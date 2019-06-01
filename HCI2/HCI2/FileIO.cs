using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace HCI2
{
    public static class FileIO
    {
        private const string PATH = "../../Data";
        public static void UpisiLokal(String fName, object items)
        {
            using (Stream stream = File.Open(PATH+"/"+fName, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, items);
            }
        }

        public static object IscitajLokal(string fName)
        {
            if (File.Exists(PATH + "/" + fName))
            {
                using (Stream stream = File.Open(PATH + "/" + fName, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return bformatter.Deserialize(stream);
                }
            }
            return new ObservableCollection<Lokal>(); 
            
        }
        public static object UcitajSLiku(string fName)
        {
            if (File.Exists(PATH + "/" + fName))
            {
                return new WriteableBitmap(new BitmapImage(new Uri(PATH + "/" + fName, UriKind.Relative)));
            }
            return null;

        }

        internal static object IscitajTipLokal(string fName)
        {
            if (File.Exists(PATH + "/" + fName))
            {
                using (Stream stream = File.Open(PATH + "/" + fName, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return bformatter.Deserialize(stream);
                }
            }
            return new ObservableCollection<TipLokala>();
        }
        internal static object IscitajEtiketa(string fName)
        {
            if (File.Exists(PATH + "/" + fName))
            {
                using (Stream stream = File.Open(PATH + "/" + fName, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return bformatter.Deserialize(stream);
                }
            }
            return new ObservableCollection<Etiketa>();
        }
    }
}
