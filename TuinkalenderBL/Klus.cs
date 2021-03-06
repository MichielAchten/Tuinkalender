﻿using System;
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

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlusId { get; set; }
        [Column("Korte Omschrijving")]
        public string KorteOmschrijving { get; set; }
        [Column("Lange Omschrijving")]
        public string LangeOmschrijving { get; set; }
        [Column("Soort Klus")]
        public SoortKlus SoortKlus { get; set; }
        [Column("Begintijdstip")]
        public int Begintijdstip { get; set; }
        [Column("Duur")]
        public int Duur { get; set; }

        //[Column("Groente")]
        //public virtual ICollection<Groente> Groente { get; set; }
        public virtual Groente Groente { get; set; }
        //public int GroenteId { get; set; }

        //[Column("Groente")]
        //public Groente Groente { get; set; }

    }
}
