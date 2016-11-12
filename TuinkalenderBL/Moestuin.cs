using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    public class Moestuin
    {
        public int MoestuinId { get; set; }
        public string Naam { get; set; }
        public virtual ICollection<Groente> Groenten { get; set; }
    }
}
