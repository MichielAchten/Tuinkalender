using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    public abstract class Voedingsgewas: Plant
    {
        //public Voedingsgewas(string nederlandseNaam, Klus oogsten, Klus onderhoud): base(nederlandseNaam)
        //{
        //    Oogsten = oogsten;
        //    Onderhoud = onderhoud;
        //}

        //public Voedingsgewas()
        //{

        //}

        public override string NederlandseNaam { get; set; }
        public abstract Klus Oogsten { get; set; }
      //  public abstract List<Klus> Onderhoud { get; set; }

        public abstract void MaakOverzichtKlussen();
    }
}
