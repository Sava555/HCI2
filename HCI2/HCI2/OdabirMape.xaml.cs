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


        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "odabirmape";
            HelpProvider.ShowHelp(str);
        }

        private void Mapa1_Selected(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                window.ActiveMap = "mapa1.gif";
                window.Items = window.Mapa1;
                window.lvDataBinding.ItemsSource = window.Items;
                window.OnLoad();
                e.Handled = true;
                this.Close();
            }
        }

        private void Mapa2_Selected(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                window.ActiveMap = "mapa2.jpg";
                window.Items = window.Mapa2;
                window.lvDataBinding.ItemsSource = window.Items;
                window.OnLoad();
                this.Close();
            }
        }

        private void Mapa3_Selected(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                window.ActiveMap = "mapa3.jpg";
                window.Items = window.Mapa3;
                window.lvDataBinding.ItemsSource = window.Items;
                window.OnLoad();
                this.Close();
            }
        }

        private void Mapa4_Selected(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                window.ActiveMap = "mapa4.jpg";
                window.Items = window.Mapa4;
                window.lvDataBinding.ItemsSource = window.Items;
                window.OnLoad();
                this.Close();
            }
        }

        private void Mapa1_Selected_click(object sender, MouseButtonEventArgs e)
        {
            window.ActiveMap = "mapa1.gif";
            window.Items = window.Mapa1;
            window.lvDataBinding.ItemsSource = window.Items;
            window.OnLoad();
            e.Handled = true;
            this.Close();
        }
        private void Mapa2_Selected_click(object sender, MouseButtonEventArgs e)
        {
            window.ActiveMap = "mapa2.jpg";
            window.Items = window.Mapa2;
            window.lvDataBinding.ItemsSource = window.Items;
            window.OnLoad();
            this.Close();
        }
        private void Mapa3_Selected_click(object sender, MouseButtonEventArgs e)
        {
            window.ActiveMap = "mapa3.jpg";
            window.Items = window.Mapa3;
            window.lvDataBinding.ItemsSource = window.Items;
            window.OnLoad();
            this.Close();
        }
        private void Mapa4_Selected_click(object sender, MouseButtonEventArgs e)
        {
            window.ActiveMap = "mapa4.jpg";
            window.Items = window.Mapa4;
            window.lvDataBinding.ItemsSource = window.Items;
            window.OnLoad();
            this.Close();
        }
    }
}
