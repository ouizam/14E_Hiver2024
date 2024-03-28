using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CineQuebec.Windows.BLL.Services
{
    public class AdminService
    {
        private AdminRepository _adminRepository;

        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }

        public async Task<Administrateur> ConnexionUtilisateur(string pUsername, string pPassword)
        {
            Administrateur utilisateur = new Administrateur();
            try
            {
                utilisateur = await _adminRepository.ConnexionUtilisateur(pUsername, pPassword);

            }catch (UtilisateurNotFoundException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
				MessageBox.Show($"Erreur lors de la connexion: {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
			}
            return utilisateur;
        }
    }
}
