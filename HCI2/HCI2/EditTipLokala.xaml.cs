using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for EditTipLokala.xaml
    /// </summary>
    public partial class EditTipLokala : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string IconPath { get; set; }
        private MainWindow Window { get; set; }
        private ObservableCollection<TipLokala> TipoviLokala { get; set; }
        public EditTipLokala(MainWindow window)
        {
            InitializeComponent();
            this.Window = window;
            this.TipoviLokala = window.TipoviLokala;
            this.Id.ItemsSource = this.TipoviLokala;
            this.IconPath = "";
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "edittipa";
            HelpProvider.ShowHelp(str);
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
                string targetPath = "../../Data/tip" + (Id.SelectedItem as TipLokala).Id+ "." + sourcePath.Split('.')[1];
                System.IO.File.Copy(sourcePath, targetPath, true);
                IconPath = targetPath;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TipLokala lo = this.Id.SelectedItem as TipLokala;
            lo.Naziv = Naziv.Text;
            lo.Opis = Opis.Text;
            lo.Ikonica = IconPath.Equals("") ? lo.Ikonica : IconPath;
            FileIO.UpisiLokal("tipoviLokala.bin", this.Window.TipoviLokala);
            Window.ucitaj_ikonice();
            Window.renderMap();
            this.Close();
        }

        private void Id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipLokala lo = this.Id.SelectedItem as TipLokala;
            Naziv.Text = lo.Naziv;
            Opis.Text = lo.Opis;
        }
    }
}
