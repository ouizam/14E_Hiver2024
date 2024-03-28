using CineQuebec.Windows.DAL.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class AdminRepository:BaseRepository
    {
        private IMongoCollection<Administrateur> _collection;
       
       public AdminRepository()
        {
            _collection = database.GetCollection<Administrateur>("Administrateurs");
        }

        public async Task<Administrateur> ConnexionUtilisateur(string pUsername, string pPassword)
        {
            Administrateur? utilisateur = new Administrateur();
            try
            {

                var filter = Builders<Administrateur>.Filter.Eq("Name", pUsername);

                utilisateur = await _collection.Find(filter).FirstOrDefaultAsync();

                if (utilisateur is null)
                    throw new UtilisateurNotFoundException("Le username est incorrect!");

                if (!utilisateur.Password.Equals(pPassword))
                    throw new UtilisateurNotFoundException("Mot de passe incorrect!");

            }catch (UtilisateurNotFoundException  ex){
                utilisateur = null;
				MessageBox.Show($"Erreur lors de la connexion: {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
			}
            catch (Exception ex)
            {
                utilisateur = null;
                Console.WriteLine($"Impossible d'obtenir la collection {ex.Message}", "Connexion Administrateur");
            }

            return utilisateur;
        }

    }
}
