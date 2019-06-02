using Microsoft.Win32;
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
    /// Interaction logic for EditLokal.xaml
    /// </summary>
    public partial class EditLokal : Window
    {
        private int itemIndex;
        public String IconPath { get; set; }
        public String ActiveMap { get; set; }
        public ObservableCollection<TipLokala> TipoviLokala;
        public MainWindow Window { get; set; }
        public EditLokal()
        {
            InitializeComponent();
        }

        public EditLokal(MainWindow window, int index)
        {
            Lokal item = window.Items[index];
            this.itemIndex = index;
            this.TipoviLokala = window.TipoviLokala;
            this.ActiveMap = window.ActiveMap;
            this.Window = window;
            InitializeComponent();
            Tip.ItemsSource = window.TipoviLokala;
            IconPath = "";
            foreach (TipLokala it in Tip.Items)
            {
                if (it.Equals(item.Tip))
                {
                    Tip.SelectedItem = it;
                    break;
                }
            }

            foreach (ComboBoxItem it in StatusSluzenjaAlkohola.Items)
            {
                string content = it.Content.ToString();
                content = content.Replace(' ', '_');
                content = content.ToUpper();
                if(content.Equals(item.StatusSluzenjaAlkohola.ToString()))
                {
                    it.IsSelected = true;
                    break;
                }
            }
            
            foreach (ComboBoxItem it in KategorijaCene.Items)
            {
                string content = it.Content.ToString();
                content = content.Replace(' ', '_');
                content = content.ToUpper();
                if (content.Equals(item.KategorijaCene.ToString()))
                {
                    it.IsSelected = true;
                    break;
                }
            }
            Id.Text = item.Id;
            Naziv.Text = item.Naziv;
            this.Kapacitet.Text = item.Kapacitet.ToString()    ;
            DostupnoHendikepiranim.IsChecked = item.DostupanHendikepiranim;
            DozvoljenoPusenje.IsChecked = item.DozvoljenoPusenje;
            PrimaRezervacije.IsChecked = item.PrimaRezervacije;
            DatumOtvaranja.SelectedDate = item.DatumOtvaranja;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                string sourcePath = dlg.FileName;
                string targetPath = "../../Data/" + this.Window.Items[this.itemIndex].Id + "." + sourcePath.Split('.')[1];
                try
                {
                    System.IO.File.Copy(sourcePath, targetPath, true);
                }
                catch
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Nije BIlo moguce ucitati sliku");
                    return;
                }
                IconPath = targetPath;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SluzenjeAlkohola sluzenje = this.Window.Items[this.itemIndex].StatusSluzenjaAlkohola;
            switch (StatusSluzenjaAlkohola.Text)
            {
                case "Ne sluzi":
                    sluzenje = SluzenjeAlkohola.NE_SLUZI;
                    break;
                case "Sluzi do 23":
                    sluzenje = SluzenjeAlkohola.SLUZI_DO_23;
                    break;
                case "Sluzi nocu":
                    sluzenje = SluzenjeAlkohola.SLUZI_NOCU;
                    break;
            }

            KategorijeCena kat = this.Window.Items[this.itemIndex].KategorijaCene;
            switch (KategorijaCene.Text)
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
                case "Izuzetno visoke":
                    kat = KategorijeCena.IZUZETNO_VISOKE;
                    break;
            }
            var item = this.Window.Items[this.itemIndex];
            item.Id = Id.Text;
            item.Naziv = Naziv.Text;
            item.Tip = Tip.SelectedItem as TipLokala;
            item.StatusSluzenjaAlkohola = sluzenje;
            item.Ikonica = IconPath.Equals("") ? this.Window.Items[this.itemIndex].Ikonica : IconPath;
            item.DostupanHendikepiranim = DostupnoHendikepiranim.IsChecked ?? false;
            item.DozvoljenoPusenje = DozvoljenoPusenje.IsChecked ?? false;
            item.PrimaRezervacije = PrimaRezervacije.IsChecked ?? false;
            item.KategorijaCene = kat;
            item.Kapacitet = Int32.Parse(Kapacitet.Text);
            item.DatumOtvaranja = DatumOtvaranja.SelectedDate.GetValueOrDefault(DateTime.Now);
            item.UcitajIkonicu();
            FileIO.UpisiLokal(this.ActiveMap.Split('.')[0] + ".bin", this.Window.Items);
            this.Window.renderMap();
            this.Window.lvDataBinding.ItemsSource = this.Window.Items;
            this.Close();
        }

        private void IzmeniEtikete(object sender, RoutedEventArgs e)
        {
            dodajEtikete de = new dodajEtikete(Window, this.Window.Items[this.itemIndex]);
            de.ShowDialog();
            FileIO.UpisiLokal(this.ActiveMap.Split('.')[0] + ".bin", this.Window.Items); 
        }
    }
}
