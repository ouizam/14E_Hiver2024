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
    public class RealisateurService: IRealisateurService
	{
        public readonly IRealisateurRepository _realisateurRepository;

        public RealisateurService()
        {
            _realisateurRepository = new RealisateurRepository();
        }
        public RealisateurService(IRealisateurRepository pRealisateurRepository)
        {
            _realisateurRepository = pRealisateurRepository;
        }

        /// <summary>
        /// Obtiens tous les Réalisateurs contenuent dans la base de donnée.
        /// </summary>
        /// <returns>Une Liste des Réalisateurs</returns>
        public virtual List<Realisateur> ObtenirRealisateurs()
        {
            var realisateurs = new List<Realisateur>();

            try
            {
                realisateurs = _realisateurRepository.ObtenirRealisateurs();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateurs;
        }

        /// <summary>
        /// Obtiens le Réalisateur associé à l'ID passé en paramètre.
        /// </summary>
        /// <param name="idRealisateur">L'ID du Réalisateur</param>
        /// <returns>Un Réalisateur</returns>
        public virtual Realisateur ObtenirUnRealisateur(ObjectId idRealisateur)
        {
            var realisateur = new Realisateur();

            try
            {
                realisateur = _realisateurRepository.ObtenirUnRealisateur(idRealisateur);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateur;
        }
    }
}
