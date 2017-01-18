using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var klussenLijst = new List<Klus>();
            using (var context = new KalenderContext())
            {
                groente = context.Groenten.Find(id);
                klussenLijst = (from klus in groente.Klussen
                                orderby klus.Begintijdstip
                                select klus).ToList();
                //foreach (var klus in groente.Klussen)
                //{
                //    klussenLijst.Add(klus);
                //}
            }
            return klussenLijst;
        }

        public void MaakNieuweMoestuin(Moestuin moestuin)
        {
            using (var context = new KalenderContext())
            {
                context.Moestuinen.Add(moestuin);
                context.SaveChanges();
            }
        }

        public ObservableCollection<Moestuin> GetAlleMoestuinen()
        {
            ObservableCollection<Moestuin> moestuinen = new ObservableCollection<Moestuin>();
            using (var context = new KalenderContext())
            {
                foreach (var moestuin in context.Moestuinen)
                {
                    moestuinen.Add(moestuin);
                }
            }
            return moestuinen;
        }

        public void VerwijderMoestuin(int id)
        {
            using (var context = new KalenderContext())
            {
                var moestuin = context.Moestuinen.Find(id);
                if (moestuin != null)
                {
                    context.Moestuinen.Remove(moestuin);
                    context.SaveChanges();
                }
            }
        }

        public void VoegGroenteToeAanMoestuin(int groenteId, int moestuinId)
        {
            using (var context = new KalenderContext())
            {
                var moestuin = context.Moestuinen.Find(moestuinId);
                if (moestuin != null)
                {
                    var groente = context.Groenten.Find(groenteId);
                    if (groente != null)
                    {
                        moestuin.Groenten.Add(groente);
                    }
                }
                context.SaveChanges();
            }
        }

        public void VerwijderGroenteUitMoestuin(int groenteId, int moestuinId)
        {
            using (var context = new KalenderContext())
            {
                var moestuin = context.Moestuinen.Find(moestuinId);
                if (moestuin != null)
                {
                    var groente = context.Groenten.Find(groenteId);
                    if (groente != null)
                    {
                        moestuin.Groenten.Remove(groente);
                    }
                }
                context.SaveChanges();
            }
        }

        public void VerwijderAlleGroentenUitMoestuin(int moestuinId)
        {
            using (var context = new KalenderContext())
            {
                var moestuin = context.Moestuinen.Find(moestuinId);
                moestuin.Groenten.Clear();
                context.SaveChanges();
            }
        }

        public ObservableCollection<Groente> GetAlleGroentenUitMoestuin(int id)
        {
            var groentenUitMoestuin = new ObservableCollection<Groente>();
            using (var context = new KalenderContext())
            {
                var moestuin = context.Moestuinen.Find(id);
                if (moestuin != null)
                {
                    foreach (var groente in moestuin.Groenten)
                    {
                        groentenUitMoestuin.Add(groente);
                    }
                }
            }
            return groentenUitMoestuin;
        }

        public Moestuin GetMoestuinVolgensNaam(string naam)
        {
            using (var context = new KalenderContext())
            {
                Moestuin moestuin = null;
                foreach (var eenMoestuin in context.Moestuinen)
                {
                    if (eenMoestuin.NaamTuin == naam)
                    {
                        moestuin = eenMoestuin;
                        break;
                    }
                }
                return moestuin;
            }
        }

    }
}
