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
                tabcontrol.IsEnabled = true;
                listBoxMoestuinen.SelectedIndex = 0;
                //huidige maand wordt geselecteerd
                if (GroentenInMoestuin.Count != 0)
                {
                    tabKlussenPerMaand.Focus();
                    var huidigeMaand = DateTime.Now.Month;
                    var teller = 0;
                    foreach (var button in stackPanelMetToggleButtons.Children)
                    {
                        //var toggleButton = (ToggleButton)button;
                        //if (teller == huidigeMaand)
                        //{
                        //    toggleButton.IsChecked
                        //}
                        //teller++;
                    }
                }
            }
            else
            {
                tabMoestuinGegevens.Focus();
                tabcontrol.IsEnabled = false;
            }

            //Huidige maand selecteren in tab klussen per maand
            
            //comboBoxMaanden.Items.Add("Alle maanden");
            //for (int i = 0; i < arrMaanden.Length; i++)
  //weg     //{
            //    var eersteLetter = (arrMaanden[i].ToUpper())[0];
            //    var maand = eersteLetter + arrMaanden[i].Substring(1);
            //    comboBoxMaanden.Items.Add(maand);
            //    //huidige maand wordt geselecteerd
            //    var huidigeMaand = DateTime.Now.Month;
            //    comboBoxMaanden.SelectedIndex = huidigeMaand;
            //    listBoxOmschrijvingKlussenPerMaand.SelectedIndex = -1;
            //}


            //lijst met alle groenten in tab info groenten
            foreach (var groente in AlleGroenten)
            {
                listBoxAlleGroenten.Items.Add(groente);
            }
            listBoxAlleGroenten.SelectedIndex = -1;
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

            ////listBox met klussen per maand leegmaken
            //var selectieMaand = comboBoxMaanden.SelectedIndex;
            //comboBoxMaanden.SelectedIndex = -1;
            //comboBoxMaanden.SelectedIndex = selectieMaand;
  //weg     //listBoxOmschrijvingKlussenPerMaand.SelectedIndex = 0;
            //listBoxOmschrijvingKlussenPerMaand.ScrollIntoView(listBoxOmschrijvingKlussenPerMaand.SelectedItem);
            //listBoxOmschrijvingKlussenPerMaand.SelectedIndex = -1;
            //if (GroentenInMoestuin.Count == 0)
            //{
            //    tabKlussenPerMaand.IsEnabled = false;
            //    tabKlussenPerGroente.IsEnabled = false;
            //}
            //else
            //{
            //    tabKlussenPerMaand.IsEnabled = true;
            //    tabKlussenPerGroente.IsEnabled = true;
            //}
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

            if (listBoxMoestuinen.SelectedItem != null)
            {
                //textbox en canvas leegmaken op tab klussen per groenten
                textBoxOmschrijvingKlus.Text = "";
                foreach (Canvas item in canvasKleurKlussenPerMaand.Children)
                {
                    foreach (Polygon polygon in item.Children)
                    {
                        polygon.Fill = null;
                    }
                }

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

                if (groentenInMoestuin.Count != 0)
                {
                    ////huidige maand wordt geselecteerd
      //weg         //var huidigeMaand = DateTime.Now.Month;
                    //comboBoxMaanden.SelectedIndex = huidigeMaand;
                }
                else
                {
                    tabGroentenInMoestuin.Focus();
                }

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
            var geselecteerdeGroente = (Groente)(listBoxBeschikbareGroenten.SelectedItem);
            tabGroenteInfo.Focus();
            foreach (var groente in listBoxAlleGroenten.Items)
            {
                if (groente == geselecteerdeGroente)
                {
                    listBoxAlleGroenten.SelectedItem = groente;
                    break;
                }
            }
        }

        private void listBoxGroentenInMoestuinTabKlussen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxGroentenInMoestuinTabKlussen.SelectedItem != null)
            {
                //kleur verwijderen uit polygonen
                foreach (Canvas item in canvasKleurKlussenPerMaand.Children)
                {
                    foreach (Polygon polygon in item.Children)
                    {
                        polygon.Fill = null;
                    }
                }

                textBoxOmschrijvingKlus.Text = "\n";
                var geselecteerdeGroente = (Groente)(listBoxGroentenInMoestuinTabKlussen.SelectedItem);
                var manager = new GroenteManager();
                var lijstMetKlussen = manager.GetKlussenVanEenGroente(geselecteerdeGroente.GroenteId);

                //kleiner lettertype bij veel klussen
                if (lijstMetKlussen.Count <= 5)
                {
                    textBoxOmschrijvingKlus.FontSize = 12;
                }
                else if (lijstMetKlussen.Count <= 6)
                {
                    textBoxOmschrijvingKlus.FontSize = 11;
                }
                else if (lijstMetKlussen.Count <= 7)
                {
                    textBoxOmschrijvingKlus.FontSize = 10;
                }
                else
                {
                    textBoxOmschrijvingKlus.FontSize = 8.7;
                }

                //om bij te houden welke maanden gekleurd moeten worden
                var beigeMaanden = new List<int>();
                var bruineMaanden = new List<int>();
                var groeneMaanden = new List<int>();

                foreach (var klus in lijstMetKlussen)
                {
                    var beginmaand = "";
                    var eindmaand = "";
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

                        textBoxOmschrijvingKlus.Text += klus.KorteOmschrijving + ": van " + beginmaand + " tot en met " +
                            eindmaand + "\n" +
                        klus.LangeOmschrijving + "\n\n";
                    }
                    else
                    {
                        beginmaand = arrMaanden[klus.Begintijdstip - 1];

                        textBoxOmschrijvingKlus.Text += klus.KorteOmschrijving + ": in " + beginmaand + "\n" +
                        klus.LangeOmschrijving + "\n\n";
                    }

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
                //if (e.ClickCount > 1)
                //{
                //    listBoxBeschikbareGroenten.SelectionMode = SelectionMode.Multiple;
                //}
                //else
                //{
                //    listBoxBeschikbareGroenten.SelectionMode = SelectionMode.Single;
                //}
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
            toggleButtonJanuari.IsChecked = true;
        }

        private void buttonBalkFebruari_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonFebruari.IsChecked = true;
        }

        private void buttonBalkMaart_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonMaart.IsChecked = true;
        }

        private void buttonBalkApril_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonApril.IsChecked = true;
        }

        private void buttonBalkMei_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonMei.IsChecked = true;
        }

        private void buttonBalkJuni_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonJuni.IsChecked = true;
        }

        private void buttonBalkJuli_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonJuli.IsChecked = true;
        }

        private void buttonBalkAugustus_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonAugustus.IsChecked = true;
        }

        private void buttonBalkSeptember_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonSeptember.IsChecked = true;
        }

        private void buttonBalkOktober_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonOktober.IsChecked = true;
        }

        private void buttonBalkNovember_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonNovember.IsChecked = true;
        }

        private void buttonBalkDecember_Click(object sender, RoutedEventArgs e)
        {
            tabKlussenPerMaand.Focus();
            toggleButtonDecember.IsChecked = true;
        }

        //als een maand gekozen wordt
        private void AndereToggleButtonsUnChecked(ToggleButton button)
        {
            foreach (var tb in stackPanelMetToggleButtons.Children)
            {
                var toggleButton = (ToggleButton)tb;
                if ((button.IsChecked == true) && (toggleButton != button))
                {
                    toggleButton.IsChecked = false;
                    listBoxOmschrijvingKlussenPerMaand.Items.Clear();
                }
            }
        }

        private void toggleButtonBalkAlleMaanden_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(0);
        }

        private void toggleButtonJanuari_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(1);
        }

        private void toggleButtonFebruari_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(2);
        }

        private void toggleButtonMaart_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(3);
        }

        private void toggleButtonApril_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(4);
        }

        private void toggleButtonMei_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(5);
        }

        private void toggleButtonJuni_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(6);
        }

        private void toggleButtonJuli_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(7);
        }

        private void toggleButtonAugustus_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(8);
        }

        private void toggleButtonSeptember_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(9);
        }

        private void toggleButtonOktober_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(10);
        }

        private void toggleButtonNovember_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(11);
        }

        private void toggleButtonDecember_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            AndereToggleButtonsUnChecked(button);
            VulLijstMetKlussenPerMaand(12);
        }

        private void VulLijstMetKlussenPerMaand(int maandNr)
        {
            Moestuin geselecteerdeMoestuin = (Moestuin)listBoxMoestuinen.SelectedItem;
            var manager = new GroenteManager();
            var lijstGroenten = GroentenInMoestuin;

            var klussenInDeMaand = new List<Klus>();
            var teSchrijvenTekst = "";

            if (maandNr != 0)
            {
                foreach (var groente in lijstGroenten)
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
                        if (maandenKlus.Contains(maandNr))
                        {
                            klussenInDeMaand.Add(klus);
                        }
                    }
                }
            }
            else
            {
                foreach (var groente in lijstGroenten)
                {
                    var klussenVanGroente = manager.GetKlussenVanEenGroente(groente.GroenteId);
                    foreach (var klus in klussenVanGroente)
                    {
                        klussenInDeMaand.Add(klus);
                    }
                }
            }

            var vorigeGroente = "";
            TextBlock vorigeTextBlock = null;
            foreach (var klus in klussenInDeMaand)
            {
                if ((vorigeGroente != klus.Groente.NederlandseNaam))
                {
                    var textblockPerGroente = new TextBlock();
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
                    listBoxOmschrijvingKlussenPerMaand.Items.Add(vorigeTextBlock);
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
            if (listBoxOmschrijvingKlussenPerMaand.Items.Count == 0)
            {
                var textBlockMelding = new TextBlock();
                if (maandNr > 0)
                {
                    textBlockMelding.Text = "In " + arrMaanden[maandNr - 1] + " zijn er geen klussen in deze moestuin.\n\n";
                }
                else
                {
                    textBlockMelding.Text = "Er zijn geen klussen in deze moestuin.";
                }
                listBoxOmschrijvingKlussenPerMaand.Items.Add(textBlockMelding);
            }
        }
        

        private void listBoxAlleGroenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Groente geselecteerdeGroente = (Groente)(listBoxAlleGroenten.SelectedItem);
            labelNaamGroente.Content = geselecteerdeGroente.NederlandseNaam;
        }
    }
}
