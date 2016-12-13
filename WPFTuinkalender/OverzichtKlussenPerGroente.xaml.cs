using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TuinkalenderBL;
using TuinkalenderDA;

namespace WPFTuinkalender
{
    /// <summary>
    /// Interaction logic for OverzichtKlussenPerGroente.xaml
    /// </summary>
    public partial class OverzichtKlussenPerGroente : Window
    {
        public string[] maanden = new string[12]
            {"januari", "februari", "maart", "april", "mei", "juni", "juli", "augustus",
                "september", "oktober", "november", "december"};
        public Moestuin GekozenMoestuin { get; set; }

        public OverzichtKlussenPerGroente(Moestuin gekozenMoestuin)
        {
            GekozenMoestuin = gekozenMoestuin;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            CollectionViewSource groenteViewSource = ((CollectionViewSource)(this.FindResource("groenteViewSource")));
            var manager = new GroenteManager();
            groenteViewSource.Source = manager.GetAlleGroentenUitMoestuin(GekozenMoestuin.Id);

            //GroenteManager manager = new GroenteManager();
            //List<Groente> alleGroenten = manager.GetAlleGroenten();

            //foreach (var groenteUitHeleLijst in alleGroenten)
            //{
            //    foreach (var groenteUitGokozenLijst in StartschermGroenten.GekozenGroenten)
            //    {
            //        if (groenteUitHeleLijst.NederlandseNaam == groenteUitGokozenLijst.NederlandseNaam)
            //        {
            //            listBoxGroentenInTuin.Items.Add(groenteUitHeleLijst);
            //        }
            //    }
            //}
        }

        private void buttonSluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public List<Klus> klussenVanGeselecteerdeGroente = new List<Klus>();
        private void listBoxGroentenInTuin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            klussenVanGeselecteerdeGroente.Clear();
            foreach (var child in stackpanelInfoKlus.Children)
            {
                var stackPanel = (StackPanel)child;
                foreach (var textBlock in stackPanel.Children)
                {
                    var textBlockMetTekst = (TextBlock)textBlock;
                    textBlockMetTekst.Text = "";
                }
            }
            //textBlockZaaienOfPlantenOmschrijving.Text = "";
            //textBlockZaaienOfPlantenTijdstip.Text = "";
            //textBlockVoorzaaienOmschrijving.Text = "";
            //textBlockVoorzaaienTijdstip.Text = "";
            //textBlockUitplantenOmschrijving.Text = "";
            //textBlockUitplantenTijdstip.Text = "";
            //textblock
            var manager = new GroenteManager();
            Groente geselecteerdeGroente = new Groente();
            geselecteerdeGroente = (Groente)listBoxGroentenInTuin.SelectedItem;
            klussenVanGeselecteerdeGroente = manager.GetKlussenVanEenGroente(geselecteerdeGroente.GroenteId);
            foreach (var klus in klussenVanGeselecteerdeGroente)
            {
                string tekstOmschrijving = klus.KorteOmschrijving.ToString() + ": " +
                    klus.LangeOmschrijving.ToString();
                string tekstTijdstip;

                string begintijdstip = maanden[Int32.Parse(klus.Begintijdstip.ToString())];
                string eindtijdstip = maanden[Int32.Parse((klus.Begintijdstip + klus.Duur - 1).ToString())];

                if (klus.Duur > 1)
                {
                    tekstTijdstip = "Van " + begintijdstip + " tot en met " + eindtijdstip;
                }
                else
                {
                    tekstTijdstip = "In " + begintijdstip;
                }

                //moet nog korter
                if (klus.SoortKlus == SoortKlus.ZaaienOfPlanten)
                {
                    textBlockZaaienOfPlantenOmschrijving.Text = tekstOmschrijving;
                    textBlockZaaienOfPlantenTijdstip.Text = tekstTijdstip;
                }
                else if (klus.SoortKlus == SoortKlus.Voorzaaien)
                {
                    textBlockVoorzaaienOmschrijving.Text = tekstOmschrijving;
                    textBlockVoorzaaienTijdstip.Text = tekstTijdstip;
                }
                else if (klus.SoortKlus == SoortKlus.Uitplanten)
                {
                    textBlockUitplantenOmschrijving.Text = tekstOmschrijving;
                    textBlockUitplantenTijdstip.Text = tekstTijdstip;
                }
                else if (klus.SoortKlus == SoortKlus.Oogsten)
                {
                    textBlockOogstenOmschrijving.Text = tekstOmschrijving;
                    textBlockOogstenTijdstip.Text = tekstTijdstip;
                }
                else
                {
                    textBlockAnderOnderhoudOmschrijving.Text = tekstOmschrijving;
                    textBlockAnderOnderhoudTijdstip.Text = tekstTijdstip;
                }

    //ZaaienOfPlanten,
    //Voorzaaien,
    //Uitplanten,
    //Oogsten,
    //AnderOnderhoud



                //listBoxKlussen.Items.Add(klus);
            }
        }
    }
}
