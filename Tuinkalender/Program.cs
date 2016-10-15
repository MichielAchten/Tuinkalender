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
                var plantenAardappel = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 1
                };
                var onderhoudAardappelAanaarden = new Klus
                {
                    KorteOmschrijving = "Aanaarden",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 5,
                    Duur = 1
                };
                var oogstenAardappel = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 9,
                    Duur = 1
                };

                //groente
                var aardappel = new Groente
                {
                    NederlandseNaam = "Aardappel",
                    Klussen = new List<Klus> { plantenAardappel, onderhoudAardappelAanaarden, oogstenAardappel }
                };
                
                LijstGroenten.Add(aardappel);

                //aardpeer
                //klussen
                var plantenAardpeer = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var oogstenAardpeer = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 11,
                    Duur = 4
                };
                var onderhoudAardpeerVoorDeVorst = new Klus
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
                    Klussen = new List<Klus> { plantenAardpeer, oogstenAardpeer, onderhoudAardpeerVoorDeVorst }
                };

                LijstGroenten.Add(aardpeer);

                //artisjok
                //klussen
                var plantenArtisjok = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var oogstenArtisjok = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 3
                };

                //groente
                var artisjok = new Groente
                {
                    NederlandseNaam = "Artisjok",
                    Klussen = new List<Klus> { plantenArtisjok, oogstenArtisjok }
                };

                LijstGroenten.Add(artisjok);

                //asperge
                //klussen
                var plantenAsperge = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 1
                };
                var oogstenAsperge = new Klus
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
                    Klussen = new List<Klus> { plantenAsperge, oogstenAsperge }
                };

                LijstGroenten.Add(asperge);

                //aubergine
                //klussen
                var voorzaaienAubergine = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 2,
                    Duur = 1
                };
                var uitplantenAubergine = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten ongeveer een maand na het voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 3,
                    Duur = 1
                };
                var oogstenAubergine = new Klus
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
                    Klussen = new List<Klus> { voorzaaienAubergine, uitplantenAubergine, oogstenAubergine }
                };

                LijstGroenten.Add(aubergine);

                //augurk
                //klussen
                var zaaienAugurk = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogstenAugurk = new Klus
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
                    Klussen = new List<Klus> { zaaienAugurk, oogstenAugurk }
                };

                LijstGroenten.Add(augurk);

                //bleekselder
                //klussen
                var voorzaaien3_3_Bleekselder = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 3
                };
                var uitplantenBleekselder = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var onderhoudBleekselderVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen twee maanden na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 5,
                    Duur = 3
                };
                var oogstenBleekselder = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 5
                };

                //groente
                var bleekselder = new Groente
                {
                    NederlandseNaam = "Bleekselder",
                    Klussen = new List<Klus> { voorzaaien3_3_Bleekselder, uitplantenBleekselder,
                        onderhoudBleekselderVerspenen, oogstenBleekselder }
                };

                LijstGroenten.Add(bleekselder);

                //bloemkool
                //klussen
                var voorzaaienBloemkool = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 4
                };
                var uitplantenBloemkool = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten anderhalve maand na voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 5,
                    Duur = 4
                };
                var onderhoudBloemkoolVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen een maand na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 4
                };
                var oogstenBloemkool = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 5
                };

                //groente
                var bloemkool = new Groente
                {
                    NederlandseNaam = "Bloemkool",
                    Klussen = new List<Klus> { voorzaaienBloemkool, uitplantenBloemkool,
                        onderhoudBloemkoolVerspenen, oogstenBloemkool }
                };

                LijstGroenten.Add(bloemkool);

                //boerenkool
                //klussen
                var voorzaaienBoerenkool = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 4,
                    Duur = 3
                };
                var uitplantenBoerenkool = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten anderhalve maand na voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 6,
                    Duur = 3
                };
                var onderhoudBoerenkoolUitdunnen = new Klus
                {
                    KorteOmschrijving = "Uitdunnen",
                    LangeOmschrijving = "Uitdunnen drie weken na voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 3
                };
                var oogstenBoerenkool = new Klus
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
                    Klussen = new List<Klus> { voorzaaienBoerenkool, uitplantenBoerenkool,
                        onderhoudBoerenkoolUitdunnen, oogstenBoerenkool }
                };

                LijstGroenten.Add(boerenkool);

                //broccoli
                //klussen
                var voorzaaienBroccoli = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var uitplantenBroccoli = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten wanneer de plantjes 4 tot 6 blaadjes hebben.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 7,
                    Duur = 1
                };
                var onderhoudBroccoliVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen vier weken na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 6,
                    Duur = 2
                };
                var oogstenBroccoli = new Klus
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
                    Klussen = new List<Klus> { voorzaaienBroccoli, uitplantenBroccoli,
                        onderhoudBroccoliVerspenen, oogstenBroccoli }
                };

                LijstGroenten.Add(broccoli);

                //courgette
                //klussen
                var voorzaaienCourgette = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in potjes onder glas. Meerdere zaadjes per pot.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var uitplantenCourgette = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten 3 tot 4 weken na het voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var onderhoudCourgetteUitdunnen = new Klus
                {
                    KorteOmschrijving = "Uitdunnen",
                    LangeOmschrijving = "Uitdunnen 2 weken na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var oogstenCourgette = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 3
                };

                //groente
                var courgette = new Groente
                {
                    NederlandseNaam = "Courgette",
                    Klussen = { voorzaaienCourgette, uitplantenCourgette,
                        onderhoudCourgetteUitdunnen, oogstenCourgette }
                };

                LijstGroenten.Add(courgette);

                //doperwt
                //klussen
                var zaaienDoperwt = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 2,
                    Duur = 5
                };
                var onderhoudDoperwtOphogen = new Klus
                {
                    KorteOmschrijving = "Ophogen",
                    LangeOmschrijving = "Ophogen andehalve maand na het zaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 3,
                    Duur = 5
                };
                var oogstenDoperwt = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 6,
                    Duur = 5
                };

                //groente
                var doperwt = new Groente
                {
                    NederlandseNaam = "Doperwt",
                    Klussen = { zaaienDoperwt, onderhoudDoperwtOphogen, oogstenDoperwt }
                };

                LijstGroenten.Add(doperwt);

                //knoflook
                //klussen
                var plantenKnoflook = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 10,
                    Duur = 2
                };
                var oogstenKnoflook = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 6,
                    Duur = 1
                };

                //groente
                var knoflook = new Groente
                {
                    NederlandseNaam = "Knoflook",
                    Klussen = { plantenKnoflook, oogstenKnoflook }
                };

                LijstGroenten.Add(knoflook);

                //knolselder
                //klussen
                var voorzaaienKnolselder = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in zaai- of kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 3
                };
                var uitplantenKnolselder = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var onderhoudKnolselderVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen anderhalve maand na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 3
                };
                var oogstenKnolselder = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 8,
                    Duur = 3
                };

                //groente
                var knolselder = new Groente
                {
                    NederlandseNaam = "Knolselder",
                    Klussen = { voorzaaienKnolselder, uitplantenKnolselder,
                        onderhoudKnolselderVerspenen, oogstenKnolselder }
                };

                LijstGroenten.Add(knolselder);







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
