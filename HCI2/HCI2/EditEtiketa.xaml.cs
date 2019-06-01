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
    /// Interaction logic for EditEtiketa.xaml
    /// </summary>
    public partial class EditEtiketa : Window
    {
        private MainWindow Window { get; set; }
        public ObservableCollection<Etiketa> Etikete { get; set; }
        public EditEtiketa(MainWindow window)
        {
            InitializeComponent();
            this.Window = window;
            this.Etikete = window.Etikete;
            this.Id_Selct.ItemsSource = this.Etikete;
        }

        private void Id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Etiketa et = Id_Selct.SelectedItem as Etiketa;
            if(et == null)
            {
                return;
            }
            Opis.Text = et.Opis;
            ClrPcker.SelectedColor = ColorConverter.ConvertFromString(et.Boja) as Color?;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Etiketa et = Id_Selct.SelectedItem as Etiketa;
            et.Opis = Opis.Text;
            et.Boja = ClrPcker.SelectedColor.ToString();
            Window.OsveziEtikete(et);
            FileIO.UpisiLokal("etikete.bin", Window.Etikete);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Etiketa et = Id_Selct.SelectedItem as Etiketa;
            Window.Etikete.Remove(et);
            Window.ObrisiEtikete(et);
            FileIO.UpisiLokal("etikete.bin", Window.Etikete);
            this.Close();
        }
    }
}
