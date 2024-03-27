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

        public Administrateur ConnexionUtilisateur(string pUsername, string pPassword)
        {
            Administrateur utilisateur = new Administrateur();
            try
            {
                utilisateur = _adminRepository.ConnexionUtilisateur(pUsername, pPassword);

                var filter = Builders<Administrateur>.Filter.Eq("Name", pUsername);

                //utilisateur = collection.Find(filter).FirstOrDefault();

                if (utilisateur is null)
                    throw new UtilisateurNotFoundException("Le username est incorrect!");

                if (!utilisateur.Password.Equals(pPassword))
                    throw new UtilisateurNotFoundException("Mot de passe incorrect!");

            }
            catch (UtilisateurNotFoundException ex)
            {
                MessageBox.Show($"Erreur lors de la connexion: {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Impossible d'obtenir la collection {ex.Message}", "Connexion Administrateur");
            }
            return utilisateur;
        }
    }
}
