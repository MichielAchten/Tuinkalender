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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TuinkalenderBL;
using TuinkalenderDA;

namespace WPFTuinkalender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var manager = new GroenteManager();
            //List<Groente> groenten = new List<Groente>();

            //groenten = manager.GetAlleGroenten();
            //foreach (var groente in groenten)
            //{
            //    listBoxGroenten.Items.Add(groente);
            //}

            CollectionViewSource groentenViewSource = ((CollectionViewSource)(this.FindResource("groentenViewSource")));
            var manager = new GroenteManager();
            groentenViewSource.Source = manager.GetAlleGroenten();
        }
    }
}
