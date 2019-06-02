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
using System.Drawing;
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
        public ObservableCollection<Lokal> Items { get; set; }
        public ObservableCollection<Lokal> Mapa1 { get; set; }
        public ObservableCollection<Lokal> Mapa2 { get; set; }
        public ObservableCollection<Lokal> Mapa3 { get; set; }
        public ObservableCollection<Lokal> Mapa4 { get; set; }
        public ObservableCollection<TipLokala> TipoviLokala { get; set; }

        public ObservableCollection<Etiketa> Etikete { get; set; }
        public Point startPoint { get; set; }
        public String ActiveMap { get; set; }

        private const int picSize = 20;

        public MainWindow()
        {
            ActiveMap = "mapa1.gif";
            InitializeComponent();
            this.Etikete = (ObservableCollection<Etiketa>)FileIO.IscitajEtiketa("etikete.bin");
            this.TipoviLokala = (ObservableCollection<TipLokala>)FileIO.IscitajTipLokal("tipoviLokala.bin");
            Mapa1 = (ObservableCollection<Lokal>)FileIO.IscitajLokal("mapa1.bin");
            Mapa2 = (ObservableCollection<Lokal>)FileIO.IscitajLokal("mapa2.bin");
            Mapa3 = (ObservableCollection<Lokal>)FileIO.IscitajLokal("mapa3.bin");
            Mapa4 = (ObservableCollection<Lokal>)FileIO.IscitajLokal("mapa4.bin");
            izjednaciLokale();
            Items = Mapa1;
            if (Items == null)
            {
                Items = new ObservableCollection<Lokal>();
            }
            foreach(Etiketa et in this.Etikete)
            {
                et.ucitajBoju();
            }
            ucitaj_ikonice();
            lvDataBinding.ItemsSource = Items;
            OnLoad();

        }

        private void izjednaciLokale()
        {
            foreach (Lokal l in Mapa1)
            {
                for(int i = 0; i < Mapa2.Count; i++)
                {
                    Lokal l2 = Mapa2[i];
                    if (l2.Id.Equals(l.Id))
                    {
                        Mapa2[i] = l;
                    }
                }
                for (int i = 0; i < Mapa3.Count; i++)
                {
                    Lokal l2 = Mapa3[i];
                    if (l2.Id.Equals(l.Id))
                    {
                        Mapa3[i] = l;
                    }
                }
                for (int i = 0; i < Mapa4.Count; i++)
                {
                    Lokal l2 = Mapa4[i];
                    if (l2.Id.Equals(l.Id))
                    {
                        Mapa4[i] = l;
                    }
                }
            }
            foreach (Lokal l in Mapa2)
            {
                for (int i = 0; i < Mapa3.Count; i++)
                {
                    Lokal l2 = Mapa3[i];
                    if (l2.Id.Equals(l.Id))
                    {
                        Mapa3[i] = l;
                    }
                }
                for (int i = 0; i < Mapa4.Count; i++)
                {
                    Lokal l2 = Mapa4[i];
                    if (l2.Id.Equals(l.Id))
                    {
                        Mapa4[i] = l;
                    }
                }
            }
            foreach (Lokal l in Mapa3)
            {
                for (int i = 0; i < Mapa4.Count; i++)
                {
                    Lokal l2 = Mapa4[i];
                    if (l2.Id.Equals(l.Id))
                    {
                        Mapa4[i] = l;
                    }
                }
            }
        }

        private void SacuvajLokale()
        {
            FileIO.UpisiLokal("mapa1.bin", Mapa1);
            FileIO.UpisiLokal("mapa2.bin", Mapa2);
            FileIO.UpisiLokal("mapa3.bin", Mapa3);
            FileIO.UpisiLokal("mapa4.bin", Mapa4);
        }

        public void ObrisiEtikete(Etiketa et)
        {
            foreach (Lokal l in Mapa1)
            {
                l.Etikete?.Remove(et);
            }
            foreach (Lokal l in Mapa2)
            {
                l.Etikete?.Remove(et);
            }
            foreach (Lokal l in Mapa3)
            {
                l.Etikete?.Remove(et);
            }
            foreach (Lokal l in Mapa4)
            {
                l.Etikete?.Remove(et);
            }
            this.SacuvajLokale();
        }
        public void OsveziEtikete(Etiketa et)
        {
            foreach (Lokal l in Mapa1)
            {
                for(int i = 0; i < l.Etikete?.Count; i++)
                {
                    Etiketa etiketa = l.Etikete[i];
                    if (etiketa.Equals(et))
                    {
                        etiketa = et;
                        break;
                    }
                }
            }
            foreach (Lokal l in Mapa2)
            {
                for (int i = 0; i < l.Etikete?.Count; i++)
                {
                    Etiketa etiketa = l.Etikete[i];
                    if (etiketa.Equals(et))
                    {
                        etiketa = et;
                        break;
                    }
                }
            }
            foreach (Lokal l in Mapa3)
            {
                for (int i = 0; i < l.Etikete?.Count; i++)
                {
                    Etiketa etiketa = l.Etikete[i];
                    if (etiketa.Equals(et))
                    {
                        etiketa = et;
                        break;
                    }
                }
            }
            foreach (Lokal l in Mapa4)
            {
                for (int i = 0; i < l.Etikete?.Count; i++)
                {
                    Etiketa etiketa = l.Etikete[i];
                    if (etiketa.Equals(et))
                    {
                        etiketa = et;
                        break;
                    }
                }
            }
            this.SacuvajLokale();
        }
        public void ucitaj_ikonice()
        {
            foreach (Lokal l in Mapa1)
            {
                l.UcitajIkonicu();
            }
            foreach (Lokal l in Mapa2)
            {
                l.UcitajIkonicu();
            }
            foreach (Lokal l in Mapa3)
            {
                l.UcitajIkonicu();
            }
            foreach (Lokal l in Mapa4)
            {
                l.UcitajIkonicu();
            }
        }
        public void place_Icon(ref WriteableBitmap dest, int nXDest, int nYDest, ref WriteableBitmap src)
        {
            // copy the source image into a byte buffer
            int src_stride = src.PixelWidth * (src.Format.BitsPerPixel >> 3);
            byte[] src_buffer = new byte[src_stride * src.PixelHeight];
            src.CopyPixels(src_buffer, src_stride, 0);

            // copy the dest image into a byte buffer
            int dest_stride = src.PixelWidth * (dest.Format.BitsPerPixel >> 3);
            byte[] dest_buffer = new byte[(src.PixelWidth * src.PixelHeight) << 2];
            try
            {
                dest.CopyPixels(new Int32Rect(nXDest, nYDest, src.PixelWidth, src.PixelHeight), dest_buffer, dest_stride, 0);
            }
            catch
            {
                return;
            }
            // do merge (could be made faster through parallelization)
            for (int i = 0; i < src_buffer.Length; i = i + 4)
            {
                float src_alpha = ((float)src_buffer[i + 3] / 255);
                dest_buffer[i + 0] = (byte)((src_buffer[i + 0] * src_alpha) + dest_buffer[i + 0] * (1.0 - src_alpha));
                dest_buffer[i + 1] = (byte)((src_buffer[i + 1] * src_alpha) + dest_buffer[i + 1] * (1.0 - src_alpha));
                dest_buffer[i + 2] = (byte)((src_buffer[i + 2] * src_alpha) + dest_buffer[i + 2] * (1.0 - src_alpha));
            }

            // copy dest buffer back to the dest WriteableBitmap
            dest.WritePixels(new Int32Rect(nXDest, nYDest, src.PixelWidth, src.PixelHeight), dest_buffer, dest_stride, 0);
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

        // dodavanje novog lokala
        private void NoviLokal(object sender, RoutedEventArgs e)
        {
            FormaLokal forma = new FormaLokal(this);
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
            var image = FileIO.UcitajSLiku(this.ActiveMap) as WriteableBitmap;

            MyImage.Width = image.Width;
            MyImage.Height = image.Height;

            image = BitmapFactory.ConvertToPbgra32Format(image);

            writeableBitmap = image;

            MyImage.Source = image;
            this.renderMap();
        }

        public void renderMap()
        {
            var map = writeableBitmap.Clone();
            foreach (Lokal lokal in this.Items)
            {
                if (lokal.Filter)
                {
                    map.FillRectangle(lokal.XPoint[this.ActiveMap] - picSize - 4, lokal.YPoint[this.ActiveMap] - picSize - 4, lokal.XPoint[this.ActiveMap] + picSize + 4, lokal.YPoint[this.ActiveMap] + picSize + 4, Colors.DarkOrange);
                }
                if (!(!lokal.XPoint.ContainsKey(this.ActiveMap) || !lokal.YPoint.ContainsKey(this.ActiveMap)))
                {
                    var im = lokal.Slicica;
                    im = im.Resize(picSize * 2, picSize * 2, WriteableBitmapExtensions.Interpolation.Bilinear);
                    this.place_Icon(ref map, lokal.XPoint[this.ActiveMap] - picSize , lokal.YPoint[this.ActiveMap] - picSize, ref im);
                }                
            }
            MyImage.Source = map;
        }

        private bool check_Colision(int x1, int y1, int x2, int y2)
        { 
            if(x1 - picSize > x2 + picSize || x2 - picSize > x1 + picSize)
            {
                return false;
            }
            if (y1 + picSize < y2 - picSize || y2 + picSize < y1 - picSize)
            {
                return false;
            }
            return true;
        }

        private void Mape(object sender, RoutedEventArgs e)
        {
            OdabirMape dlg = new OdabirMape(this);
            dlg.ShowDialog();
        }

        private void LvDataBinding_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = Mouse.DirectlyOver;
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str);
            }
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
                DataObject dragData = new DataObject("lokal", lokal);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Link);
            }
        }

        private void MyImage_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("lokal") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
            if (!e.Data.GetDataPresent("lokalTransfer") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MyImage_Drop(object sender, DragEventArgs e)
        {
            Point myPoint = e.GetPosition(sender as Image);
            int x = Convert.ToInt32(myPoint.X);
            int y = Convert.ToInt32(myPoint.Y);
            bool f = false;
            if (e.Data.GetDataPresent("lokalTransfer"))
            {
                f = true;
            }
            if (e.Data.GetDataPresent("lokal") || f)
            {
                bool flag = false;
                Lokal lokal = null;
                if (f)
                {
                    lokal = e.Data.GetData("lokalTransfer") as Lokal;
                    if (!this.Items.Contains(lokal))
                    { 
                        this.Items.Insert(0, lokal);
                    }
                    else
                    {
                        lokal = this.Items[this.Items.IndexOf(lokal)];
                    }
                }
                else
                {
                    lokal = e.Data.GetData("lokal") as Lokal;
                }
                foreach (Lokal lo in this.Items)
                {
                    if(lo.Id == lokal.Id)
                    {
                        continue;
                    }
                    if (check_Colision(x, y, lo.XPoint[this.ActiveMap], lo.YPoint[this.ActiveMap]))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    lokal.XPoint[this.ActiveMap] = x;
                    lokal.YPoint[this.ActiveMap] = y;
                    FileIO.UpisiLokal(ActiveMap.Split('.')[0] + ".bin", this.Items);
                    this.renderMap();
                }
            }
        }
        private void MyImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(sender as Image);
        }
        private void MyImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                foreach(Lokal lokal in this.Items)
                {
                    if(lokal.XPoint[this.ActiveMap] - picSize < startPoint.X && lokal.YPoint[this.ActiveMap] + picSize > startPoint.Y)
                    {
                        if(lokal.XPoint[this.ActiveMap] + picSize > startPoint.X && lokal.YPoint[this.ActiveMap] - picSize < startPoint.Y)
                        {
                            DataObject dragData = new DataObject("lokal", lokal);
                            DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                            break;
                        }
                    }
                }
            }
        }

        private void ShowDetails(object sender, MouseButtonEventArgs e)
        {
            ListView v = sender as ListView;
            EditLokal elokal = new EditLokal(this, v.SelectedIndex);
            elokal.Show();
        }

        private void MyImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                Lokal lokal = this.Items[i];
                if (lokal.XPoint[this.ActiveMap] - picSize < startPoint.X && lokal.YPoint[this.ActiveMap] + picSize > startPoint.Y)
                {
                    if (lokal.XPoint[this.ActiveMap] + picSize > startPoint.X && lokal.YPoint[this.ActiveMap] - picSize < startPoint.Y)
                    {
                        EditLokal elokal = new EditLokal(this, i);
                        elokal.Show();
                        break;
                    }
                }
            }
        }

        private void NoviTipLokal(object sender, ExecutedRoutedEventArgs e)
        {
            FormaTipLokala ftl = new FormaTipLokala(this);
            ftl.Show();
        }

        private void PromenaTipLokal(object sender, ExecutedRoutedEventArgs e)
        {
            EditTipLokala ed = new EditTipLokala(this);
            ed.ShowDialog();
        }

        private void NovaEtiketa(object sender, ExecutedRoutedEventArgs e)
        {
            FormaEtiketa fe = new FormaEtiketa(this);
            fe.ShowDialog();
        }

        private void PromenaEtiketa(object sender, ExecutedRoutedEventArgs e)
        {
            EditEtiketa ee = new EditEtiketa(this);
            ee.ShowDialog();
        }

        private void PrebaciPodatke(object sender, ExecutedRoutedEventArgs e)
        {
            TransferLokala tl = new TransferLokala(this);
            tl.Show();
        }
    }
}
