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
    /// Interaction logic for StartschermMoestuin.xaml
    /// </summary>
    public partial class StartschermMoestuin : Window
    {
        public StartschermMoestuin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource moestuinViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("moestuinViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // moestuinViewSource.Source = [generic data source]

            VulLijstMetMoestuinen();
        }

        private void VulLijstMetMoestuinen()
        {
            CollectionViewSource moestuinViewSource = ((CollectionViewSource)(this.FindResource("moestuinViewSource")));
            var manager = new GroenteManager();
            moestuinViewSource.Source = manager.GetAlleMoestuinen();
        }

        private void buttonVerwijderMoestuin_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxMoestuinen.SelectedItem != null)
            {
                var teVerwijderenMoestuin = (Moestuin)listBoxMoestuinen.SelectedItem;
                var manager = new GroenteManager();
                manager.VerwijderMoestuin(teVerwijderenMoestuin.Id);
                VulLijstMetMoestuinen();
            }
        }

        private void buttonMaakEenNieuweMoestuin_Click(object sender, RoutedEventArgs e)
        {
            if ((textBoxNaam.Text != "") && (textBoxNaam.Text != "tik hier een naam"))
            {
                var manager = new GroenteManager();
                string naam = textBoxNaam.Text.ToString();
                //manager.MaakNieuweMoestuin(naam);     er moet een moestuin worden toegevoegd, geen naam
                VulLijstMetMoestuinen();
            }
        }

        private void buttonNaarOverzichtGroenten_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxMoestuinen.SelectedItem != null)
            {
                var gekozenMoestuin = (Moestuin)listBoxMoestuinen.SelectedItem;
                StartschermGroenten nieuwStartschermGroenten = new StartschermGroenten(gekozenMoestuin);
                nieuwStartschermGroenten.Show();
                nieuwStartschermGroenten.Focus();
            }
        }
    }
}
