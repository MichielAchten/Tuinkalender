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
        public OverzichtGroenten()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //CollectionViewSource groenteViewSource = ((CollectionViewSource)(this.FindResource("groenteViewSource")));
            //var manager = new GroenteManager();
            //groenteViewSource.Source = manager.GetAlleGroenten();
            LijstMetGroentenVullen();


            foreach (var groente in StartschermGroenten.GekozenGroenten)
            {
                listBoxGroentenTuin.Items.Add(groente);
            }
            
        }

        private void LijstMetGroentenVullen()
        {
            listBoxGroenten.Items.Clear();
            var manager = new GroenteManager();
            var alleGroenten = manager.GetAlleGroenten();
            foreach (var groente in alleGroenten)
            {
                bool tuinBevatGroente = false;
                foreach (var groenteInTuin in StartschermGroenten.GekozenGroenten)
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
                listBoxGroentenTuin.Items.Add(listBoxGroenten.SelectedItem);
                StartschermGroenten.GekozenGroenten.Add((Groente)listBoxGroenten.SelectedItem);
                LijstMetGroentenVullen();
            }
        }

        private void buttonVerwijderenUitTuin_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxGroentenTuin.SelectedItem != null)
            {
                foreach (var teVerwijderenGroente in StartschermGroenten.GekozenGroenten)
                {
                    string nederlandseNaam = ((Groente)listBoxGroentenTuin.SelectedItem).NederlandseNaam.ToString();
                    if (nederlandseNaam == teVerwijderenGroente.NederlandseNaam)
                    {
                        StartschermGroenten.GekozenGroenten.Remove(teVerwijderenGroente);
                        break;
                    }
                }
                listBoxGroentenTuin.Items.Remove(listBoxGroentenTuin.SelectedItem);
                //StartschermGroenten.GekozenGroenten.Remove((Groente)listBoxGroenten.SelectedItem);
                LijstMetGroentenVullen();
            }
        }

        private void buttonKeuzeDoorvoeren_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var groente in aangeduideGroenten)
            //{
            //    StartschermGroenten.GekozenGroenten.Add(groente);
            //}
            this.Close();
        }
    }
}
