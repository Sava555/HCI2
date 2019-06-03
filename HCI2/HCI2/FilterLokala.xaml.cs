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
    /// Interaction logic for FilterLokala.xaml
    /// </summary>
    public partial class FilterLokala : Window
    {

        public ObservableCollection<Lokal> Mapa1 { get; set; }
        public ObservableCollection<Lokal> Mapa2 { get; set; }
        public ObservableCollection<Lokal> Mapa3 { get; set; }
        public ObservableCollection<Lokal> Mapa4 { get; set; }
        public ObservableCollection<TipLokala> TipoviLokala { get; set; }
        public ObservableCollection<Etiketa> Etikete { get; set; }
        public MainWindow window { get; set; }
        public String ActiveMap { get; set; }
        ObservableCollection<Lokal> filtriraniLokali = new ObservableCollection<Lokal>();


        public FilterLokala(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            this.TipoviLokala = window.TipoviLokala;
            this.ActiveMap = window.ActiveMap;
            Mapa1 = window.Mapa1;
            Mapa2 = window.Mapa2;
            Mapa3 = window.Mapa3;
            Mapa4 = window.Mapa4;

        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "searchfilter";
            HelpProvider.ShowHelp(str);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FilterDataButton_Click(object sender, RoutedEventArgs e)
        {

            if (ActiveMap.Equals("mapa1.gif"))
            {
                //---------------------STATUS CENA LOKALA----------------------//
                foreach (Lokal l in Mapa1)
                {
                    if ((bool)(niskeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("NISKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(srednjeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("SREDNJE"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(visokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(izuzetnoVisokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("IZUZETNO_VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }

                    //---------------------SLUZENJE ALKOHOLA----------------------//

                    if ((bool)(nesluziCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("NE_SLUZI"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluzi23Check.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_DO_23"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluziKasnoCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_NOCU"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }

                    //---------------------OSTALO----------------------//

                    if ((bool)(pusenjeCheck.IsChecked))
                    {
                        if (l.DozvoljenoPusenje)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(rezervacijeCheck.IsChecked))
                    {
                        if (l.PrimaRezervacije)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(dosupanCheck.IsChecked))
                    {
                        if (l.DostupanHendikepiranim)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }

                }
            }

            if (ActiveMap.Equals("mapa2.jpg"))
            {
                foreach (Lokal l in Mapa2)
                {
                    if ((bool)(niskeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("NISKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(srednjeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("SREDNJE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(visokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(izuzetnoVisokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("IZUZETNO_VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }

                    //---------------------SLUZENJE ALKOHOLA----------------------//

                    if ((bool)(nesluziCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("NE_SLUZI"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluzi23Check.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_DO_23"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluziKasnoCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_NOCU"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }

                    //---------------------OSTALO----------------------//

                    if ((bool)(pusenjeCheck.IsChecked))
                    {
                        if (l.DozvoljenoPusenje)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(rezervacijeCheck.IsChecked))
                    {
                        if (l.PrimaRezervacije)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(dosupanCheck.IsChecked))
                    {
                        if (l.DostupanHendikepiranim)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                }
            }

            if (ActiveMap.Equals("mapa3.jpg"))
            {
                foreach (Lokal l in Mapa3)
                {
                    if ((bool)(niskeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("NISKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(srednjeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("SREDNJE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(visokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(izuzetnoVisokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("IZUZETNO_VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }

                    //---------------------SLUZENJE ALKOHOLA----------------------//

                    if ((bool)(nesluziCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("NE_SLUZI"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluzi23Check.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_DO_23"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluziKasnoCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_NOCU"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }

                    //---------------------OSTALO----------------------//

                    if ((bool)(pusenjeCheck.IsChecked))
                    {
                        if (l.DozvoljenoPusenje)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(rezervacijeCheck.IsChecked))
                    {
                        if (l.PrimaRezervacije)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(dosupanCheck.IsChecked))
                    {
                        if (l.DostupanHendikepiranim)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                }
            }

            if (ActiveMap.Equals("mapa4.jpg"))
            {
                foreach (Lokal l in Mapa4)
                {
                    if ((bool)(niskeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("NISKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(srednjeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("SREDNJE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(visokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }
                    else if ((bool)(izuzetnoVisokeCheck.IsChecked))
                    {
                        if (l.KategorijaCene.ToString().Equals("IZUZETNO_VISOKE"))
                        {
                            filtriraniLokali.Add(l);
                            Console.WriteLine(filtriraniLokali);
                        }
                    }

                    //---------------------SLUZENJE ALKOHOLA----------------------//

                    if ((bool)(nesluziCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("NE_SLUZI"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluzi23Check.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_DO_23"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(sluziKasnoCheck.IsChecked))
                    {
                        if (l.StatusSluzenjaAlkohola.ToString().Equals("SLUZI_NOCU"))
                        {
                            filtriraniLokali.Add(l);
                        }
                    }

                    //---------------------OSTALO----------------------//

                    if ((bool)(pusenjeCheck.IsChecked))
                    {
                        if (l.DozvoljenoPusenje)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(rezervacijeCheck.IsChecked))
                    {
                        if (l.PrimaRezervacije)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                    else if ((bool)(dosupanCheck.IsChecked))
                    {
                        if (l.DostupanHendikepiranim)
                        {
                            filtriraniLokali.Add(l);
                        }
                    }
                }
            }

            window.Items = filtriraniLokali;
            window.lvDataBinding.ItemsSource = filtriraniLokali;
            window.renderMap();
            this.Close();

        }
    }
}
