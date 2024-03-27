﻿using CineQuebec.Windows.DAL.Data;
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
       
       public AdminRepository()
        {

        }

        public Administrateur ConnexionUtilisateur(string pUsername, string pPassword)
        {
            Administrateur utilisateur = new Administrateur();
            try
            {
                IMongoCollection<Administrateur> collection = database.GetCollection<Administrateur>("Administrateurs");

                var filter = Builders<Administrateur>.Filter.Eq("Name", pUsername);

                utilisateur = collection.Find(filter).FirstOrDefault();

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