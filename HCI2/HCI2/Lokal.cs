using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HCI2
{
    public enum SluzenjeAlkohola
    {
        NE_SLUZI, SLUZI_DO_23, SLUZI_NOCU
    }

    public enum KategorijeCena
    {
        NISKE, SREDNJE, VISOKE, IZUZETNO_VISOKE
    }

    [Serializable]
    public class Lokal : INotifyPropertyChanged
    {
        public String Id { get; set; }

        private String _naziv;
        public String Naziv
        {
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
        public TipLokala Tip { get; set; }
        public SluzenjeAlkohola StatusSluzenjaAlkohola { get; set; }
        public String Ikonica { get; set; }
        public bool DostupanHendikepiranim { get; set; }
        public bool DozvoljenoPusenje { get; set; }
        public bool PrimaRezervacije { get; set; }
        public KategorijeCena KategorijaCene { get; set; }
        public int Kapacitet { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        [NonSerialized]
        private WriteableBitmap _slicica;
        public WriteableBitmap Slicica {
            get {
                return _slicica;
            }
            set{
                _slicica = value;
                OnPropertyChanged("Slicica");
            }
        }

        public int XPoint { get; set; }
        public int YPoint { get; set; }
        public bool Filter { get; set; }

        public ObservableCollection<Etiketa> Etikete { get; set; }

        public Lokal(String Id, String Naziv, TipLokala Tip, SluzenjeAlkohola Status, String Ikonica, bool DostupanHendikepiranim, bool DozvoljenoPusenje, bool PrimaRezervacije, KategorijeCena KategorijaCene, int Kapacitet, DateTime DatumOtvaranja)
        {
            this.Id = Id;
            this.Naziv = Naziv;
            this.Tip = Tip;
            this.StatusSluzenjaAlkohola = Status;
            this.Ikonica = Ikonica;
            this.DostupanHendikepiranim = DostupanHendikepiranim;
            this.DozvoljenoPusenje = DozvoljenoPusenje;
            this.PrimaRezervacije = PrimaRezervacije;
            this.KategorijaCene = KategorijaCene;
            this.Kapacitet = Kapacitet;
            this.DatumOtvaranja = DatumOtvaranja;
            this.XPoint = -1;
            this.YPoint = -1;
            this.Filter = false;
        }

        public override string ToString()
        {
            return this.Id + " " + this.Naziv;
        }

        public void UcitajIkonicu()
        {
            if (this.Ikonica.Equals(""))
            {
                this.Slicica = BitmapFactory.ConvertToPbgra32Format(new WriteableBitmap(new BitmapImage(new Uri(this.Tip.Ikonica, UriKind.Relative))));
            }
            else
            {
                this.Slicica = BitmapFactory.ConvertToPbgra32Format(new WriteableBitmap(new BitmapImage(new Uri(this.Ikonica, UriKind.Relative))));
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Lokal lokal &&
                   Id == lokal.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }
    }
}
