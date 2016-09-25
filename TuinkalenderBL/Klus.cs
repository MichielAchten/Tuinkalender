using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    public class Klus
    {
        //public Klus(string omschrijving, int tijdstip)
        //{
        //    Omschrijving = omschrijving;
        //    Tijdstip = tijdstip;
        //}

        public int KlusId { get; set; }
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Omschrijving { get; set; }
        public int Tijdstip { get; set; }

        public Groente Groente { get; set; }

    }
}
