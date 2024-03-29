using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class ActeurRepository: BaseRepository
    {
        public ActeurRepository() { }


        public List<Acteur> ReadActeurs()
        {
            var acteurs = new List<Acteur>();

            try
            {
                IMongoCollection<Acteur> collection = database.GetCollection<Acteur>("Acteurs");
                acteurs = collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return acteurs;
        }

        public Acteur ObtenireActeur(ObjectId idActeur)
        {
            var acteur = new Acteur();

            try
            {
                IMongoCollection<Acteur> collection = database.GetCollection<Acteur>("Acteurs");
                acteur = collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idActeur);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return acteur;
        }
    }
}
