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
        public ObservableCollection<Lokal> Items;
        public String IconPath { get; set; }

        public FormaLokal()
        {
            InitializeComponent();
        }

        public FormaLokal(ObservableCollection<Lokal> Items)
        {
            this.Items = Items;
            InitializeComponent();
            IconPath = "";
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
                string targetPath = "./" + System.IO.Path.GetFileName(sourcePath);
                System.IO.File.Copy(sourcePath, targetPath);
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
            Lokal l = new Lokal(Id.Text, Naziv.Text, Tip.Text, sluzenje, IconPath.Equals("") ? "./icon.png" : IconPath, DostupnoHendikepiranim.IsChecked ?? false, DozvoljenoPusenje.IsChecked ?? false, PrimaRezervacije.IsChecked ?? false, kat, Int32.Parse(Kapacitet.Text), DatumOtvaranja.SelectedDate.GetValueOrDefault(DateTime.Now));
            l.UcitajIkonicu();
            this.Items.Add(l);
            FileIO.UpisiLokal("./lokali.bin", this.Items);
            this.Close();
        }

    }
}
