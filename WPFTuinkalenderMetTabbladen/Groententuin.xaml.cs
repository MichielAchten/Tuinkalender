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
            }
            else
            {
                tabcontrol.IsEnabled = false;
            }

            //lijst in tabblad klussenPerMaand vullen met maanden
            comboBoxMaanden.Items.Add("  --kies een maand--");
            for (int i = 0; i < arrMaanden.Length; i++)
            {
                var eersteLetter = (arrMaanden[i].ToUpper())[0];
                var maand = eersteLetter + arrMaanden[i].Substring(1);
                comboBoxMaanden.Items.Add(maand);
                comboBoxMaanden.SelectedIndex = 0;
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
                var groeneMaanden = new List<int>();
                var geleMaanden = new List<int>();
                var blauweMaanden = new List<int>();

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
                            eindmaand = arrMaanden[(klus.Begintijdstip) + (klus.Duur - 1) - 12];
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
                                    geleMaanden.Add(i);
                                    break;
                                case "ZaaienOfPlanten":
                                    groeneMaanden.Add(i);
                                    break;
                                case "Oogsten":
                                    blauweMaanden.Add(i);
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
                                        geleMaanden.Add(i - 12);
                                    }
                                    else
                                    {
                                        geleMaanden.Add(i);
                                    }
                                    break;
                                case "ZaaienOfPlanten":
                                    if (i > 12)
                                    {
                                        groeneMaanden.Add(i - 12);
                                    }
                                    else
                                    {
                                        groeneMaanden.Add(i);
                                    }
                                    break;
                                case "Oogsten":
                                    if (i > 12)
                                    {
                                        blauweMaanden.Add(i - 12);
                                    }
                                    else
                                    {
                                        blauweMaanden.Add(i);
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
                    if (geleMaanden.Contains(maandNr))
                    {
                        moetGeelGekleurdWorden = true;
                    }
                    if (groeneMaanden.Contains(maandNr))
                    {
                        moetGroenGekleurdWorden = true;
                    }
                    if (blauweMaanden.Contains(maandNr))
                    {
                        moetBlauwGekleurdWorden = true;
                    }

                    foreach (var child in canvasMaand.Children)
                    {
                        var polygon = (Polygon)child;
                        lijstPolygonen.Add(polygon);
                    }

                    BrushConverter bc = new BrushConverter();
                    SolidColorBrush geel = (SolidColorBrush)bc.ConvertFromString("Yellow");
                    SolidColorBrush groen = (SolidColorBrush)bc.ConvertFromString("Green");
                    SolidColorBrush blauw = (SolidColorBrush)bc.ConvertFromString("blue");
                    if (moetGeelGekleurdWorden)
                    {
                        lijstPolygonen[0].Fill = geel;
                        lijstPolygonen[1].Fill = geel;
                    }
                    if (moetGroenGekleurdWorden)
                    {
                        if (lijstPolygonen[0].Fill == null)
                        {
                            lijstPolygonen[0].Fill = groen;
                            lijstPolygonen[1].Fill = groen;
                        }
                        else
                        {
                            lijstPolygonen[1].Fill = groen;
                        }
                    }
                    if (moetBlauwGekleurdWorden)
                    {
                        if (lijstPolygonen[0].Fill == null)
                        {
                            lijstPolygonen[0].Fill = blauw;
                            lijstPolygonen[1].Fill = blauw;
                        }
                        else
                        {
                            if (lijstPolygonen[0].Fill == lijstPolygonen[1].Fill)
                            {
                                lijstPolygonen[1].Fill = blauw;
                            }
                            else
                            {
                                lijstPolygonen[2].Fill = geel;
                                lijstPolygonen[3].Fill = groen;
                                lijstPolygonen[4].Fill = blauw;
                            }
                        }
                    }
                }
            }
        }

        //als een maand gekozen wordt
        private void comboBoxMaanden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (comboBoxMaanden.SelectedIndex != 0)
            //{
            //    labelMaand.Content = comboBoxMaanden.SelectedItem.ToString();
            //}
            //else
            //{
            //    labelMaand.Content = "";
            //}

            //Moestuin geselecteerdeMoestuin = (Moestuin)listBoxMoestuinen.SelectedItem;
            //var manager = new GroenteManager();
            //var lijstGroenten = manager.GetAlleGroentenUitMoestuin(geselecteerdeMoestuin.Id);
            //var lijstAlleKlussenVanDeGroenten = new List<Klus>();
            //foreach (var groente in lijstGroenten)
            //{
            //    var lijstKlussen = manager.GetKlussenVanEenGroente(groente.GroenteId);
            //    foreach (var klus in lijstKlussen)
            //    {
            //        lijstAlleKlussenVanDeGroenten.Add(klus);
            //    }
            //}

            //foreach (var klus in lijstAlleKlussenVanDeGroenten)
            //{
            //    if ((comboBoxMaanden.SelectedIndex <= 1))
            //    {
            //        //nog aanvullen
            //    }
            //}
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

    }
}
