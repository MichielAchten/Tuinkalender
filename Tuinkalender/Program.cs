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

            //DatabaseAanmaken();

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
                var voorzaaienBleekselder = new Klus
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
                    Duur = 4
                };

                //groente
                var bleekselder = new Groente
                {
                    NederlandseNaam = "Bleekselder",
                    Klussen = new List<Klus> { voorzaaienBleekselder, uitplantenBleekselder,
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
                    Klussen = new List<Klus> { voorzaaienCourgette, uitplantenCourgette,
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
                    Klussen = new List<Klus> { zaaienDoperwt, onderhoudDoperwtOphogen, oogstenDoperwt }
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
                    Klussen = new List<Klus> { plantenKnoflook, oogstenKnoflook }
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
                    Klussen = new List<Klus> { voorzaaienKnolselder, uitplantenKnolselder,
                        onderhoudKnolselderVerspenen, oogstenKnolselder }
                };

                LijstGroenten.Add(knolselder);
                
                //knolvenkel
                //klussen
                var voorzaaienKnolvenkel = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var uitplantenKnolVenkel = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten, 6 tot 7 weken na het voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var zaaienKnolvenkel = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 5
                };
                var oogstenKnolvenkel = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 6,
                    Duur = 5
                };

                //groente
                var knolvenkel = new Groente
                {
                    NederlandseNaam = "Knolvenkel",
                    Klussen = new List<Klus> { voorzaaienKnolvenkel, uitplantenKnolVenkel, zaaienKnolvenkel, oogstenKnolvenkel }
                };

                LijstGroenten.Add(knolvenkel);

                //komkommer
                //klussen
                var zaaienKomkommer = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 3
                };
                var oogstenKomkommer = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 4
                };
                
                //groente
                var komkommer = new Groente
                {
                    NederlandseNaam = "Komkommer",
                    Klussen = new List<Klus> { zaaienKomkommer, oogstenKomkommer }
                };

                LijstGroenten.Add(komkommer);

                //koolrabi
                //klussen
                var zaaienKoolrabi = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 4
                };
                var oogstenKoolrabi = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 6,
                    Duur = 4
                };

                //groente
                var koolrabi = new Groente
                {
                    NederlandseNaam = "Koolrabi",
                    Klussen = new List<Klus> { zaaienKoolrabi, oogstenKoolrabi }
                };

                LijstGroenten.Add(koolrabi);

                //pastinaak
                //klussen
                var zaaienPastinaak = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 4
                };
                var oogstenPastinaak = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 4
                };

                //groente
                var pastinaak = new Groente
                {
                    NederlandseNaam = "Pastinaak",
                    Klussen = new List<Klus> { zaaienPastinaak, oogstenPastinaak }
                };

                LijstGroenten.Add(pastinaak);

                //paprika en peper
                //klussen
                var voorzaaienPaprika = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in zaaibak.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 1
                };
                var uitplantenPaprika = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 6,
                    Duur = 1
                };
                var oogstenPaprika = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 4
                };
                var onderhoudPaprikaVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen, anderhalve maand na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 1
                };
                
                //groenten
                var paprika = new Groente
                {
                    NederlandseNaam = "Paprika",
                    Klussen = new List<Klus> { voorzaaienPaprika, uitplantenPaprika, oogstenPaprika, onderhoudPaprikaVerspenen }
                };
                
                LijstGroenten.Add(paprika);

                //Peper
                //klussen
                var voorzaaienPeper = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in zaaibak.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 1
                };
                var uitplantenPeper = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 6,
                    Duur = 1
                };
                var oogstenPeper = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 4
                };
                var onderhoudPeperVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen, anderhalve maand na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 1
                };

                //groente
                var peper = new Groente
                {
                    NederlandseNaam = "Peper",
                    Klussen = new List<Klus> { voorzaaienPeper, uitplantenPeper, oogstenPeper, onderhoudPeperVerspenen }
                };

                LijstGroenten.Add(peper);

                //pompoen
                //klussen
                var zaaienPompoen = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var oogstenPompoen = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 9,
                    Duur = 2
                };

                //groente
                var pompoen = new Groente
                {
                    NederlandseNaam = "Pompoen",
                    Klussen = new List<Klus> { zaaienPompoen, oogstenPompoen }
                };

                LijstGroenten.Add(pompoen);

                //prei
                //klussen
                var voorzaaienPreiWarmBed = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien op warm bed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 1,
                    Duur = 2
                };
                var voorzaaienPreiPlatglasbak = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in platglasbak.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 9,
                    Duur = 1
                };
                var voorzaaienPreiKweekbed = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 2,
                    Duur = 6
                };
                var uitplantenPrei = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 4,
                    Duur = 7
                };
                var zaaienPrei = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 8,
                    Duur = 1
                };
                var oogstenPrei = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "Oogsten, tussen 5 en 8 maanden na het zaaien.",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 1,
                    Duur = 12
                };

                //groente
                var prei = new Groente
                {
                    NederlandseNaam = "Prei",
                    Klussen = new List<Klus> { voorzaaienPreiWarmBed, voorzaaienPreiPlatglasbak, voorzaaienPreiKweekbed, uitplantenPrei, 
                        zaaienPrei, oogstenPrei }
                };

                LijstGroenten.Add(prei);

                //raap
                //klussen
                var zaaienRaapMaartApril = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var zaaienRaapAugustus = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 8,
                    Duur = 1
                };
                var oogstenRaapMeiJuni = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogstenRaapOktober = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 10,
                    Duur = 1
                };

                //groente
                var raap = new Groente
                {
                    NederlandseNaam = "Raap",
                    Klussen = new List<Klus> { zaaienRaapMaartApril, zaaienRaapAugustus, oogstenRaapMeiJuni, oogstenRaapOktober }
                };

                LijstGroenten.Add(raap);

                //Rabarber
                //klussen
                var plantenRabarberMaartApril = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "Ter plaatse planten.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var plantenRabarberSeptemberOktober = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "Ter plaatse planten.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 9,
                    Duur = 2
                };
                var oogstenRabarberMeiJuni = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogstenRabarberSeptemberOktober = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 9,
                    Duur = 2
                };

                //groente
                var rabarber = new Groente
                {
                    NederlandseNaam = "Rabarber",
                    Klussen = new List<Klus> { plantenRabarberMaartApril, plantenRabarberSeptemberOktober, oogstenRabarberMeiJuni, oogstenRabarberSeptemberOktober }
                };

                LijstGroenten.Add(rabarber);

                //radijs
                //klussen
                var zaaienRadijs = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "In rijen of breedwerpig zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 7
                };
                var oogstenRadijs = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 4,
                    Duur = 7
                };

                //groente
                var radijs = new Groente
                {
                    NederlandseNaam = "Radijs",
                    Klussen = new List<Klus> { zaaienRadijs, oogstenRadijs }
                };

                LijstGroenten.Add(radijs);

                //raketsla
                //klussen
                var zaaienRaketslaAprilAugustus = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 5
                };
                var zaaienRaketslaSeptemberOktober = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 9,
                    Duur = 2
                };
                var oogstenRaketslaJuniNovember = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 6,
                    Duur = 6,
                };
                var oogstenRaketslaMaartApril = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 3,
                    Duur = 2
                };

                //groente
                var raketsla = new Groente
                {
                    NederlandseNaam = "Raketsla",
                    Klussen = new List<Klus> { zaaienRaketslaAprilAugustus, zaaienRaketslaSeptemberOktober, oogstenRaketslaMaartApril, oogstenRaketslaJuniNovember }
                };

                LijstGroenten.Add(raketsla);

                //rode biet
                //klussen
                var zaaienRodeBiet = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 3
                };
                var oogstenRodeBiet = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 5
                };

                //groente
                var rodeBiet = new Groente
                {
                    NederlandseNaam = "Rode biet",
                    Klussen = new List<Klus> { zaaienRodeBiet, oogstenRodeBiet }
                };

                LijstGroenten.Add(rodeBiet);

                //Schorseneer
                //klussen
                var zaaienSchorseneer = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var oogstenSchorseneer = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 10,
                    Duur = 6
                };

                //groente
                var schorseneer = new Groente
                {
                    NederlandseNaam = "Schorseneer",
                    Klussen = new List<Klus> { zaaienSchorseneer, oogstenSchorseneer }
                };

                LijstGroenten.Add(schorseneer);

                //sjalot
                //klussen
                var plantenSjalot = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "Ter plaatse planten.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 2,
                    Duur = 2
                };
                var plantenSjalotZandgrond = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "Op zandgrond kunnen sjalotten ook in november geplant worden.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 11,
                    Duur = 1
                };
                var oogstenSjalot = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 6,
                    Duur = 2
                };

                //groente
                var sjalot = new Groente
                {
                    NederlandseNaam = "Sjalot",
                    Klussen = new List<Klus> { plantenSjalot, plantenSjalotZandgrond, oogstenSjalot }
                };

                LijstGroenten.Add(sjalot);

                //sla
                //klussen
                var zaaienSlaJanuariSeptember = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Zaaien in een bak.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 1,
                    Duur = 9
                };
                var zaaienSlaAprilSeptember = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Zaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 4,
                    Duur = 6
                };
                var uitplantenSla = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen, 3 tot 4 weken na het zaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 1,
                    Duur = 10
                };
                var oogstenSla = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 3,
                    Duur = 8
                };

                //groente
                var sla = new Groente
                {
                    NederlandseNaam = "Sla",
                    Klussen = new List<Klus> { zaaienSlaJanuariSeptember, zaaienSlaAprilSeptember, uitplantenSla, oogstenSla }
                };

                LijstGroenten.Add(sla);

                //sluitkool
                //klussen
                var voorzaaienSluitkoolKweekbedMaartJuni = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 4
                };
                var voorzaaienSluitkoolKweekbedAugustusSeptember = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 8,
                    Duur = 2
                };
                var voorzaaienSluitkoolPlatglasbak = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in platglasbak.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 2,
                    Duur = 2
                };
                var uitplantenSluitkoolAprilAugustus = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten, ongeveer een maand na het verspenen en twee maanden na het voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 4,
                    Duur = 5
                };
                var uitplantenSluitkoolOktoberNovember = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "Uitplanten, ongeveer een maand na het verspenen en twee maanden na het voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 10,
                    Duur = 2
                };
                var oogstenSluitkool = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "Oogsten in ieder seizoen, 4 tot 6 maanden na het voorzaaien.",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 1,
                    Duur = 12
                };
                var onderhoudSluitkoolVerspenenMaartJuli = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen, ongeveer een maand na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 3,
                    Duur = 5
                };
                var onderhoudSluitkoolVerspenenSeptemberOktober = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen, ongeveer een maand na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 9,
                    Duur = 2
                };

                //groente
                var sluitkool = new Groente
                {
                    NederlandseNaam = "Sluitkool",
                    Klussen = new List<Klus>{ voorzaaienSluitkoolKweekbedMaartJuni, voorzaaienSluitkoolKweekbedAugustusSeptember, 
                        voorzaaienSluitkoolPlatglasbak, uitplantenSluitkoolAprilAugustus, uitplantenSluitkoolOktoberNovember,
                        oogstenSluitkool, onderhoudSluitkoolVerspenenMaartJuli, onderhoudSluitkoolVerspenenSeptemberOktober }
                };

                LijstGroenten.Add(sluitkool);

                //snijbiet
                //klussen
                var voorzaaienSnijbiet = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var uitplantenSnijbiet = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen waneer de planten 4 of 5 blaadjes hebben.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var zaaienSnijbiet = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var oogstenSnijbietJuliNovember = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 5
                };
                var oogstenSnijbietAprilMei = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 4,
                    Duur = 2
                };

                //groente
                var snijbiet = new Groente
                {
                    NederlandseNaam = "Snijbiet",
                    Klussen = new List<Klus> { voorzaaienSnijbiet, uitplantenSnijbiet, zaaienSnijbiet, oogstenSnijbietJuliNovember, oogstenSnijbietAprilMei }
                };

                LijstGroenten.Add(snijbiet);

                //sperzieboon
                //klussen
                var zaaienSperzieboon = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Sperziebonen ter plaatse zaaien van april tot en met augustus; dopbonen ter plaatse zaaien van april tot en met juni.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 4,
                    Duur = 5
                };
                var oogstenSperzieboon = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 4
                };

                //groente
                var sperzieboon = new Groente
                {
                    NederlandseNaam = "Sperzieboon",
                    Klussen = new List<Klus> { zaaienSperzieboon, oogstenSperzieboon }
                };

                LijstGroenten.Add(sperzieboon);

                //spinazie
                //klussen
                var zaaienSpinazieMaartApril = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var zaaienSpinazieAugustusSeptember = new Klus{
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 8,
                    Duur = 2
                };
                var oogstenSpinazieMeiJuni = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogstenSpinazieNovemberMaart = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 11,
                    Duur = 5
                };

                //groente
                var spinazie = new Groente
                {
                    NederlandseNaam = "Spinazie",
                    Klussen = new List<Klus> { zaaienSpinazieMaartApril, zaaienSpinazieAugustusSeptember, oogstenSpinazieMeiJuni, oogstenSpinazieNovemberMaart }
                };

                LijstGroenten.Add(spinazie);

                //spruitjes
                //klussen
                var voorzaaienSpruitjes = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in kweekbed.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var uitplantenSpruitjes = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "uitplanten, anderhalve maand na het voorzaaien.",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogstenSpruitjes = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 10,
                    Duur = 7
                };
                var onderhoudSpruitjesVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen, 3 weken na het voorzaaien;",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 2
                };

                //groente
                var spruitjes = new Groente
                {
                    NederlandseNaam = "Spruitjes",
                    Klussen = new List<Klus> { voorzaaienSpruitjes, uitplantenSpruitjes, oogstenSpruitjes, onderhoudSpruitjesVerspenen }
                };

                LijstGroenten.Add(spruitjes);

                //suikermais
                //klussen
                var zaaienSuikermais = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogstenSuikermais = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 8,
                    Duur = 2
                };

                //groente
                var suikermais = new Groente
                {
                    NederlandseNaam = "Suikermaïs",
                    Klussen = new List<Klus> { zaaienSuikermais, oogstenSuikermais }
                };

                LijstGroenten.Add(suikermais);

                //tomaat
                //klussen
                var voorzaaienTomaatZaaibak = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in zaaibak.",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var voorzaaienTomaatPlatglasbak = new Klus
                {
                    KorteOmschrijving = "Voorzaaien",
                    LangeOmschrijving = "Voorzaaien in platglasbak",
                    SoortKlus = SoortKlus.Voorzaaien,
                    Begintijdstip = 4,
                    Duur = 1
                };
                var uitplantenTomaat = new Klus
                {
                    KorteOmschrijving = "Uitplanten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Uitplanten,
                    Begintijdstip = 4,
                    Duur = 2
                };
                var oogstenTomaat = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "Afhankelijk van de variëteit oogsten tot aan de eerste vorst.",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 2
                };
                var onderhoudTomaatVerspenen = new Klus
                {
                    KorteOmschrijving = "Verspenen",
                    LangeOmschrijving = "Verspenen, 3 of 4 weken na het voorzaaien.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 4,
                    Duur = 2
                };

                //groente
                var tomaat = new Groente
                {
                    NederlandseNaam = "Tomaat",
                    Klussen = new List<Klus> { voorzaaienTomaatZaaibak, voorzaaienTomaatPlatglasbak, uitplantenTomaat, oogstenTomaat, onderhoudTomaatVerspenen }
                };

                LijstGroenten.Add(tomaat);

                //tuinboon
                //klussen
                var zaaienTuinboonFebruariMaart = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 2,
                    Duur = 2
                };
                var zaaienTuinboonJuliAugustus = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 7,
                    Duur = 2
                };
                var oogstenTuinboonJuni = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 6,
                    Duur = 1
                };
                var oogstenTuinboonSeptemberOktober = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 9,
                    Duur = 2
                };

                //groente
                var tuinboon = new Groente
                {
                    NederlandseNaam = "Tuinboon",
                    Klussen = new List<Klus> { zaaienTuinboonFebruariMaart, zaaienTuinboonJuliAugustus, oogstenTuinboonJuni, oogstenTuinboonSeptemberOktober }
                };

                LijstGroenten.Add(tuinboon);

                //ui
                //klussen
                var plantenUi = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "Ter plaatse planten.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 2
                };
                var plantenWitteUi = new Klus
                {
                    KorteOmschrijving = "Planten",
                    LangeOmschrijving = "Witte ui kan ter plaatse geplant worden van augustus tot en met september.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 8,
                    Duur = 2
                };
                var oogstenUi = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 2
                };
                var oogstenWitteUi = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "Witte ui kan geoogst worden van april tot en met juni.",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 4,
                    Duur = 3
                };

                //groente
                var ui = new Groente
                {
                    NederlandseNaam = "Ui",
                    Klussen = new List<Klus> { plantenUi, plantenWitteUi, oogstenUi, oogstenWitteUi }
                };

                LijstGroenten.Add(ui);

                //veldsla
                //klussen
                var zaaienVeldsla = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "In rijen of breedwerpig zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 7,
                    Duur = 3
                };
                var oogstenVeldsla = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 9,
                    Duur = 7
                };

                //groente
                var veldsla = new Groente
                {
                    NederlandseNaam = "Veldsla",
                    Klussen = new List<Klus> { zaaienVeldsla, oogstenVeldsla }
                };

                LijstGroenten.Add(veldsla);

                //witloof
                //klussen
                var zaaienWitloof = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "Ter plaatse zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 5,
                    Duur = 2
                };
                var oogstenWitloof = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "Oogsten, 6 weken na begin forceren.",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 11,
                    Duur = 3
                };
                var onderhoudWitloofForceren = new Klus
                {
                    KorteOmschrijving = "Forceren",
                    LangeOmschrijving = "Planten uit de grond halen om te forceren in tuin of kelder.",
                    SoortKlus = SoortKlus.AnderOnderhoud,
                    Begintijdstip = 10,
                    Duur = 3
                };

                //groente
                var witloof = new Groente
                {
                    NederlandseNaam = "Witloof",
                    Klussen = new List<Klus> { zaaienWitloof, oogstenWitloof, onderhoudWitloofForceren }
                };

                LijstGroenten.Add(witloof);

                //wortel
                //klussen
                var zaaienWortel = new Klus
                {
                    KorteOmschrijving = "Zaaien",
                    LangeOmschrijving = "In rijen of breedwerpig zaaien.",
                    SoortKlus = SoortKlus.ZaaienOfPlanten,
                    Begintijdstip = 3,
                    Duur = 5
                };
                var oogstenWortel = new Klus
                {
                    KorteOmschrijving = "Oogsten",
                    LangeOmschrijving = "aanvullen",
                    SoortKlus = SoortKlus.Oogsten,
                    Begintijdstip = 7,
                    Duur = 5
                };

                //groente
                var wortel = new Groente
                {
                    NederlandseNaam = "Wortel",
                    Klussen = new List<Klus> { zaaienWortel, oogstenWortel }
                };

                LijstGroenten.Add(wortel);

                //toevoegen aan database
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
