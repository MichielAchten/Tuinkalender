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

        private void buttonNaarOverzichtGroenten_Click(object sender, RoutedEventArgs e)
        {
            if ((textBoxNaam.Text != "") && (textBoxNaam.Text != "tik hier een naam"))
            {
                var manager = new GroenteManager();
                string naam = textBoxNaam.Text.ToString();
                manager.MaakNieuweMoestuin(naam);
            }
        }
    }
}
