using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    [Table("Groente")]
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



        public int GroenteId { get; set; }
        [Column("Nederlandse naam")]
        public override string NederlandseNaam { get; set; }

        public virtual ICollection<Klus> Klussen { get; set; }

        public virtual ICollection<Moestuin> Moestuinen { get; set; }



        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int GroenteId { get; set; }
        //[Column("Nederlandse naam")]
        //public override string NederlandseNaam { get; set; }
        //[Column("Voorzaaien")]
        //public Klus Voorzaaien { get; set; }
        //[Column("Planten")]
        //public Klus Planten { get; set; }
        //[Column("Zaaien volle grond")]
        //public Klus ZaaienVolleGrond { get; set; }
        //[Column("Oogsten")]
        //public override Klus Oogsten { get; set; }
     //   [Column("Onderhoud")]
     //   public override List<Klus> Onderhoud { get; set; }
        
        
        
        //public virtual List<Klus> Klussen { get; set; }
        
        
        
        //public bool EenmaligOogsten { get; set; }

        //public List<Klus> Klussen { get; set; }

        public override void MaakOverzichtKlussen()
        {

        }
    }
    
}
