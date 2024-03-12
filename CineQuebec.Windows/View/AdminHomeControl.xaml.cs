using CineQuebec.Windows.DAL.Data;
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

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour AdminHomeControl.xaml
    /// </summary>
    public partial class AdminHomeControl : UserControl
    {
        private List<Abonne> _listeAbonnes;

        public AdminHomeControl()
        {
            InitializeComponent();
            _listeAbonnes = new List<Abonne>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UtilisateursControl utilisateursControl = new UtilisateursControl();
            utilisateursControl.Show();
        }
        
    }
}
