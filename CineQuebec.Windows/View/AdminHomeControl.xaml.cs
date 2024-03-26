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
        private List<Film> _listeFilms;

        public AdminHomeControl()
        {
            InitializeComponent();
			// TODO: ALLER CHERCHER LES ABONNEES DANS LA BD
			// TODO: ALLER CHERCHER LES FILMS DANS LA BASE
            // NOTE: JE NE SAIS PAS SI C'EST PERTINENT D'INSTENCIER ICI LES ABONNEES ET LES FILMS
			_listeAbonnes = new List<Abonne>();
            _listeFilms = new List<Film>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UtilisateursControl utilisateursControl = new UtilisateursControl();
            utilisateursControl.Show();
        }

		private void Button_Films_Click(object sender, RoutedEventArgs e)
		{
            // TODO: GERER LE CLICK DU BOUTON VOIR FILMS
            // TODO: FAIRE LE FENETRE POUR AFFICHER LES FILMS
		}
	}
}
