using CineQuebec.Windows.DAL;
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
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.BLL.Services;
using System.Text.RegularExpressions;

namespace CineQuebec.Windows.View
{
	/// <summary>
	/// Logique d'interaction pour ConnexionControl.xaml
	/// </summary>
    /// 
	public partial class ConnexionControl : UserControl
    {

		private AdminService _adminService;
        private const int NB_MIN_USER = 2;
		public ConnexionControl()
        {
            InitializeComponent();
            _adminService = new AdminService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            string username = usernameTXT.Text.ToString();
            string password = passwordTXT.Password.ToString();
		
            if(ValiderConnexion(username, password))
			{
				Administrateur? admin = await _adminService.ConnexionUtilisateur(username, password);

                if (admin != null)
                {
					((MainWindow)Application.Current.MainWindow).AdminHomeControl();
				}
			} 
        }

        public bool ValiderConnexion(string pUsername, string pPassword)
        {
            Regex rxPassword = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@#$%^&+=])(?=.*[^\\w\\d\\s]).{4,}$");
            bool estValid = true;
            string message = "";
            if (string.IsNullOrWhiteSpace(pUsername) || pUsername.Length < NB_MIN_USER)
            {
                estValid = false;
                message += "Le nom d'utilisateur n'est pas valide, il doit y avoir au moins deux caractères\n";
            }
            if (string.IsNullOrWhiteSpace(pPassword) && !rxPassword.IsMatch(pPassword))
            {
                message += "Le mot de passe n'est pas valide, il doit y avoir au moins une lettre majuscule, une minuscule, un chiffre, un caractère spécial et minimum 8 caractères sans espace vide\n";
                estValid = false;
            }
            if (message != "")
            {
                MessageBox.Show(message, "Erreur lors de la connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return estValid;
        }
    }
}
