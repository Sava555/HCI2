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
    /// Interaction logic for OdabirMape.xaml
    /// </summary>
    public partial class OdabirMape : Window
    {
        public MainWindow window { get; set; }
        public OdabirMape(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void NoviSad_Selected(object sender, RoutedEventArgs e)
        {
            window.ActiveMap = "./ns.gif";
            window.OnLoad();
            this.Close();
        }

        private void Beograd_Selected(object sender, RoutedEventArgs e)
        {
            window.ActiveMap = "./bg.jpg";
            window.OnLoad();
            this.Close();
        }

        private void Subotica_Selected(object sender, RoutedEventArgs e)
        {
            window.ActiveMap = "./sub.jpg";
            window.OnLoad();
            this.Close();
        }
    }
}
