using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace HCI2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Lokal> Items { get; set; }
        public String ActiveMap { get; set; }
        public MainWindow()
        {
            ActiveMap = "./ns.gif";
            InitializeComponent();
            OnLoad();
            
            Items = (ObservableCollection<Lokal>)FileIO.IscitajLokal("./lokali.bin");
            if (Items == null)
            {
                Items = new ObservableCollection<Lokal>();
            }
            foreach (Lokal l in Items)
            {
                l.UcitajIkonicu();
            }
            lvDataBinding.ItemsSource = Items;
            
        }

        // dodavanje novog lokala
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormaLokal forma = new FormaLokal(this.Items);
            forma.Show();
        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var matrix = MyImage.LayoutTransform.Value;

            if (e.Delta > 0)
            {
                matrix.ScaleAt(1.5, 1.5, e.GetPosition(this).X, e.GetPosition(this).Y);
            }
            else
            {
                matrix.ScaleAt(1.0 / 1.5, 1.0 / 1.5, e.GetPosition(this).X, e.GetPosition(this).Y);
            }

            MyImage.LayoutTransform = new MatrixTransform(matrix);
        }

        private WriteableBitmap writeableBitmap;

        public void OnLoad()
        {
            var image = new WriteableBitmap(new BitmapImage(new Uri(ActiveMap, UriKind.Relative)));

            MyImage.Width = image.Width;
            MyImage.Height = image.Height;

            image = BitmapFactory.ConvertToPbgra32Format(image);

            writeableBitmap = image;

            MyImage.Source = image;
        }

        private Point downPoint;
        private Point upPoint;

        private void MyImage_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            downPoint = e.GetPosition(MyImage);
        }

        private void MyImage_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            upPoint = e.GetPosition(MyImage);

            writeableBitmap.DrawRectangle(Convert.ToInt32(downPoint.X), Convert.ToInt32(downPoint.Y), Convert.ToInt32(upPoint.X), Convert.ToInt32(upPoint.Y), Colors.Red);
            MyImage.Source = writeableBitmap;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OdabirMape dlg = new OdabirMape(this);
            dlg.Show();
        }
    }
}
