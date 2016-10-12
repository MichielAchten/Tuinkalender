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
                var onderhoud5_1_I = new Klus
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
                    Klussen = new List<Klus> { planten4_1, oogsten9_1, onderhoud5_1_I }
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
                var onderhoud10_1_I = new Klus
                {
                    KorteOmschrijving = "Voor de vorst",
                    LangeOmschrijving = "Voor de vorst dode bladeren leggen rond de plant.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 10,
                    Duur = 1
                };

                //groente
                var aardpeer = new Groente
                {
                    NederlandseNaam = "Aardpeer",
                    Klussen = new List<Klus> { planten3_2, oogsten11_4, onderhoud10_1_I }
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

                //asperge
                //klussen
                var planten3_1 = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 1
                };
                var oogsten4_3 = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 4,
                    Duur = 3
                };

                //groente
                var asperge = new Groente
                {
                    NederlandseNaam = "Asperge",
                    Klussen = new List<Klus> { planten3_1, oogsten4_3 }
                };

                LijstGroenten.Add(asperge);

                //aubergine
                //klussen
                var voorzaaien2_1 = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 2,
                    Duur = 1
                };
                var uitplanten3_1 = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten ongeveer een maand na het voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 3,
                    Duur = 1
                };
                var oogsten7_5 = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 5
                };

                //groente
                var aubergine = new Groente
                {
                    NederlandseNaam = "Aubergine",
                    Klussen = new List<Klus> { voorzaaien2_1, uitplanten3_1, oogsten7_5 }
                };

                LijstGroenten.Add(aubergine);

                //augurk
                //klussen
                var zaaien5_2 = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogsten7_4 = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 4
                };

                //groente
                var augurk = new Groente
                {
                    NederlandseNaam = "Augurk",
                    Klussen = new List<Klus> { zaaien5_2, oogsten7_4 }
                };

                LijstGroenten.Add(augurk);

                //bleekselder
                //klussen
                var voorzaaien3_3 = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 3
                };
                var uitplanten4_2 = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var onderhoud5_3_I = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen twee maanden na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 5,
                    Duur = 3
                };
                //oogsten7_4

                //groente
                var bleekselder = new Groente
                {
                    NederlandseNaam = "Bleekselder",
                    Klussen = new List<Klus> { voorzaaien3_3, uitplanten4_2, onderhoud5_3_I, oogsten7_4 }
                };

                LijstGroenten.Add(bleekselder);

                //bloemkool
                //klussen
                var voorzaaien3_4 = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 4
                };
                var uitplanten5_4 = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten anderhalve maand na voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 5,
                    Duur = 4
                };
                var onderhoud4_4_I = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen een maand na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 4
                };
                //oogsten7_5

                //groente
                var bloemkool = new Groente
                {
                    NederlandseNaam = "Bloemkool",
                    Klussen = new List<Klus> { voorzaaien3_4, uitplanten5_4, onderhoud4_4_I, oogsten7_5 }
                };

                LijstGroenten.Add(bloemkool);

                //boerenkool
                //klussen
                var voorzaaien4_3 = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 4,
                    Duur = 3
                };
                var uitplanten6_3 = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten anderhalve maand na voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 6,
                    Duur = 3
                };
                var onderhoud4_3_I = new Klus
                {
                    KorteOmschrijving = "Uitdunnen",
                    LangeOmschrijving = "Uitdunnen drie weken na voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 3
                };
                var oogsten10_6 = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 10,
                    Duur = 6
                };

                //groente
                var boerenkool = new Groente
                {
                    NederlandseNaam = "Boerenkool",
                    Klussen = new List<Klus> { voorzaaien4_3, uitplanten6_3, onderhoud4_3_I, oogsten10_6 }
                };

                LijstGroenten.Add(boerenkool);

                //broccoli
                //klussen
                var voorzaaien5_2 = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var uitplanten7_1 = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten wanneer de plantjes 4 tot 6 blaadjes hebben.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 7,
                    Duur = 1
                };
                var onderhoud6_2_I = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen vier weken na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 6,
                    Duur = 2
                };
                var oogsten3_3 = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 3,
                    Duur = 3
                };

                //groente
                var broccoli = new Groente
                {
                    NederlandseNaam = "Broccoli",
                    Klussen = new List<Klus> { voorzaaien5_2, uitplanten7_1, onderhoud6_2_I, oogsten3_3 }
                };

                LijstGroenten.Add(broccoli);






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
