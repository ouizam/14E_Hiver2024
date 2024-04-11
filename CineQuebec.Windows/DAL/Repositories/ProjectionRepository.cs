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
    public class ProjectionRepository:BaseRepository
    {
        IMongoCollection<Projection> _collection;

		public ProjectionRepository()
        {
            _collection = database.GetCollection<Projection>("Projections");
		}


        public virtual Projection ObtenirProjection(ObjectId idProjection)
        {
            var projection = new Projection();

            try
            {
                projection = _collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idProjection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return projection;
        }

        public virtual async Task<List<Projection>?> GetAllProjections()
        {
            try
            {
                return await _collection.Aggregate().ToListAsync();
            }catch (Exception ex)
            {
				Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
			}
            return null;
        }
    }
}
