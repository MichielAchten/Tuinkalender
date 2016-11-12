using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuinkalenderBL;

namespace TuinkalenderDA
{
    public class GroenteManager
    {
        public List<Groente> GetAlleGroenten()
        {
            List<Groente> groenten = new List<Groente>();
            using (var context = new KalenderContext())
            {
                foreach (var groente in context.Groenten)
                {
                    groenten.Add(groente);
                }
            }
            return groenten;
        }

        public List<Klus> GetKlussenVanEenGroente(int id)
        {
            var groente = new Groente();
            var klussen = new List<Klus>();
            using (var context = new KalenderContext())
            {
                groente = context.Groenten.Find(id);
                foreach (var klus in groente.Klussen)
                {
                    klussen.Add(klus);
                }
            }
            return klussen;
            //List<Klus> klussen = new List<Klus>();
            //using (var context = new KalenderContext())
            //{
            //    foreach (var klus in groente.Klussen)
            //    {
            //        klussen.Add(klus);
            //    }
            //}
            //return klussen;
        }

        public void MaakNieuweMoestuin(string naam)
        {
            using (var context = new KalenderContext())
            {
                var nieuweMoestuin = new Moestuin();
                nieuweMoestuin.Naam = naam;

                context.Moestuinen.Add(nieuweMoestuin);
                context.SaveChanges();
            }
        }
    }
}
