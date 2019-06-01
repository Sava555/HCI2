using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace HCI2
{
    /// <summary>
    /// Interaction logic for FormaLokal.xaml
    /// </summary>
    public partial class FormaLokal : Window
    {
        public ObservableCollection<Lokal> Items { get; set; }
        public ObservableCollection<TipLokala> TipoviLokala { get; set; }
        public MainWindow Window { get; set; }
        public String IconPath { get; set; }
        public String ActiveMap { get; set; }
        public ObservableCollection<Etiketa> OdabraneEtikete { get; set; }

        public FormaLokal()
        {
            InitializeComponent();
        }

        public FormaLokal(MainWindow window)
        { 
            InitializeComponent();
            IconPath = "";
            this.Window = window;
            this.Items = window.Items;
            this.ActiveMap = window.ActiveMap;
            this.TipoviLokala = window.TipoviLokala;
            this.OdabraneEtikete = new ObservableCollection<Etiketa>();
            Tip.ItemsSource = window.TipoviLokala;
            Tip.SelectedIndex = 0;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string sourcePath = dlg.FileName;
                string targetPath = "../../Data/" + Id.Text + "." + sourcePath.Split('.')[1];
                System.IO.File.Copy(sourcePath, targetPath,true);
                IconPath = targetPath;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SluzenjeAlkohola sluzenje = SluzenjeAlkohola.NE_SLUZI;
            switch(StatusSluzenjaAlkohola.Text)
            {
                case "Ne sluzi":
                    sluzenje = SluzenjeAlkohola.NE_SLUZI;
                    break;
                case "Sluzi do 23h":
                    sluzenje = SluzenjeAlkohola.SLUZI_DO_23;
                    break;
                case "Sluzi celu noc":
                    sluzenje = SluzenjeAlkohola.SLUZI_NOCU;
                    break;
            }

            KategorijeCena kat = KategorijeCena.NISKE;
            switch(KategorijaCene.Text)
            {
                case "Niske":
                    kat = KategorijeCena.NISKE;
                    break;
                case "Srednje":
                    kat = KategorijeCena.SREDNJE;
                    break;
                case "Visoke":
                    kat = KategorijeCena.VISOKE;
                    break;
                case "Veoma visoke":
                    kat = KategorijeCena.IZUZETNO_VISOKE;
                    break;
            }
            TipLokala tLokala = Tip.SelectedItem as TipLokala;
            Lokal l = new Lokal(Id.Text, Naziv.Text, tLokala, sluzenje, IconPath.Equals("") ? "" : IconPath, DostupnoHendikepiranim.IsChecked ?? false, DozvoljenoPusenje.IsChecked ?? false, PrimaRezervacije.IsChecked ?? false, kat, Int32.Parse(Kapacitet.Text), DatumOtvaranja.SelectedDate.GetValueOrDefault(DateTime.Now));
            l.Etikete = this.OdabraneEtikete;
            l.UcitajIkonicu();
            this.Items.Insert(0, l);
            FileIO.UpisiLokal(this.ActiveMap.Split('.')[0] + ".bin", this.Items);
            this.Close();
        }

        private void DodajEtikete(object sender, RoutedEventArgs e)
        {
            dodajEtikete de = new dodajEtikete(Window, this.OdabraneEtikete);
            de.ShowDialog();
        }
    }
}
