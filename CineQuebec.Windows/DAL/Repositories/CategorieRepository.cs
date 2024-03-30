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
        public CategorieRepository() { }

        public Categorie ObtenireCategorie(ObjectId idCategorie)
        {
            var categorie = new Categorie();

            try
            {
                IMongoCollection<Categorie> collection = database.GetCollection<Categorie>("Categories");
                categorie = collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idCategorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return categorie;
        }
    }
}
