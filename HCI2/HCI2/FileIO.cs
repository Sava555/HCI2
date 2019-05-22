using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HCI2
{
    public static class FileIO
    {
        public static void UpisiLokal(string path, object items)
        {
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, items);
            }
        }

        public static object IscitajLokal(string path)
        {
            if (File.Exists(path))
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    return bformatter.Deserialize(stream);
                }
            }
            return null; 
            
        }
    }
}
