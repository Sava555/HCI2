using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HCI2
{
    [Serializable]
    public class TipLokala : INotifyPropertyChanged
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
        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Opis { get; set; }

        private string _naziv;
        public string Naziv {
            get
            {
                return _naziv;
            }
            set
            {
                _naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        private string _ikonica;
        public string Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                _ikonica = value;
                OnPropertyChanged("Ikonica");
            }
        }

        public TipLokala()
        {
            this.Id = "-1";
            this.Naziv = "";
            this.Opis = "";
            this.Ikonica = "";
        }
        public TipLokala(string id, string naziv, string opis, string ikonica)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Ikonica = ikonica;
        }

        public override bool Equals(object other)
        {
            TipLokala lo;
            try
            {
                lo = other as TipLokala;
            }
            catch
            {
                return false;
            }
            if(this.Id == null || lo.Id == null)
            {
                return false;
            }
            return this.Id.Equals(lo.Id);
        }

        public override int GetHashCode()
        {
            var hashCode = 178972834;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Opis);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_naziv);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naziv);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ikonica);
            return hashCode;
        }
    }
}
