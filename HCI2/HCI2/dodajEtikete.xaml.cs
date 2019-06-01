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
    /// Interaction logic for dodajEtikete.xaml
    /// </summary>
    public partial class dodajEtikete : Window
    {
        public MainWindow Window;
        public ObservableCollection<Etiketa> OdabraneEtikete { get; set; }
        public ObservableCollection<Etiketa> NeodabraneEtikete { get; set; }
        public dodajEtikete(MainWindow window, Lokal lokal)
        {
            InitializeComponent();
            this.OdabraneEtikete = lokal.Etikete;
            this.NeodabraneEtikete = new ObservableCollection<Etiketa>();
            foreach (Etiketa et in window.Etikete)
            {
                bool flag = false;
                foreach(Etiketa etIz in lokal.Etikete)
                {
                    if (et.Id.Equals(etIz.Id))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    NeodabraneEtikete.Add(et);
                }
            }
            this.etikete.ItemsSource = this.NeodabraneEtikete;
            this.Odabrane.ItemsSource = this.OdabraneEtikete;
        }
        public dodajEtikete(MainWindow window, ObservableCollection<Etiketa> odabraneEtikete)
        {
            InitializeComponent();
            this.OdabraneEtikete = odabraneEtikete;
            this.NeodabraneEtikete = new ObservableCollection<Etiketa>();
            foreach (Etiketa et in window.Etikete)
            {
                bool flag = false;
                foreach (Etiketa etIz in this.OdabraneEtikete)
                {
                    if (et.Id.Equals(etIz.Id))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    NeodabraneEtikete.Add(et);
                }
            }
            this.etikete.ItemsSource = this.NeodabraneEtikete;
            this.Odabrane.ItemsSource = this.OdabraneEtikete;
        }

        private void OdaberiEtiketu(object sender, EventArgs e)
        {
            Etiketa et = etikete.SelectedItem as Etiketa;
            if(et == null)
            {
                return;
            }
            etikete.SelectedItem = null;
            OdabraneEtikete.Insert(0,et);
            NeodabraneEtikete.Remove(et);
            this.Odabrane.ItemsSource = OdabraneEtikete; 
        }

        private void Otkloni(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Etiketa et = button.DataContext as Etiketa;
            OdabraneEtikete.Remove(et);
            NeodabraneEtikete.Add(et);
        }
    }
}
