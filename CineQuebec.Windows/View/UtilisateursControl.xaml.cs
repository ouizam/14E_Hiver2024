using CineQuebec.Windows.DAL;
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
using System.Windows.Shapes;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour UtilisateursControl.xaml
    /// </summary>
    public partial class UtilisateursControl : Window
    {
        DatabasePeleMele _databasePeleMele = new DatabasePeleMele();

        List<Abonne> _listeDesUsers=new List<Abonne>();
        public UtilisateursControl()
        {
            InitializeComponent();
           
            _listeDesUsers= _databasePeleMele.ReadAbonnes();
            //_databasePeleMele.AddAbonne();
            AfficherListeUtilisateurs();
        }

        private void lstUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstUsers.SelectedItems !=null)
            {
                Abonne abonne = lstUsers.SelectedItems as Abonne;
            }
        }

        private void AfficherListeUtilisateurs()
        {
            lstUsers.Items.Clear();
            foreach (Abonne abonne in _listeDesUsers)
            {
                lstUsers.Items.Add(abonne);
            }   
        }
       

    }
}
