using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for GroentetuinAanmaken.xaml
    /// </summary>
    public partial class GroententuinAanmaken : Window
    {
        public GroententuinAanmaken()
        {
            InitializeComponent();
        }

        private void buttonMoestuinToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Moestuin moestuin;
            var manager = new GroenteManager();
            var naam = "";
            var eigenaar = "";
            var adres = "";
            var postcode = 0;
            var gemeente = "";
            var aantalJuisteVelden = 0;

            if (valideerTextBoxMetString(textBoxNaam, labelNaamValidatie))
            {
                naam = textBoxNaam.Text;
                aantalJuisteVelden++;
            }
            if (valideerTextBoxMetString(textBoxEigenaar, labelEigenaarValidatie))
            {
                eigenaar = textBoxEigenaar.Text;
                aantalJuisteVelden++;
            }
            if (valideerTextBoxMetString(textBoxAdres, labelAdresValidatie))
            {
                adres = textBoxAdres.Text;
                aantalJuisteVelden++;
            }
            //if (valideerTextBoxMetString(textBoxGemeente, labelGemeenteValidatie))
            //{
            //    gemeente = textBoxGemeente.Text;
            //    aantalJuisteVelden++;
            //}
            if (textBoxGemeente.Text == "")
            {
                labelGemeenteValidatie.Content = "Verplicht in te vulle veld!";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxGemeente.Text, "^([A-Z][a-z]*)([-\\s][A-Z][a-z]*)*$"))
            {
                labelGemeenteValidatie.Content = "Geef een gemeente in!";
            }
            else
            {
                labelGemeenteValidatie.Content = "";
                gemeente = textBoxGemeente.Text;
                aantalJuisteVelden++;
            }

            if (textBoxPostcode.Text == "")
            {
                labelPostcodeValidatie.Content = "Verplicht in te vullen veld!";
            }
            else if (Int32.TryParse(textBoxPostcode.Text, out postcode))
            {
                if ((postcode > 999) && (postcode < 10000))
                {
                    labelPostcodeValidatie.Content = "";
                    aantalJuisteVelden++;
                }
                else
                {
                    labelPostcodeValidatie.Content = "Waarde tussen 999 en 10000!";
                }
            }
            else
            {
                labelPostcodeValidatie.Content = "Geef een getal in!";
            }
            if (aantalJuisteVelden == 5)
            {
                moestuin = new Moestuin { NaamTuin = naam, Eigenaar = eigenaar, Adres = adres, Postcode = postcode, Gemeente = gemeente };
                manager.MaakNieuweMoestuin(moestuin);
                this.Close();
            }
        }

        private bool valideerTextBoxMetString(TextBox textBox, Label label)
        {
            if (textBox.Text == "")
            {
                label.Content = "Verplicht in te vullen veld!";
                return false;
            }
            else
            {
                label.Content = "";
                return true;
            }
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Groententuin groententuin = new Groententuin();
            groententuin.Show();
            groententuin.Focus();
        }
    }
}
