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
    public class ActeurService: IActeurService
	{
        private readonly IActeurRepository _acteurRepository;

        public ActeurService()
        {
            _acteurRepository = new ActeurRepository();
        }

        public ActeurService(IActeurRepository pActeurRepository)
        {
            _acteurRepository = pActeurRepository;
        }
        /// <summary>
        /// Méthode qui récupère tous les acteurs sous form d'une liste
        /// </summary>
        /// <returns></returns>
        public List<Acteur> ObtenirActeurs()
        {
            var acteurs = new List<Acteur>();

            try
            {
                acteurs = _acteurRepository.ObtenirActeurs();
              

            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return acteurs;
        }
        /// <summary>
        /// Méthode qui return un acteuer selon son id d'acteur
        /// </summary>
        /// <param name="idActeur"></param>
        /// <returns></returns>
        public virtual Acteur ObtenirUnActeur(ObjectId idActeur)
        {
            var acteur = new Acteur();

            try
            {
                acteur = _acteurRepository.ObtenirUnActeur(idActeur);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return acteur;
        }

    }
}
