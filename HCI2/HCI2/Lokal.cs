using System;
using System.Collections.Generic;
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
    public class Lokal
    {
        public String Id { get; set; }
        public String Naziv { get; set; }
        public String Tip { get; set; }
        public SluzenjeAlkohola StatusSluzenjaAlkohola { get; set; }
        public String Ikonica { get; set; }
        public bool DostupanHendikepiranim { get; set; }
        public bool DozvoljenoPusenje { get; set; }
        public bool PrimaRezervacije { get; set; }
        public KategorijeCena KategorijaCene { get; set; }
        public int Kapacitet { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public WriteableBitmap Slicica { get; set; }

        public Lokal(String Id, String Naziv, String Tip, SluzenjeAlkohola Status, String Ikonica, bool DostupanHendikepiranim, bool DozvoljenoPusenje, bool PrimaRezervacije, KategorijeCena KategorijaCene, int Kapacitet, DateTime DatumOtvaranja)
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
        }

        public override string ToString()
        {
            return this.Id + " " + this.Naziv;
        }

        public void UcitajIkonicu()
        {
            this.Slicica = BitmapFactory.ConvertToPbgra32Format(new WriteableBitmap(new BitmapImage(new Uri(this.Ikonica, UriKind.Relative))));
        }

    }
}
