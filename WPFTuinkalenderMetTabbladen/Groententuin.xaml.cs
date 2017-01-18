using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        public List<Moestuin> selectieMoestuinen = new List<Moestuin>();
        public List<int> selectieMaanden = new List<int>();

        public string[] arrMaanden = new string[12] { "januari", "februari", "maart", "april", "mei", "juni", "juli", 
            "augustus", "september", "oktober", "november", "december" };

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
                //huidige maand wordt geselecteerd in tabKlussenPerMaand en geselecteerde moestuin uit listBoxMoestuinen
                tabKlussenPerMaand.Focus();
                var huidigeMaand = DateTime.Now.Month;
                var teller = 0;
                foreach (var button in stackPanelMetToggleButtonsMaanden.Children)
                {
                    var toggleButton = (ToggleButton)button;
                    if (teller == huidigeMaand)
                    {
                        toggleButton.IsChecked = true;
                        break;
                    }
                    teller++;
                }

                //listbox moestuinen met checkboxen vullen
                foreach (var moestuin in MoestuinOb)
                {
                    var nieuweCheckBox = new CheckBox();
                    nieuweCheckBox.Width = 154;
                    nieuweCheckBox.Content = moestuin.NaamTuin;
                    nieuweCheckBox.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(CheckBoxMeerdereMoestuinen_Checked));
                    listBoxMoestuinenCheckBox.Items.Add(nieuweCheckBox);
                }
                toggleButtonEenMoestuin.IsChecked = true;
                MaakDeJuisteListBoxMoestuinenZichtbaar();
                listBoxMoestuinen.SelectedIndex = -1;
                listBoxMoestuinen.SelectedIndex = 0;

                BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
            }
            else
            {
                GeenMoestuin();
            }

            //lijst met alle groenten in tab info groenten
            foreach (var groente in AlleGroenten)
            {
                listBoxAlleGroenten.Items.Add(groente);
            }
            listBoxAlleGroenten.SelectedIndex = -1;
        }

        private void MaakDeJuisteListBoxMoestuinenZichtbaar()
        {
            if (toggleButtonEenMoestuin.IsChecked == true)
            {
                listBoxMoestuinen.Height = 405;
                listBoxMoestuinenCheckBox.Height = 0;
                labelMeldingKeuzeMoestuin.Content = "Kies een moestuin uit de lijst.";
            }
            else if (toggleButtonMeerdereMoestuinen.IsChecked == true)
            {
                listBoxMoestuinenCheckBox.Height = 405;
                listBoxMoestuinen.Height = 0;
                labelMeldingKeuzeMoestuin.Content = "Kies moestuinen uit de lijst.";
                var teller = 1;
                foreach (var listboxItem in listBoxMoestuinenCheckBox.Items)
                {
                    var checkBox = (CheckBox)listboxItem;
                    if (teller == 1)
                    {
                        checkBox.IsChecked = true;
                    }
                    else
                    {
                        checkBox.IsChecked = false;
                    }
                    teller++;
                }
            }
            else
            {
                listBoxMoestuinenCheckBox.Height = 405;
                listBoxMoestuinen.Height = 0;
                labelMeldingKeuzeMoestuin.Content = "";
                foreach (var listboxItem in listBoxMoestuinenCheckBox.Items)
                {
                    var checkBox = (CheckBox)listboxItem;
                    checkBox.IsChecked = true;
                }
            }
        }

        private void GeenMoestuin()
        {
            tabcontrolGroententuin.Height = 0;
            tabcontrolGroententuin.Visibility = Visibility.Hidden;
            labelMeldingMoestuinAanmaken.Height = 40;
            labelMeldingMoestuinAanmaken.FontSize = 20;
            labelMeldingMoestuinAanmaken.Content = "Maak eerst een moestuin aan.";
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
                listBoxBeschikbareGroenten.SelectedIndex = -1;
            }
        }

        private void VulLijstMetGroentenInTuin()
        {
            Moestuin geselecteerdeMoestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);

            CollectionViewSource groenteViewSource = ((CollectionViewSource)(this.FindResource("groenteViewSource")));
            var manager = new GroenteManager();
            GroentenInMoestuin = manager.GetAlleGroentenUitMoestuin(geselecteerdeMoestuin.Id);
            groenteViewSource.Source = GroentenInMoestuin;
        }

        private void buttonMoestuinToevoegen_Click(object sender, RoutedEventArgs e)
        {
            GroententuinAanmaken nieuwGroententuinAanmaken = new GroententuinAanmaken();
            nieuwGroententuinAanmaken.Show();
            nieuwGroententuinAanmaken.Focus();
            this.Close();
        }

        private void buttonMoestuinAanpassen_Click(object sender, RoutedEventArgs e)
        {
            //aanvullen
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
                        GeenMoestuin();
                    }
                }
            }
        }

        private void listBoxMoestuinen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxMoestuinen.SelectedItem != null)
            {
                //listbox en canvas leegmaken op tab klussen per groenten
                listBoxOmschrijvingKlussenPerGroente.Items.Clear();
                foreach (Canvas item in canvasKleurKlussenPerMaand.Children)
                {
                    foreach (Polygon polygon in item.Children)
                    {
                        polygon.Fill = null;
                    }
                }

                Moestuin moestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
                labelEigenaar.Content = moestuin.Eigenaar;
                labelAdres.Content = moestuin.Adres;
                labelPostcode.Content = moestuin.Postcode;
                labelGemeente.Content = moestuin.Gemeente;

                var manager = new GroenteManager();
                var groentenInMoestuin = manager.GetAlleGroentenUitMoestuin(moestuin.Id);
                VulLijstMetGroentenInTuin();
                VulLijstMetBeschikbareGroenten();

                statusGeselecteerdeMoestuin.Content = moestuin.NaamTuin;

                BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
            }
            else
            {
                labelEigenaar.Content = null;
                labelAdres.Content = null;
                labelPostcode.Content = null;
                labelGemeente.Content = null;
            }
        }

        private void buttonKiesGroente_Click(object sender, RoutedEventArgs e)
        {
            GroentenToevoegenAanMoestuin();
        }

        private void groenteToevoegenMetDubbelklik(object sender, RoutedEventArgs e)
        {
            GroentenToevoegenAanMoestuin();
        }

        private void GroentenToevoegenAanMoestuin()
        {
            var toeTeVoegenGroenten = new List<Groente>();
            var manager = new GroenteManager();
            Moestuin geselecteerdeMoestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
            if (listBoxBeschikbareGroenten.SelectedItems.Count > 1)
            {
                foreach (var toeTeVoegenGroente in listBoxBeschikbareGroenten.SelectedItems)
                {
                    toeTeVoegenGroenten.Add((Groente)toeTeVoegenGroente);
                }
            }
            else if (listBoxBeschikbareGroenten.SelectedItems.Count == 1)
            {
                toeTeVoegenGroenten.Add((Groente)(listBoxBeschikbareGroenten.SelectedItem));
            }
            foreach (var groenteInLijstToeTeVoegenGroenten in toeTeVoegenGroenten)
            {
                manager.VoegGroenteToeAanMoestuin(groenteInLijstToeTeVoegenGroenten.GroenteId, geselecteerdeMoestuin.Id);
            }

            VulLijstMetGroentenInTuin();
            VulLijstMetBeschikbareGroenten();
        }

        private void buttonVerwijderGeselecteerdeGroente_Click(object sender, RoutedEventArgs e)
        {
            GroentenVerwijderenUitTuin();
        }

        private void groenteVerwijderenMetDubbelklik(object sender, RoutedEventArgs e)
        {
            GroentenVerwijderenUitTuin();
        }

        private void GroentenVerwijderenUitTuin()
        {
            var teVerwijderenGroenten = new List<Groente>();
            Moestuin moestuin = (Moestuin)(listBoxMoestuinen.SelectedItem);
            var manager = new GroenteManager();
            if (listBoxGroentenInMoestuinTabGroenten.SelectedItems.Count > 1)
            {
                foreach (var teVerwijderenGroente in listBoxGroentenInMoestuinTabGroenten.SelectedItems)
                {
                    teVerwijderenGroenten.Add((Groente)teVerwijderenGroente);
                }
            }
            else if (listBoxGroentenInMoestuinTabGroenten.SelectedItems.Count == 1)
            {
                teVerwijderenGroenten.Add((Groente)listBoxGroentenInMoestuinTabGroenten.SelectedItem);
            }
            foreach (var groenteInLijstMetTeVerwijderenGroenten in teVerwijderenGroenten)
            {
                manager.VerwijderGroenteUitMoestuin(groenteInLijstMetTeVerwijderenGroenten.GroenteId, moestuin.Id);
            }
            VulLijstMetGroentenInTuin();
            VulLijstMetBeschikbareGroenten();
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
            Groente geselecteerdeGroente = null;
            if (listBoxBeschikbareGroenten.SelectedIndex >= 0)
            {
                geselecteerdeGroente = (Groente)(listBoxBeschikbareGroenten.SelectedItem);
                listBoxBeschikbareGroenten.SelectedIndex = -1;
            }
            else if (listBoxGroentenInMoestuinTabGroenten.SelectedIndex >= 0)
            {
                geselecteerdeGroente = (Groente)(listBoxGroentenInMoestuinTabGroenten.SelectedItem);
                listBoxGroentenInMoestuinTabGroenten.SelectedIndex = -1;
            }
            if (geselecteerdeGroente != null)
            {
                tabGroenteInfo.Focus();
                foreach (var item in listBoxAlleGroenten.Items)
                {
                    var groente = (Groente)item;
                    if (groente.NederlandseNaam == geselecteerdeGroente.NederlandseNaam)
                    {
                        listBoxAlleGroenten.SelectedItem = groente;
                        break;
                    }
                }
            }
        }

        private void listBoxGroentenInMoestuinTabGroenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxGroentenInMoestuinTabGroenten.SelectedIndex >= 0)
            {
                listBoxBeschikbareGroenten.SelectedIndex = -1;
            }
        }

        private void listBoxBeschikbareGroenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxBeschikbareGroenten.SelectedIndex >= 0)
            {
                listBoxGroentenInMoestuinTabGroenten.SelectedIndex = -1;
            }
        }

        //om meerdere items in een lijst te selecteren
        private void listBoxBeschikbareGroentenCtrlClick(object sender, MouseButtonEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                listBoxBeschikbareGroenten.SelectionMode = SelectionMode.Multiple;
            }
            else
            {
                listBoxBeschikbareGroenten.SelectionMode = SelectionMode.Single;
            }
        }
        private void listBoxGroentenInMoestuinTabGroentenCtrlClick(object sender, MouseButtonEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                listBoxGroentenInMoestuinTabGroenten.SelectionMode = SelectionMode.Multiple;
            }
            else
            {
                listBoxGroentenInMoestuinTabGroenten.SelectionMode = SelectionMode.Single;
            }
        }

        private void buttonBalkJanuari_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonJanuari);
            toggleButtonJanuari.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkFebruari_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonFebruari);
            toggleButtonFebruari.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkMaart_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonMaart);
            toggleButtonMaart.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkApril_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonApril);
            toggleButtonApril.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkMei_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonMei);
            toggleButtonMei.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkJuni_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonJuni);
            toggleButtonJuni.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkJuli_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonJuli);
            toggleButtonJuli.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkAugustus_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonAugustus);
            toggleButtonAugustus.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkSeptember_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonSeptember);
            toggleButtonSeptember.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkOktober_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonOktober);
            toggleButtonOktober.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkNovember_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonNovember);
            toggleButtonNovember.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void buttonBalkDecember_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            AndereToggleButtonsMaandenUnChecked(toggleButtonDecember);
            toggleButtonDecember.IsChecked = true;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        //andere togglebutton in balk unchecken
        private void AndereToggleButtonsMaandenUnChecked(ToggleButton button)
        {
            foreach (var tb in stackPanelMetToggleButtonsMaanden.Children)
            {
                var toggleButton = (ToggleButton)tb;
                if ((toggleButton.IsChecked == true) && (toggleButton != button))
                {
                    toggleButton.IsChecked = false;
                }
            }
        }

        private void toggleButtonAlleMaanden_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsMaandenUnChecked(button);
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonJanuari_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonFebruari_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonMaart_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonApril_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonMei_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonJuni_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonJuli_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonAugustus_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonSeptember_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonOktober_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonNovember_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonDecember_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            toggleButtonAlleMaanden.IsChecked = false;
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        /*listbox omschrijving klussen per maand vullen met tekst ipv textblocken*/
        //private void VulLijstMetKlussenPerMaand(List<int> maandNummers, List<Moestuin> lijstMoestuinen)
        //{
        //    //proberen deze method sneller te maken

        //    listBoxOmschrijvingKlussenPerMaand.Items.Clear();
        //    foreach (var moestuin in lijstMoestuinen)
        //    {
        //        var eersteString = "";
        //        eersteString = moestuin.NaamTuin + ":";

        //        listBoxOmschrijvingKlussenPerMaand.Items.Add(eersteString);
        //        foreach (var maandNr in maandNummers)
        //        {
        //            var tweedeString = "   ";
        //            tweedeString += ((arrMaanden[maandNr].ToUpper())[0]) + (arrMaanden[maandNr].Substring(1)) + ":";
        //            listBoxOmschrijvingKlussenPerMaand.Items.Add(tweedeString);

        //            var manager = new GroenteManager();
        //            var lijstGroenten = manager.GetAlleGroentenUitMoestuin(moestuin.Id);

        //            if (lijstGroenten.Count != 0)
        //            {
        //                var klussenInDeMaand = new List<Klus>();
        //                var teSchrijvenTekst = "       ";
        //                foreach (var groente in lijstGroenten)
        //                {
        //                    var klussenVanGroente = manager.GetKlussenVanEenGroente(groente.GroenteId);
        //                    foreach (var klus in klussenVanGroente)
        //                    {
        //                        var maandenKlus = new List<int>();
        //                        var beginMaandNr = klus.Begintijdstip;
        //                        var eindMaandNr = klus.Begintijdstip + klus.Duur - 1;
        //                        for (int i = beginMaandNr; i <= eindMaandNr; i++)
        //                        {
        //                            if (i <= 12)
        //                            {
        //                                maandenKlus.Add(i);
        //                            }
        //                            else
        //                            {
        //                                maandenKlus.Add(i - 12);
        //                            }
        //                        }
        //                        if (maandenKlus.Contains(maandNr + 1))
        //                        {
        //                            klussenInDeMaand.Add(klus);
        //                        }
        //                    }
        //                }

        //                if (klussenInDeMaand.Count != 0)
        //                {
        //                    var vorigeGroente = "";
        //                    foreach (var klus in klussenInDeMaand)
        //                    {
        //                        if ((vorigeGroente != klus.Groente.NederlandseNaam))
        //                        {
        //                            teSchrijvenTekst = "       ";
        //                            teSchrijvenTekst += klus.Groente.NederlandseNaam + ":\n       ";
        //                            if (klus.LangeOmschrijving == "aanvullen")      //voorlopig
        //                            {
        //                                teSchrijvenTekst += klus.KorteOmschrijving + "\n       ";
        //                            }
        //                            else
        //                            {
        //                                teSchrijvenTekst += klus.LangeOmschrijving + "\n       ";
        //                            }

        //                            listBoxOmschrijvingKlussenPerMaand.Items.Add(teSchrijvenTekst);
        //                        }
        //                        else
        //                        {
        //                            if (klus.LangeOmschrijving == "aanvullen")      //voorlopig
        //                            {
        //                                teSchrijvenTekst += klus.KorteOmschrijving + "\n       ";
        //                            }
        //                            else
        //                            {
        //                                teSchrijvenTekst += klus.LangeOmschrijving + "\n       ";
        //                            }
        //                        }
        //                        vorigeGroente = klus.Groente.NederlandseNaam;
        //                    }
        //                }
        //                else
        //                {
        //                    var stringGeenKlussen = "       Voor " + moestuin.NaamTuin + " zijn er geen klussen in " + arrMaanden[maandNr] + ".";
        //                    listBoxOmschrijvingKlussenPerMaand.Items.Add(stringGeenKlussen);
        //                }
        //            }
        //            else
        //            {
        //                var stringGeenGroenten = "       Er zijn nog geen groenten gekozen voor deze moestuin.";
        //                listBoxOmschrijvingKlussenPerMaand.Items.Add(stringGeenGroenten);
        //            }
        //        }
        //    }
        //}

        private void VulLijstMetKlussenPerMaand(List<int> maandNummers, List<Moestuin> lijstMoestuinen)
        {
            //proberen deze method sneller te maken
            var tekstGeselecteerdeMoestuin = "";

            listBoxOmschrijvingKlussenPerMaand.Items.Clear();
            foreach (var moestuin in lijstMoestuinen)
            {
                var eersteTextBlock = new TextBlock();
                eersteTextBlock.Text = moestuin.NaamTuin + ":";
                eersteTextBlock.FontWeight = FontWeights.Bold;
                eersteTextBlock.FontSize = 18;
                eersteTextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#265C00");
                eersteTextBlock.Width = 610;
                eersteTextBlock.AddHandler(TextBlock.MouseEnterEvent, new RoutedEventHandler(textBlock_MouseEnter));
                eersteTextBlock.AddHandler(TextBlock.MouseLeaveEvent, new RoutedEventHandler(textBlock_MouseLeave));

                listBoxOmschrijvingKlussenPerMaand.Items.Add(eersteTextBlock);

                var manager = new GroenteManager();
                var groentenInHuidigeTuin = manager.GetAlleGroentenUitMoestuin(moestuin.Id);
                if (groentenInHuidigeTuin.Count != 0)
                {
                    foreach (var maandNr in maandNummers)
                    {
                        var tweedeTextBlock = new TextBlock();
                        tweedeTextBlock.Text = ((arrMaanden[maandNr].ToUpper())[0]) + (arrMaanden[maandNr].Substring(1)) + ":";
                        tweedeTextBlock.FontSize = 14;
                        tweedeTextBlock.FontWeight = FontWeights.Bold;
                        tweedeTextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#265C00");
                        tweedeTextBlock.Width = 610;
                        var paddingTweedeTextBlock = tweedeTextBlock.Padding;
                        paddingTweedeTextBlock.Left = 15;
                        tweedeTextBlock.Padding = paddingTweedeTextBlock;
                        tweedeTextBlock.AddHandler(TextBlock.MouseEnterEvent, new RoutedEventHandler(textBlock_MouseEnter));
                        tweedeTextBlock.AddHandler(TextBlock.MouseLeaveEvent, new RoutedEventHandler(textBlock_MouseLeave));

                        listBoxOmschrijvingKlussenPerMaand.Items.Add(tweedeTextBlock);

                        var klussenInDeMaand = new List<Klus>();
                        var teSchrijvenTekst = "";
                        foreach (var groente in groentenInHuidigeTuin)
                        {
                            var klussenVanGroente = manager.GetKlussenVanEenGroente(groente.GroenteId);
                            foreach (var klus in klussenVanGroente)
                            {
                                var maandenKlus = new List<int>();
                                var beginMaandNr = klus.Begintijdstip;
                                var eindMaandNr = klus.Begintijdstip + klus.Duur - 1;
                                for (int i = beginMaandNr; i <= eindMaandNr; i++)
                                {
                                    if (i <= 12)
                                    {
                                        maandenKlus.Add(i);
                                    }
                                    else
                                    {
                                        maandenKlus.Add(i - 12);
                                    }
                                }
                                if (maandenKlus.Contains(maandNr + 1))
                                {
                                    klussenInDeMaand.Add(klus);
                                }
                            }
                        }

                        if (klussenInDeMaand.Count != 0)
                        {
                            var vorigeGroente = "";
                            TextBlock vorigeTextBlock = null;
                            foreach (var klus in klussenInDeMaand)
                            {
                                if ((vorigeGroente != klus.Groente.NederlandseNaam))
                                {
                                    var textblockPerGroente = new TextBlock();
                                    textblockPerGroente.FontSize = 14;
                                    textblockPerGroente.Foreground = (Brush)new BrushConverter().ConvertFromString("#265C00");
                                    var paddingTextBlockPerGroente = textblockPerGroente.Padding;
                                    paddingTextBlockPerGroente.Left = 30;
                                    textblockPerGroente.Padding = paddingTextBlockPerGroente;
                                    textblockPerGroente.Width = 610;
                                    textblockPerGroente.AddHandler(TextBlock.MouseEnterEvent, new RoutedEventHandler(textBlock_MouseEnter));
                                    textblockPerGroente.AddHandler(TextBlock.MouseLeaveEvent, new RoutedEventHandler(textBlock_MouseLeave));

                                    teSchrijvenTekst = klus.Groente.NederlandseNaam + ":\n";
                                    if (klus.LangeOmschrijving == "aanvullen")      //voorlopig
                                    {
                                        teSchrijvenTekst += klus.KorteOmschrijving + "\n";
                                    }
                                    else
                                    {
                                        teSchrijvenTekst += klus.LangeOmschrijving + "\n";
                                    }
                                    textblockPerGroente.Text = teSchrijvenTekst;
                                    vorigeTextBlock = textblockPerGroente;
                                    listBoxOmschrijvingKlussenPerMaand.Items.Add(textblockPerGroente);
                                }
                                else
                                {
                                    if (klus.LangeOmschrijving == "aanvullen")      //voorlopig
                                    {
                                        teSchrijvenTekst += klus.KorteOmschrijving + "\n";
                                    }
                                    else
                                    {
                                        teSchrijvenTekst += klus.LangeOmschrijving + "\n";
                                    }
                                    vorigeTextBlock.Text = teSchrijvenTekst;
                                }
                                vorigeGroente = klus.Groente.NederlandseNaam;
                            }
                        }
                        else
                        {
                            var textblockGeenGroente = new TextBlock();
                            textblockGeenGroente.FontSize = 14;
                            var marginTextBlockGeenGroente = textblockGeenGroente.Margin;
                            marginTextBlockGeenGroente.Left = 30;
                            textblockGeenGroente.Margin = marginTextBlockGeenGroente;
                            textblockGeenGroente.Text = "Voor " + moestuin.NaamTuin + " zijn er geen klussen in " + arrMaanden[maandNr] + ".";
                            listBoxOmschrijvingKlussenPerMaand.Items.Add(textblockGeenGroente);
                        }
                    }
                }
                else
                {
                    var textBlockGeenGroenten = new TextBlock();
                    textBlockGeenGroenten.Text = "Er zijn nog geen groenten gekozen voor deze moestuin.";
                    listBoxOmschrijvingKlussenPerMaand.Items.Add(textBlockGeenGroenten);
                }

                tekstGeselecteerdeMoestuin += moestuin.NaamTuin + "/";
            }
            if (tekstGeselecteerdeMoestuin.Length > 0)
            {
                tekstGeselecteerdeMoestuin = tekstGeselecteerdeMoestuin.Substring(0, tekstGeselecteerdeMoestuin.Length - 1);
                statusGeselecteerdeMoestuin.Content = tekstGeselecteerdeMoestuin;
            }

            //listBoxOmschrijvingKlussenPerMaand.SelectedIndex = 0;
            //listBoxOmschrijvingKlussenPerMaand.ScrollIntoView(listBoxOmschrijvingKlussenPerMaand.SelectedItem);

        }

        //als mouseover listboxitem = true
        private void textBlock_MouseEnter(object sender, RoutedEventArgs e)
        {
            var textBlock = (TextBlock)sender;
            if (textBlock.IsMouseOver == true)
            {
                textBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#9E6D34");
            }
        }

        //als mouseover listboxitem = false
        private void textBlock_MouseLeave(object sender, RoutedEventArgs e)
        {
            var textBlock = (TextBlock)sender;
            if (textBlock.IsMouseOver == false)
            {
                textBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#265C00");
            }
        }

        //private void listBoxOmschrijvingKlussenPerMaand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            //om ervoor te zorgen dat er geen item kan geselecteerd worden
   //weg    //listBoxOmschrijvingKlussenPerMaand.SelectedIndex = 0;
            //listBoxOmschrijvingKlussenPerMaand.ScrollIntoView(listBoxOmschrijvingKlussenPerMaand.SelectedItem);
            //listBoxOmschrijvingKlussenPerMaand.SelectedIndex = -1;
        //}

        private void listBoxAlleGroenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Groente geselecteerdeGroente = (Groente)(listBoxAlleGroenten.SelectedItem);
            listBoxAlleGroenten.ScrollIntoView(listBoxAlleGroenten.SelectedItem);


            //kleur verwijderen uit polygonen
            foreach (Canvas item in canvasKleurKlussenPerMaand.Children)
            {
                foreach (Polygon polygon in item.Children)
                {
                    polygon.Fill = null;
                }
            }
            listBoxOmschrijvingKlussenPerGroente.Items.Clear();
            if (listBoxAlleGroenten.SelectedItem != null)
            {
                var manager = new GroenteManager();
                var lijstMetKlussen = manager.GetKlussenVanEenGroente(geselecteerdeGroente.GroenteId);

                //om bij te houden welke maanden gekleurd moeten worden
                var beigeMaanden = new List<int>();
                var bruineMaanden = new List<int>();
                var groeneMaanden = new List<int>();

                foreach (var klus in lijstMetKlussen)
                {

                    var beginmaand = "";
                    var eindmaand = ""; var nieuweString = "";

                    if (klus.Duur > 1)
                    {
                        if (klus.Begintijdstip + klus.Duur <= 12)
                        {
                            beginmaand = arrMaanden[klus.Begintijdstip - 1];
                            eindmaand = arrMaanden[(klus.Begintijdstip - 1) + (klus.Duur - 1)];
                        }
                        else if (((klus.Begintijdstip) + (klus.Duur - 1) - 13) >= 0)
                        {
                            beginmaand = arrMaanden[klus.Begintijdstip - 1];
                            eindmaand = arrMaanden[(klus.Begintijdstip) + (klus.Duur - 1) - 13];
                        }
                        else
                        {
                            beginmaand = arrMaanden[klus.Begintijdstip - 1];
                            eindmaand = arrMaanden[(klus.Begintijdstip) + (klus.Duur - 2)];
                        }

                        //tekst afsplitsen als deze te lang is
                        var arrWoordenLangeOmschrijving = klus.LangeOmschrijving.Split(' ');
                        nieuweString = klus.KorteOmschrijving + ": van " + beginmaand + " tot en met " + eindmaand + "\n  ";
                        var lengteEersteRegel = nieuweString.Length;
                        var tellerRegel = 1;
                        foreach (var woord in arrWoordenLangeOmschrijving)
                        {
                            if (((nieuweString + woord).Length - lengteEersteRegel) > (tellerRegel * 55))
                            {
                                tellerRegel++;
                                nieuweString += "\n  " + woord;
                            }
                            else
                            {
                                nieuweString += woord;
                            }
                            nieuweString += " ";
                        }
                        nieuweString += "\n";
                    }
                    else
                    {
                        beginmaand = arrMaanden[klus.Begintijdstip - 1];
                        //tekst afsplitsen als deze te lang is
                        var arrWoordenLangeOmschrijving = klus.LangeOmschrijving.Split(' ');
                        nieuweString = klus.KorteOmschrijving + ": in " + beginmaand + "\n  ";
                        var lengteEersteRegel = nieuweString.Length;
                        var tellerRegel = 1;
                        foreach (var woord in arrWoordenLangeOmschrijving)
                        {
                            if (((nieuweString + woord)).Length - lengteEersteRegel > (tellerRegel * 55))
                            {
                                tellerRegel++;
                                nieuweString += "\n  " + woord;
                            }
                            else
                            {
                                nieuweString += woord;
                            }
                            nieuweString += " ";
                        }
                        nieuweString += "\n";
                    }
                    listBoxOmschrijvingKlussenPerGroente.Items.Add(nieuweString);

                    //lijst vullen met op te vullen canvas en welke kleur deze moet hebben
                    var begin = klus.Begintijdstip;
                    var einde = 0;
                    if ((begin + klus.Duur - 1) <= 12)
                    {
                        einde = begin + klus.Duur - 1;
                        for (int i = begin; i <= einde; i++)
                        {
                            switch (klus.SoortKlus.ToString())
                            {
                                case "Voorzaaien":
                                    bruineMaanden.Add(i);
                                    break;
                                case "ZaaienOfPlanten":
                                    beigeMaanden.Add(i);
                                    break;
                                case "Oogsten":
                                    groeneMaanden.Add(i);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        einde = begin + klus.Duur - 13;
                        for (int i = begin; i <= einde + 12; i++)
                        {
                            switch (klus.SoortKlus.ToString())
                            {
                                case "Voorzaaien":
                                    if (i > 12)
                                    {
                                        bruineMaanden.Add(i - 12);
                                    }
                                    else
                                    {
                                        bruineMaanden.Add(i);
                                    }
                                    break;
                                case "ZaaienOfPlanten":
                                    if (i > 12)
                                    {
                                        beigeMaanden.Add(i - 12);
                                    }
                                    else
                                    {
                                        beigeMaanden.Add(i);
                                    }
                                    break;
                                case "Oogsten":
                                    if (i > 12)
                                    {
                                        groeneMaanden.Add(i - 12);
                                    }
                                    else
                                    {
                                        groeneMaanden.Add(i);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                //polygonen opvullen
                foreach (var item in canvasKleurKlussenPerMaand.Children)
                {
                    var canvasMaand = (Canvas)item;
                    int maandNr = int.Parse(canvasMaand.Name.Substring(11));
                    var lijstPolygonen = new List<Polygon>();
                    var moetGeelGekleurdWorden = false;
                    var moetGroenGekleurdWorden = false;
                    var moetBlauwGekleurdWorden = false;
                    //nagaan welke kleuren de maand moet hebben
                    if (bruineMaanden.Contains(maandNr))
                    {
                        moetGeelGekleurdWorden = true;
                    }
                    if (beigeMaanden.Contains(maandNr))
                    {
                        moetGroenGekleurdWorden = true;
                    }
                    if (groeneMaanden.Contains(maandNr))
                    {
                        moetBlauwGekleurdWorden = true;
                    }

                    foreach (var child in canvasMaand.Children)
                    {
                        var polygon = (Polygon)child;
                        lijstPolygonen.Add(polygon);
                    }

                    BrushConverter bc = new BrushConverter();
                    SolidColorBrush bruin = (SolidColorBrush)bc.ConvertFromString("#8F660F");
                    SolidColorBrush beige = (SolidColorBrush)bc.ConvertFromString("#E0BD5E");
                    SolidColorBrush groen = (SolidColorBrush)bc.ConvertFromString("#265C00");
                    if (moetGeelGekleurdWorden)
                    {
                        lijstPolygonen[0].Fill = bruin;
                        lijstPolygonen[1].Fill = bruin;
                    }
                    if (moetGroenGekleurdWorden)
                    {
                        if (lijstPolygonen[0].Fill == null)
                        {
                            lijstPolygonen[0].Fill = beige;
                            lijstPolygonen[1].Fill = beige;
                        }
                        else
                        {
                            lijstPolygonen[1].Fill = beige;
                        }
                    }
                    if (moetBlauwGekleurdWorden)
                    {
                        if (lijstPolygonen[0].Fill == null)
                        {
                            lijstPolygonen[0].Fill = groen;
                            lijstPolygonen[1].Fill = groen;
                        }
                        else
                        {
                            if (lijstPolygonen[0].Fill == lijstPolygonen[1].Fill)
                            {
                                lijstPolygonen[1].Fill = groen;
                            }
                            else
                            {
                                lijstPolygonen[2].Fill = bruin;
                                lijstPolygonen[3].Fill = beige;
                                lijstPolygonen[4].Fill = groen;
                            }
                        }
                    }
                }
            }
        }

        private void expanderGegevensGroenten_Expanded(object sender, EventArgs e)
        {
            expanderOmschijvingKlussen.IsExpanded = false;
        }

        private void expanderOmschrijvingKlussen_Expanded(object sender, EventArgs e)
        {
            expanderGegevensGroenten.IsExpanded = false;
        }

        //balk met togglebuttons om de mogelijk te kiezen om meer moestuinen te selecteren
        private void toggleButtonAlleMoestuinen_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsMoestuinenUnChecked(button);
            MaakDeJuisteListBoxMoestuinenZichtbaar();

            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonMeerdereMoestuinen_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsMoestuinenUnChecked(button);
            MaakDeJuisteListBoxMoestuinenZichtbaar();

            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void toggleButtonEenMoestuin_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsMoestuinenUnChecked(button);
            MaakDeJuisteListBoxMoestuinenZichtbaar();
            listBoxMoestuinen.SelectedIndex = 0;

            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }

        private void AndereToggleButtonsMoestuinenUnChecked(ToggleButton button)
        {
            if (button.IsChecked == false)
            {
                button.IsChecked = true;
            }
            foreach (var tb in stackPanelMetToggleButtonsMoestuinen.Children)
            {
                var toggleButton = (ToggleButton)tb;
                if ((toggleButton.IsChecked == true) && (toggleButton != button))
                {
                    toggleButton.IsChecked = false;
                }
            }
        }


        private void tabcontrolGroententuin_selectionChanged(object sender, EventArgs e)
        {
            if (tabKlussenPerMaand.IsSelected == false)
            {
                toggleButtonEenMoestuin.IsChecked = true;
                AndereToggleButtonsMoestuinenUnChecked(toggleButtonEenMoestuin);
                MaakDeJuisteListBoxMoestuinenZichtbaar();
            }
            else
            {
                toggleButtonJanuari.IsChecked = true;
                AndereToggleButtonsMaandenUnChecked(toggleButtonJanuari);
                BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
            }
        }

        private void CheckBoxMeerdereMoestuinen_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var naamMoestuin = checkBox.Content.ToString();
            
            BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen();
        }



        private void BepaalSelectieMaandenEnMoestuinenEnVulLijstKlussen()
        {
            //selectieMaanden bepalen
            selectieMaanden.Clear();
            if (toggleButtonAlleMaanden.IsChecked == false)
            {
                foreach (var tb in stackPanelMetToggleButtonsMaanden.Children)
                {
                    var toggleButton = (ToggleButton)tb;
                    var naamMaand = (toggleButton.Name.ToString()).Substring(12);
                    var nrMaand = 0;

                    if (toggleButton.IsChecked == true)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            if (arrMaanden[i] == naamMaand.ToLower())
                            {
                                nrMaand = i;
                                break;
                            }
                        }
                        selectieMaanden.Add(nrMaand);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    selectieMaanden.Add(i);
                }
            }

            //selectieMoestuinen bepalen
            selectieMoestuinen.Clear();
            if (toggleButtonAlleMoestuinen.IsChecked == true)
            {
                foreach (var moestuin in MoestuinOb)
                {
                    selectieMoestuinen.Add(moestuin);
                }
            }
            else if (toggleButtonMeerdereMoestuinen.IsChecked == true)
            {
                var manager = new GroenteManager();
                foreach (var listBoxItem in listBoxMoestuinenCheckBox.Items)
                {
                    var checkBox = (CheckBox)listBoxItem;
                    if (checkBox.IsChecked == true)
                    {
                        selectieMoestuinen.Add(manager.GetMoestuinVolgensNaam(checkBox.Content.ToString()));
                    }
                }
            }
            else if (toggleButtonEenMoestuin.IsChecked == true)
            {
                selectieMoestuinen.Add((Moestuin)listBoxMoestuinen.SelectedItem);
            }

            //lijst vullen
            VulLijstMetKlussenPerMaand(selectieMaanden, selectieMoestuinen);
        }
    }
}
