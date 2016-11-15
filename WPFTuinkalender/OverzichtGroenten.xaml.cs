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
    /// Interaction logic for OverzichtGroenten.xaml
    /// </summary>
    public partial class OverzichtGroenten : Window
    {
        public List<Groente> AlleGroenten = new List<Groente>();
        public List<Groente> GroentenInMoestuin = new List<Groente>();
        public List<Groente> BeginGroenten = new List<Groente>();

        public Moestuin GekozenMoestuin { get; set; }

        public OverzichtGroenten(Moestuin gekozenMoestuin)
        {
            GekozenMoestuin = gekozenMoestuin;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //CollectionViewSource groenteViewSource = ((CollectionViewSource)(this.FindResource("groenteViewSource")));
            //var manager = new GroenteManager();
            //groenteViewSource.Source = manager.GetAlleGroenten();

            var manager = new GroenteManager();
            AlleGroenten = manager.GetAlleGroenten();
            GroentenInMoestuin = manager.GetAlleGroentenUitMoestuin(GekozenMoestuin.MoestuinId);
            foreach (var begingroente in GroentenInMoestuin)
            {
                BeginGroenten.Add(begingroente);
            }
            LijstMetTeKiezenGroentenVullen();
            LijstMetGekozenGroentenVullen();
            
        }

        private void LijstMetGekozenGroentenVullen()
        {
            listBoxGroentenTuin.Items.Clear();
            foreach (var groente in GroentenInMoestuin)
            {
                listBoxGroentenTuin.Items.Add(groente);
            }
        }

        private void LijstMetTeKiezenGroentenVullen()
        {
            listBoxGroenten.Items.Clear();
            foreach (var groente in AlleGroenten)
            {
                bool tuinBevatGroente = false;
                foreach (var groenteInTuin in GroentenInMoestuin)
                {
                    if (groente.NederlandseNaam == groenteInTuin.NederlandseNaam)
                    {
                        tuinBevatGroente = true;
                    }
                }
                if (!tuinBevatGroente)
                {
                    listBoxGroenten.Items.Add(groente);
                }
            }
        }

        private void buttonToevoegenAanTuin_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxGroenten.SelectedItem != null)
            {
                var aanTuinToeTeVoegenGroente = (Groente)listBoxGroenten.SelectedItem;
                var manager = new GroenteManager();
                GroentenInMoestuin.Add(aanTuinToeTeVoegenGroente);
                LijstMetTeKiezenGroentenVullen();
                LijstMetGekozenGroentenVullen();
            }
        }

        private void buttonVerwijderenUitTuin_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxGroentenTuin.SelectedItem != null)
            {
                var uitTuinTeVerwijderenGroente = (Groente)listBoxGroentenTuin.SelectedItem;
                var manager = new GroenteManager();
                GroentenInMoestuin.Remove(uitTuinTeVerwijderenGroente);
                LijstMetTeKiezenGroentenVullen();
                LijstMetGekozenGroentenVullen();
                //foreach (var teVerwijderenGroente in StartschermGroenten.GekozenGroenten)
                //{
                //    string nederlandseNaam = ((Groente)listBoxGroentenTuin.SelectedItem).NederlandseNaam.ToString();
                //    if (nederlandseNaam == teVerwijderenGroente.NederlandseNaam)
                //    {
                //        StartschermGroenten.GekozenGroenten.Remove(teVerwijderenGroente);
                //        break;
                //    }
                //}
                //listBoxGroentenTuin.Items.Remove(listBoxGroentenTuin.SelectedItem);
                //StartschermGroenten.GekozenGroenten.Remove((Groente)listBoxGroenten.SelectedItem);
            }
        }

        private void buttonKeuzeDoorvoeren_Click(object sender, RoutedEventArgs e)
        {
            var manager = new GroenteManager();
            foreach (var groente in GroentenInMoestuin)
            {
                manager.VoegGroenteToeAanMoestuin(groente.GroenteId, GekozenMoestuin.MoestuinId);
            }
            foreach(var groente in BeginGroenten)
            {
                if (!GroentenInMoestuin.Contains(groente))
                {
                    manager.VerwijderGroenteUitMoestuin(groente.GroenteId, GekozenMoestuin.MoestuinId);
                }
            }
            this.Close();
        }
    }
}
