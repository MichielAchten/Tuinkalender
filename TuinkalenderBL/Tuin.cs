using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    public class Tuin
    {
        public int Id { get; set; }
        public string NaamTuin { get; set; }
        public string Eigenaar { get; set; }
        public string Adres { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }

    }
}
