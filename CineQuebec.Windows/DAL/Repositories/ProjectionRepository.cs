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
        public ProjectionRepository() { }


        public Projection ObtenirProjection(ObjectId idProjection)
        {
            var projection = new Projection();

            try
            {
                IMongoCollection<Projection> collection = database.GetCollection<Projection>("Projections");
                projection = collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idProjection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return projection;
        }
    }
}
