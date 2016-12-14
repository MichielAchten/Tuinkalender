using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace WPFTuinkalenderMetTabbladen
{
    /// <summary>
    /// Interaction logic for Groententuin.xaml
    /// </summary>
    public partial class Groententuin : Window
    {
        public ObservableCollection<Moestuin> MoestuinOb = new ObservableCollection<Moestuin>();
        public List<Groente> AlleGroenten = new List<Groente>();
        public ObservableCollection<Groente> GroentenInMoestuin = new ObservableCollection<Groente>();

        public Groententuin()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            VulLijstMetMoestuinen();
            VulLijstMetBeschikbareGroenten();

            var aantal = MoestuinOb.Count;
            if (MoestuinOb.Count > 0)
            {
                tabcontrol.IsEnabled = true;
                listBoxMoestuinen.SelectedIndex = 0;
            }
            else
            {
                tabcontrol.IsEnabled = false;
            }
        }

        private void VulLijstMetMoestuinen()
        {
            //CollectionViewSource moestuinViewSource = ((CollectionViewSource)(this.FindResource("moestuinViewSource")));
            //var manager = new GroenteManager();
            //moestuinViewSource.Source = manager.GetAlleMoestuinen();

            CollectionViewSource moestuinViewSource = ((CollectionViewSource)(this.FindResource("moestuinViewSource")));
            var manager = new GroenteManager();
            MoestuinOb = manager.GetAlleMoestuinen();
            moestuinViewSource.Source = MoestuinOb;
        }

        private void VulLijstMetBeschikbareGroenten()
        {
            if (MoestuinOb.Count > 0)
            {
                listBoxBeschikbareGroenten.Items.Clear();
                Moestuin geselecteerdeMoestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
                var manager = new GroenteManager();
                var groentenInMoestuin = manager.GetAlleGroentenUitMoestuin(geselecteerdeMoestuin.Id);
                AlleGroenten = manager.GetAlleGroenten();

                foreach (var groente in AlleGroenten)
                {
                    var tuinBevatGroente = false;
                    foreach (var groenteInMoestuin in groentenInMoestuin)
                    {
                        if (groente.GroenteId == groenteInMoestuin.GroenteId)
                        {
                            tuinBevatGroente = true;
                            break;
                        }
                    }
                    if (!tuinBevatGroente)
                    {
                        listBoxBeschikbareGroenten.Items.Add(groente);
                    }
                }
            }
        }

        private void VulLijstMetGroentenInTuin()
        {
            Moestuin geselecteerdeMoestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);

            CollectionViewSource groenteViewSource = ((CollectionViewSource)(this.FindResource("groenteViewSource")));
            var manager = new GroenteManager();
            GroentenInMoestuin = manager.GetAlleGroentenUitMoestuin(geselecteerdeMoestuin.Id);
            groenteViewSource.Source = GroentenInMoestuin;

            if (GroentenInMoestuin.Count > 0)
            {
                stackPanelGroentenInMoestuin.IsEnabled = true;
            }
            else
            {
                stackPanelGroentenInMoestuin.IsEnabled = false;
            }
        }

        private void buttonMoestuinToevoegen_Click(object sender, RoutedEventArgs e)
        {
            GroententuinAanmaken nieuwGroententuinAanmaken = new GroententuinAanmaken();
            nieuwGroententuinAanmaken.Show();
            nieuwGroententuinAanmaken.Focus();
            this.Close();
        }

        private void buttonMoestuinVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u de moestuin wilt verwijderen?", "Moestuin verwijderen",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                if (listBoxMoestuinen.SelectedItem != null)
                {
                    var geselecteerdeMoestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
                    var manager = new GroenteManager();
                    manager.VerwijderMoestuin(geselecteerdeMoestuin.Id);
                    VulLijstMetMoestuinen();
                    if (MoestuinOb.Count == 0)
                    {
                        tabcontrol.IsEnabled = false;
                    }
                }
            }
        }

        private void listboxMoestuinen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabMoestuinGegevens.Focus();
            if (listBoxMoestuinen.SelectedItem != null)
            {
                Moestuin moestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
                labelNaamMoestuin.Content = moestuin.NaamTuin;
                labelEigenaar.Content = moestuin.Eigenaar;
                labelAdres.Content = moestuin.Adres;
                labelPostcode.Content = moestuin.Postcode;
                labelGemeente.Content = moestuin.Gemeente;

                var manager = new GroenteManager();
                var groentenInMoestuin = manager.GetAlleGroentenUitMoestuin(moestuin.Id);
                VulLijstMetGroentenInTuin();
                VulLijstMetBeschikbareGroenten();
            }
            else
            {
                labelNaamMoestuin.Content = null;
                labelEigenaar.Content = null;
                labelAdres.Content = null;
                labelPostcode.Content = null;
                labelGemeente.Content = null;
            }
        }

        private void buttonNaarTabbladGroenten_Click(object sender, RoutedEventArgs e)
        {
            tabGroentenInMoestuin.Focus();
        }

        private void buttonKiesGroente_Click(object sender, RoutedEventArgs e)
        {
            GroenteToevoegenAanMoestuin();
        }

        private void groenteToevoegenMetDubbelklik(object sender, RoutedEventArgs e)
        {
            GroenteToevoegenAanMoestuin();
        }

        private void GroenteToevoegenAanMoestuin()
        {
            if (listBoxBeschikbareGroenten.SelectedItem != null)
            {
                var manager = new GroenteManager();
                Groente geselecteerdeGroente = (Groente)(listBoxBeschikbareGroenten.SelectedItem);
                Moestuin geselecteerdeMoestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
                manager.VoegGroenteToeAanMoestuin(geselecteerdeGroente.GroenteId, geselecteerdeMoestuin.Id);

                VulLijstMetGroentenInTuin();
                VulLijstMetBeschikbareGroenten();
            }
        }

        private void buttonVerwijderGeselecteerdeGroente_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxGroentenInMoestuinTabGroenten.SelectedItem != null)
            {
                Groente groente = (Groente)(listBoxGroentenInMoestuinTabGroenten.SelectedItem);
                Moestuin moestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
                var manager = new GroenteManager();
                manager.VerwijderGroenteUitMoestuin(groente.GroenteId, moestuin.Id);

                VulLijstMetGroentenInTuin();
                VulLijstMetBeschikbareGroenten();
            }
        }

        private void buttonVerwijderAlleGroente_Click(object sender, RoutedEventArgs e)
        {
            Moestuin moestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
            var manager = new GroenteManager();
            manager.VerwijderAlleGroentenUitMoestuin(moestuin.Id);

            VulLijstMetGroentenInTuin();
            VulLijstMetBeschikbareGroenten();
        }

        private void buttonNaarTabbladGroenteInfo_Click(object sender, RoutedEventArgs e)
        {
            tabGroenteInfo.Focus();
        }

        private void buttonNaarTabKlussenPerGroente_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerGroente.Focus();
        }

        private void buttonNaarTabKlussenPerMaand_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
        }

        private void listBoxGroentenInMoestuinTabKlussen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxGroentenInMoestuinTabKlussen.SelectedItem != null)
            {
                textBoxOmschrijvingKlus.Text = "";
                var geselecteerdeGroente = (Groente)(listBoxGroentenInMoestuinTabKlussen.SelectedItem);
                var manager = new GroenteManager();
                var lijstMetKlussen = manager.GetKlussenVanEenGroente(geselecteerdeGroente.GroenteId);
                foreach (var klus in lijstMetKlussen)
                {
                    textBoxOmschrijvingKlus.Text += klus.KorteOmschrijving + "\t\t\t" + klus.Begintijdstip + "-" + (klus.Begintijdstip + klus.Duur) + "\n" +
                    klus.LangeOmschrijving + "\n\n";
                }
            }
        }


    }
}
