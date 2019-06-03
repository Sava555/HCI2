using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace HCI2
{
    /// <summary>
    /// Interaction logic for TransferLokala.xaml
    /// </summary>
    public partial class TransferLokala : Window
    {
        public MainWindow window { get; set; }
        public ObservableCollection<Lokal> Items { get; set; }
        public Point startPoint { get; private set; }

        public TransferLokala(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }
        private void Mapa1_Selected(object sender, EventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa1.gif"))
            {
                this.Items = window.Mapa1;
                lvDataBinding.ItemsSource = this.Items;
            }
            else
            {
                this.Items = new ObservableCollection<Lokal>();
                lvDataBinding.ItemsSource = this.Items;
            }
            
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "transferlokala";
            HelpProvider.ShowHelp(str);
        }

        private void Mapa2_Selected(object sender, EventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa2.jpg"))
            {
                this.Items = window.Mapa2;
                lvDataBinding.ItemsSource = this.Items;
            }
            else
            {
                this.Items = new ObservableCollection<Lokal>();
                lvDataBinding.ItemsSource = this.Items;
            }
        }

        private void Mapa3_Selected(object sender, EventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa3.jpg"))
            {
                this.Items = window.Mapa3;
                lvDataBinding.ItemsSource = this.Items;    
            }
            else
            {
                this.Items = new ObservableCollection<Lokal>();
                lvDataBinding.ItemsSource = this.Items;
            }
        }

        private void Mapa4_Selected(object sender, EventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa4.jpg"))
            {
                this.Items = window.Mapa4;
                lvDataBinding.ItemsSource = this.Items;
            }
            else
            {
                this.Items = new ObservableCollection<Lokal>();
                lvDataBinding.ItemsSource = this.Items;
            }
        }

        private void Mapa1_Selected_click(object sender, MouseButtonEventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa1.gif"))
            {
                this.Items = window.Mapa1;
                lvDataBinding.ItemsSource = this.Items;
                e.Handled = true;
            }
            else
            {
                this.Items = new ObservableCollection<Lokal>();
                lvDataBinding.ItemsSource = this.Items;
            }
        }
        private void Mapa2_Selected_click(object sender, MouseButtonEventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa2.jpg"))
            {
                this.Items = window.Mapa2;
                lvDataBinding.ItemsSource = this.Items;
                e.Handled = true;
            }
        }
        private void Mapa3_Selected_click(object sender, MouseButtonEventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa3.jpg"))
            {
                this.Items = window.Mapa3;
                lvDataBinding.ItemsSource = this.Items;
                e.Handled = true;
            }
            else
            {
                this.Items = new ObservableCollection<Lokal>();
                lvDataBinding.ItemsSource = this.Items;
            }
        }
        private void Mapa4_Selected_click(object sender, MouseButtonEventArgs e)
        {
            if (!window.ActiveMap.Equals("mapa4.jpg"))
            {
                this.Items = window.Mapa4;
                lvDataBinding.ItemsSource = this.Items;
                e.Handled = true;
            }
            else
            {
                this.Items = new ObservableCollection<Lokal>();
                lvDataBinding.ItemsSource = this.Items;
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void LvDataBinding_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        private void LvDataBinding_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                Lokal lokal;
                // Find the data behind the ListViewItem
                try
                {
                    lokal = listView.ItemContainerGenerator.
                        ItemFromContainer(listViewItem) as Lokal;
                }
                catch
                {
                    return;
                }
                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("lokalTransfer", lokal);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Link);
            }
        }
        private void ShowDetails(object sender, MouseButtonEventArgs e)
        {
            ListView v = sender as ListView;
            EditLokal elokal = new EditLokal(this.window, v.SelectedItem as Lokal);
            elokal.Show();
        }
    }
}
