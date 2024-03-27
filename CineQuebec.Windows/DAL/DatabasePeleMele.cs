using CineQuebec.Windows.DAL.Data;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CineQuebec.Windows.DAL
{
    public class DatabasePeleMele
    {
        private IMongoClient mongoDBClient;
        private IMongoDatabase database;

        public DatabasePeleMele(IMongoClient client = null)
        {
            mongoDBClient = client ?? OuvrirConnexion();
            database = ConnectDatabase();
        }
        private IMongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données " + ex.Message, "Erreur");
            }
            return dbClient;
        }

        private IMongoDatabase ConnectDatabase()
        {
            IMongoDatabase db = null;
            try
            {
                db = mongoDBClient.GetDatabase("TP2DB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données " + ex.Message, "Erreur");
            }
            return db;
        }
    //    public List<Abonne> ReadAbonnes()
    //    {
    //        var abonnes = new List<Abonne>();

    //        try
    //        {
				//IMongoCollection<Abonne> collection = database.GetCollection<Abonne>("Abonnes");
    //            abonnes = collection.Aggregate().ToList();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
    //        }
    //        return abonnes;
    //    }

        public List<Film> ChargerListeFilms()
        {

			List<Film> films = new List<Film>();

			try
			{

				IMongoCollection<Film> collection = database.GetCollection<Film>(name:"Films");
                films = collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Impossible d'obtenir la collection {ex.Message}", "Récupération Films");
            }
            return films;
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
                    
            }catch (UtilisateurNotFoundException ex)
            {
                MessageBox.Show($"Erreur lors de la connexion: {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }catch (Exception ex)
            {
                Console.WriteLine($"Impossible d'obtenir la collection {ex.Message}", "Connexion Administrateur");
            }
            return utilisateur;
        }


        //public void AddAbonne()
        //{
        //    var abonnes = new Abonne
        //    {
        //        DateAdhesion = DateTime.Now,
        //        Username = "Ouiza1",
        //        Email = "ouiz@gmail.com",
        //        Recompenses = new List<Recompense> { new Recompense { Type = new TypeRecompense { nomRecompense = "Ticket gratuit" } } },
        //        Reservations = new List<Reservation> { new Reservation { DateReservation = DateTime.Now, Projection = new Projection { DateProjection = DateTime.Now, NoSalle = 2, Film = null } } },
        //    };
           
        //    try
        //    {
        //        var collection = database.GetCollection <Abonne>("Abonnes");
        //        collection.InsertOne(abonnes);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
        //    }
          
        //}
    }

    public class UtilisateurNotFoundException: Exception
    {
		public UtilisateurNotFoundException(string message = "Utilisateur non trouvé.") : base(message) { }
		public UtilisateurNotFoundException(string message, Exception innerException) : base(message, innerException) { }
	}
}
