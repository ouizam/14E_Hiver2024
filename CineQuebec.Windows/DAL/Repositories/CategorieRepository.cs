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
    public class CategorieRepository: BaseRepository
    {

        IMongoCollection<Categorie> _collection;

		public CategorieRepository()
        {
            _collection = database.GetCollection<Categorie>(name: "Categories");
        }

        public virtual Categorie ObtenirCategorie(ObjectId idCategorie)
        {
            var categorie = new Categorie();

            try
            {
                categorie = _collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idCategorie);
            }
            catch (Exception ex)
            {
                
            }
            return categorie;
        }

        public virtual async Task<List<Categorie>> GetCategories()
        {
            try
            {
                return await _collection.Aggregate().ToListAsync();
            }catch (Exception ex)
            {
				Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
			}
            return new List<Categorie>();
        }
    }
}
