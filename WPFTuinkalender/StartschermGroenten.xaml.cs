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

namespace WPFTuinkalender
{
    /// <summary>
    /// Interaction logic for StartschermGroenten.xaml
    /// </summary>
    public partial class StartschermGroenten : Window
    {
        //public static List<Groente> GekozenGroenten = new List<Groente>();

        public Moestuin GekozenMoestuin { get; set; }
        
        public StartschermGroenten(Moestuin gekozenMoestuin)
        {
            GekozenMoestuin = gekozenMoestuin;
            InitializeComponent();
            labelGekozenMoestuin.Content = GekozenMoestuin.Naam.ToString();
        }

        private void buttonNaarOverzichtGroenten_Click(object sender, RoutedEventArgs e)
        {
            OverzichtGroenten nieuwOverzichtGroenten = new OverzichtGroenten(GekozenMoestuin);
            nieuwOverzichtGroenten.Show();
            nieuwOverzichtGroenten.Focus();
        }

        private void buttonNaarOverzichtKlussenPerGroente_Click(object sender, RoutedEventArgs e)
        {
            OverzichtKlussenPerGroente nieuwOverzichtKlussenPerGroente = new OverzichtKlussenPerGroente(GekozenMoestuin);
            nieuwOverzichtKlussenPerGroente.Show();
            nieuwOverzichtKlussenPerGroente.Focus();
        }

        private void buttonNaarOverzichtKlussenPerMaand_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
