using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinkalenderBL
{
    public abstract class Plant
    {
        public Plant( string nederlandseNaam)
        {
            NederlandseNaam = nederlandseNaam;
        }

        public Plant()
        {

        }

        public abstract string NederlandseNaam { get; set; }

    }
}
