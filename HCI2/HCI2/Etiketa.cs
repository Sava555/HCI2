using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCI2
{
    [Serializable]
    public class Etiketa : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public string Id { get; set; }
        private String _opis;
        public String Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                _opis = value;
                OnPropertyChanged("Opis");
            }
        }
        private String _boja;
        public String Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                _boja = value;
                OnPropertyChanged("Boja");
            }
        }
        [NonSerialized]
        private Color? _color;
        public Color? Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public Etiketa()
        {
            Id = "";
            Opis = "";
        }

        public Etiketa(string id, string opis, Color? color)
        {
            this.Id = id;
            this.Opis = opis;
            this.Color = color;
            this.Boja = color.ToString();
        }

        public void ucitajBoju()
        {
            this.Color = ColorConverter.ConvertFromString(this.Boja) as Color?;
        }
        public override string ToString()
        {
            return Opis;
        }

        public override bool Equals(object obj)
        {
            return obj is Etiketa etiketa &&
                   Id == etiketa.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }
    }
}
