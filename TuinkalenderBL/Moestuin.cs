﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    [Table("Moestuin")]
    public class Moestuin: Tuin
    {
        //public int MoestuinId { get; set; }
        //public string Naam { get; set; }
        public virtual ICollection<Groente> Groenten { get; set; }
    }
}
