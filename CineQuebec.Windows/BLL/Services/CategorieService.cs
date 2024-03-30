using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Services
{
    public class CategorieService
    {
        private CategorieRepository _categoreiRepository;
        public CategorieService() 
        {
            _categoreiRepository = new CategorieRepository();
        }

        public Categorie ObteniCategorie(ObjectId idCategorie)
        {
            var categorie = new Categorie();

            try
            {
                categorie = _categoreiRepository.ObtenireCategorie(idCategorie);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return categorie;
        }
    }
}
