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
        public ObservableCollection<Moestuin> moestuinOb = new ObservableCollection<Moestuin>();

        public Groententuin()
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
            //CollectionViewSource moestuinViewSource = ((CollectionViewSource)(this.FindResource("moestuinViewSource")));
            //var manager = new GroenteManager();
            //moestuinViewSource.Source = manager.GetAlleMoestuinen();

            CollectionViewSource moestuinViewSource = ((CollectionViewSource)(this.FindResource("moestuinViewSource")));
            var manager = new GroenteManager();
            moestuinOb = manager.GetAlleMoestuinen();
            moestuinViewSource.Source = moestuinOb;
            
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

        }

        private void listboxMoestuinen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabMoestuinGegevens.Focus();
            
        }
    }
}
