using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    public class Groente: Voedingsgewas
    {
        //public Groente(string nederlandseNaam, Klus oogsten, Klus onderhoud, EnumZaaiMogelijkheden zaaimogelijkheden,
        //    Klus zaaienOnderGlas, Klus zaaienVolleGrond, bool eenmaligOogsten) : base(nederlandseNaam, oogsten, onderhoud)
        //{
        //    Zaaimogelijkheden = zaaimogelijkheden;
        //    if (zaaienOnderGlas == null)
        //    {
        //        ZaaienOnderGlas = new Klus("", 0);
        //    }
        //    else
        //    {
        //        ZaaienOnderGlas = zaaienOnderGlas;
        //    }
        //    if (zaaienVolleGrond == null)
        //    {
        //        ZaaienVolleGrond = new Klus("", 0);
        //    }
        //    else
        //    {
        //        ZaaienVolleGrond = zaaienVolleGrond;
        //    }
        //    EenmaligOogsten = eenmaligOogsten;
        //}

        //public Groente()
        //{

        //}

        public override string NederlandseNaam { get; set; }


        //public EnumZaaiMogelijkheden Zaaimogelijkheden { get; set; }

        public int GroenteId { get; set; }
        public Klus Voorzaaien { get; set; }
        public Klus Planten { get; set; }
        public Klus ZaaienVolleGrond { get; set; }
        public override Klus Oogsten { get; set; }
        public override List<Klus> Onderhoud { get; set; }

        //public bool EenmaligOogsten { get; set; }

        public List<Klus> Klussen { get; set; }

        public override void MaakOverzichtKlussen()
        {

        }
    }
    
}
