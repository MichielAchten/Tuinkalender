using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    [Table("Klus")]
    public class Klus
    {
        //public Klus(string omschrijving, int tijdstip)
        //{
        //    Omschrijving = omschrijving;
        //    Tijdstip = tijdstip;
        //}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlusId { get; set; }
        [Column("Omschrijving")]
        public string Omschrijving { get; set; }
        [Column("Tijdstip")]
        public int Tijdstip { get; set; }

        [Column("Groente")]
        public virtual Groente Groente { get; set; }
//        public int GroenteId { get; set; }

        //[Column("Groente")]
        //public Groente Groente { get; set; }

    }
}
