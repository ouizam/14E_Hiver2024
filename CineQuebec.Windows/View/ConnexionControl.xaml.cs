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

namespace CineQuebec.Windows.View
{
	/// <summary>
	/// Logique d'interaction pour ConnexionControl.xaml
	/// </summary>
    /// 
	public partial class ConnexionControl : UserControl
    {

		private AdminService _adminService;

		public ConnexionControl()
        {
            InitializeComponent();
            _adminService = new AdminService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTXT.Text.ToString();
            string password = passwordTXT.Text.ToString();

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				MessageBox.Show("Veuillez entrer un nom d'utilisateur et un mot de passe.", "Erreur lors de la connexion", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
			{
				Administrateur admin = await _adminService.ConnexionUtilisateur(username, password);

                if (admin != null)
                {
					((MainWindow)Application.Current.MainWindow).AdminHomeControl();
				}
			} 
        }
    }
}
