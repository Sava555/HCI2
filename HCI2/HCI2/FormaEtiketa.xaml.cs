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
    /// Interaction logic for FormaEtiketa.xaml
    /// </summary>
    public partial class FormaEtiketa : Window
    {
        private MainWindow Window { get; set; }
        public FormaEtiketa(MainWindow window)
        {
            InitializeComponent();
            this.Window = window;
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "novaetiketa";
            HelpProvider.ShowHelp(str);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Id.Text.Equals("") || Opis.Text.Equals("") || ClrPcker.SelectedColor.ToString().Equals(""))
            {
                MessageBox.Show("Neophodno je popuniti polja!");
                Id.Focus();
                return;
            }
            foreach (Etiketa ee in Window.Etikete)
            {
                if (ee.Id.Equals(Id.Text))
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Uneseni Id je vec odabran");
                    return;
                }
            }
            Etiketa et;
            try
            {
                et = new Etiketa(Id.Text, Opis.Text, ClrPcker.SelectedColor);
            }catch
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Doslo je do greske pri unosu");
                return;
            }
            Window.Etikete.Add(et);
            FileIO.UpisiLokal("etikete.bin", Window.Etikete);
            this.Close();
        }
    }
}
