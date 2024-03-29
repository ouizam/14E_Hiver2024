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
    /// Logique d'interaction pour InformationsAbonne.xaml
    /// </summary>
    public partial class InformationsAbonne : Window
    {
        public InformationsAbonne(Abonne abonne)
        {
            InitializeComponent();
            SelectUser(abonne);
        }

        private void SelectUser(Abonne abonne)
        {
            if (abonne != null)
            {
                txtUserName.Text = abonne.Username;
                datePickerDateAdhesion.Text = abonne.DateAdhesion.ToString();
                txtEmail.Text = abonne.Email;
                txtNbProjection.Text=abonne.Reservations.Count.ToString();
               
            }
        }
    }
}
