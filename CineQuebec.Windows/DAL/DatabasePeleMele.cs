using CineQuebec.Windows.DAL.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Abonne> ReadAbonnes()
        {
            var abonnes = new List<Abonne>();

            try
            {
                var collection = database.GetCollection<Abonne>("Abonnes");
                abonnes = collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return abonnes;
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
}
