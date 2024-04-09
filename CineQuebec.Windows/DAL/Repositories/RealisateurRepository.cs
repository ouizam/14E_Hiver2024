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
    public class RealisateurRepository:BaseRepository
    {
        public RealisateurRepository() { }

        public virtual List<Realisateur> ObtenirRealisateurs()
        {
            var realisateurs = new List<Realisateur>();

            try
            {
                IMongoCollection<Realisateur> collection = database.GetCollection<Realisateur>("Realisateurs");
                realisateurs = collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateurs;
        }

        public virtual Realisateur ObtenireUnRealisateur(ObjectId IdRealisateur)
        {
            var realisateur = new Realisateur();

            try
            {
                IMongoCollection<Realisateur> collection = database.GetCollection<Realisateur>("Realisateurs");
                realisateur = collection.Aggregate().ToList().FirstOrDefault(x => x.Id == IdRealisateur);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateur;
        }
    }
}
