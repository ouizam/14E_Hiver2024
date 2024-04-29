using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Services
{
    public class CategorieService: ICategorieService
	{
        private readonly ICategorieRepository _categorieRepository;

        //public CategorieService()
        //{
        //    _categorieRepository = new CategorieRepository();
        //}

        public CategorieService(ICategorieRepository pCategorieRepository)
        {
            _categorieRepository = pCategorieRepository;
        }

        /// <summary>
        /// Méthode qui obtient une catégorie selon son id
        /// </summary>
        /// <param name="idCategorie"></param>
        /// <returns></returns>

        public virtual Categorie ObtenirCategorie(ObjectId idCategorie)
        {
            var categorie = new Categorie();

            try
            {
                categorie = _categorieRepository.ObtenirCategorie(idCategorie);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return categorie;
        }

        /// <summary>
        /// Méthode qui obtient la liste de toutes les catégories
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<Categorie>> GetAllCategories()
        {
            try
            {
                return await _categorieRepository.GetAllCategories();
            }catch (Exception ex)
            {
				Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
			}
            return new List<Categorie>();
        }
    }
}
