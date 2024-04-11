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
        IMongoCollection<Acteur> _collection;


		public ActeurRepository() 
        {
            _collection = database.GetCollection<Acteur>("Acteurs");
		}


        public virtual List<Acteur> ObtenirActeurs()
        {
            var acteurs = new List<Acteur>();

            try
            {
                acteurs = _collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return acteurs;
        }

        public virtual Acteur ObtenirUnActeur(ObjectId idActeur)
        {
            var acteur = new Acteur();

            try
            {
                acteur = _collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idActeur);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return acteur;
        }

    }
}
