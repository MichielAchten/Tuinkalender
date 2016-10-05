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
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<KalenderContext>());

            using (var context = new KalenderContext())
            {
                List<Groente> lijstGroenten = new List<Groente>();
                
                //aardappel
                var oogstenAardappelen = new Klus { Omschrijving = "Oogsten", Tijdstip = 9 };
                var plantenAardappelen = new Klus { Omschrijving = "Planten", Tijdstip = 4 };
                var aanaardenAardappelen = new Klus { Omschrijving = "Aanaarden", Tijdstip = 5 };
                var aardappel = new Groente
                {
                    NederlandseNaam = "Aardappel",
                    ZaaienVolleGrond = plantenAardappelen,
                    Oogsten = oogstenAardappelen,
                    Onderhoud = new List<Klus> { aanaardenAardappelen }
                };
                lijstGroenten.Add(aardappel);

                //aardpeer
                //...


                context.Groenten.Add(aardappel);
                context.SaveChanges();
                Console.WriteLine("OK");
            }


            //Groente groente1 = new Groente(
            //    "Salade",
            //    new Klus("Oogsten", 7),
            //    new Klus("Ophogen", 7),
            //    EnumZaaiMogelijkheden.OnderGlasEnVolleGrond,
            //    new Klus("Zaaien onder glas", 7),
            //    new Klus("Zaaien volle grond", 7),
            //    true);
            //Groente groente2 = new Groente
            //{
            //    NederlandseNaam = "Aardappel",
            //    Oogsten = new Klus("Oogsten", 7),
            //    Onderhoud = new Klus("Ophogen", 7),
            //    Zaaimogelijkheden = EnumZaaiMogelijkheden.OnderGlasEnVolleGrond,
            //    ZaaienOnderGlas = new Klus("Zaaien onder glas", 7),
            //    ZaaienVolleGrond = new Klus("Zaaien volle grond", 7),
            //    EenmaligOogsten = true
            //};
            //Groente groente3 = new Groente(
            //    "Radijs",
            //    new Klus("Oogsten", 7),
            //    new Klus("Ophogen", 7),
            //    EnumZaaiMogelijkheden.OnderGlasEnVolleGrond,
            //    null,
            //    null,
            //    true);

            //Console.WriteLine(groente1.NederlandseNaam);
            //Console.WriteLine(groente1.Oogsten.Omschrijving);
            //Console.WriteLine(groente1.Oogsten.Tijdstip);
            //Console.WriteLine(groente1.Zaaimogelijkheden);
            //Console.WriteLine(groente1.EenmaligOogsten);
            //if (groente1.ZaaienOnderGlas != null)
            //{
            //    Console.WriteLine(groente1.ZaaienOnderGlas.Omschrijving);
            //    Console.WriteLine(groente1.ZaaienOnderGlas.Tijdstip);
            //}
            //if (groente1.ZaaienVolleGrond != null)
            //{
            //    Console.WriteLine(groente1.ZaaienVolleGrond.Omschrijving);
            //    Console.WriteLine(groente1.ZaaienVolleGrond.Tijdstip);
            //}
            //Console.ReadLine();
        }
    }
}
