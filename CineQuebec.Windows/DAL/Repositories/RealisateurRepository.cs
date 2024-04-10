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
        IMongoCollection<Realisateur> _collection;
        public RealisateurRepository()
        { 
            _collection = database.GetCollection<Realisateur>("Realisateurs");
		}

        public virtual List<Realisateur> ObtenirRealisateurs()
        {
            var realisateurs = new List<Realisateur>();

            try
            {
                realisateurs = _collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateurs;
        }

        public virtual Realisateur ObtenirUnRealisateur(ObjectId IdRealisateur)
        {
            var realisateur = new Realisateur();

            try
            {
                realisateur = _collection.Aggregate().ToList().FirstOrDefault(x => x.Id == IdRealisateur);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateur;
        }

        public virtual async Task<List<Realisateur>?> GetAllRealisateurs()
        {
            try
            {
                return await _collection.Aggregate().ToListAsync();
            }catch(Exception ex){
				Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
			}
            return null;
        }
    }
}
