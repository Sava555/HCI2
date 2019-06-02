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

namespace HCI2
{
    /// <summary>
    /// Interaction logic for FormaTipLokala.xaml
    /// </summary>
    public partial class FormaTipLokala : Window
    {
        private string IconPath { get; set; }
        private MainWindow Window { get; set; }
        public FormaTipLokala(MainWindow window)
        {
            InitializeComponent();
            this.IconPath = "";
            this.Window = window;
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "novitip";
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
                string targetPath = "../../Data/tip" + Id.Text + "." + sourcePath.Split('.')[1];
                System.IO.File.Copy(sourcePath, targetPath, true);
                IconPath = targetPath;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(TipLokala tl in this.Window.TipoviLokala)
            {
                if (tl.Id.Equals(Id.Text))
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Uneseni Id je vec u upotrebi");
                    Id.Focus();
                    return;
                }
            }

            TipLokala tLokala;
            try
            {
                tLokala = new TipLokala(Id.Text, Naziv.Text, Opis.Text, IconPath.Equals("") ? "../../Data/icon.png" : IconPath);
            }catch
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Doslo je do greske pri unosu");
                return;
            }
            this.Window.TipoviLokala.Add(tLokala);
            FileIO.UpisiLokal("tipoviLokala.bin", this.Window.TipoviLokala);
            this.Close();
        }
    }
}
