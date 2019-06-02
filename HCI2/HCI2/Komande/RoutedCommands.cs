using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI2.Komande
{
    class RoutedCommands
    {
        public static RoutedUICommand NoviLokal = new RoutedUICommand(
            "Otvara prozor za dodavanje novog Lokala",
            "NoviLokal",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.N,ModifierKeys.Control)
            }
            );

        public static RoutedUICommand NoviTipLokal = new RoutedUICommand(
            "Otvara prozor za dodavanje novog Tipa Lokala",
            "NoviTipLokal",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T,ModifierKeys.Control)
            }
            );

        public static RoutedUICommand PromenaTipLokal = new RoutedUICommand(
            "Otvara prozor za menjanje Tipa Lokala",
            "PromenaTipLokal",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T,ModifierKeys.Control|ModifierKeys.Shift)
            }
            );

        public static RoutedUICommand NovaEtiketa = new RoutedUICommand(
            "Otvara prozor za dodavanje nove Etikete",
            "NovaEtiketa",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E,ModifierKeys.Control)
            }
            );
        public static RoutedUICommand PromenaEtiketa = new RoutedUICommand(
            "Otvara prozor za promenu Etiketa",
            "PromenaEtiketa",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E,ModifierKeys.Control | ModifierKeys.Shift)
            }
            );

        public static RoutedUICommand PromeniMapu = new RoutedUICommand(
            "Otvara prozor za odabir mape",
            "PromeniMapu",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.M,ModifierKeys.Control)
            }
            );
        public static RoutedUICommand PrebaciPodatke = new RoutedUICommand(
            "Otvara prozor za prebacivanje podatak sa drugih mapa",
            "PrebaciPodatke",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.M, ModifierKeys.Control | ModifierKeys.Shift)
            }
            );
    }
}
