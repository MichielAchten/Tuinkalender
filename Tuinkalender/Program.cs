using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuinkalenderBL;
using TuinkalenderDA;

namespace TuinkalenderConsole
{
    class Program
    {
        private static List<Groente> LijstGroenten = new List<Groente>();
        //private static List<Klus> LijstKlussen = new List<Klus>();

        static void Main(string[] args)
        {

            DatabaseAanmaken();

        }

        private static void DatabaseAanmaken()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<KalenderContext>());

            using (var context = new KalenderContext())
            {
                //aardappel
                //klussen
                var planten4_1 = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 1
                };
                var oogsten9_1 = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 9,
                    Duur = 1
                };
                var onderhoud5_1 = new Klus
                {
                    KorteOmschrijving = "Aanaarden",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 5,
                    Duur = 1
                };

                //groente
                var aardappel = new Groente
                {
                    NederlandseNaam = "Aardappel",
                    Klussen = new List<Klus> { planten4_1, oogsten9_1, onderhoud5_1 }
                };
                
                LijstGroenten.Add(aardappel);

                //aardpeer
                //klussen
                var planten3_2 = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var oogsten11_4 = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 11,
                    Duur = 4
                };
                var onderhoud10_1 = new Klus
                {
                    KorteOmschrijving = "Voor de vorst",
                    LangeOmschrijving = "dode bladeren leggen rond plant",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 10,
                    Duur = 1
                };

                //groente
                var aardpeer = new Groente
                {
                    NederlandseNaam = "Aardpeer",
                    Klussen = new List<Klus> { planten3_2, oogsten11_4, onderhoud10_1 }
                };

                LijstGroenten.Add(aardpeer);

                //artisjok
                //klussen
                //planten3_2
                var oogsten7_3 = new Klus
                {
                    KorteOmschrijving = "oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 3
                };

                //groente
                var artisjok = new Groente
                {
                    NederlandseNaam = "Artisjok",
                    Klussen = new List<Klus> { planten3_2, oogsten7_3 }
                };

                LijstGroenten.Add(artisjok);








                foreach (Groente groente in LijstGroenten)
                {
                    context.Groenten.Add(groente);
                }
                context.SaveChanges();
                Console.WriteLine("OK");
            }
        }
    }
}
