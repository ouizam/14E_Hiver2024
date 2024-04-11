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
    public class RealisateurService
    {
        public RealisateurRepository _realisateurRepository;

        public RealisateurService()
        {
            _realisateurRepository = new RealisateurRepository();
        }
         public RealisateurService(RealisateurRepository pRealisateurRepository)
        {
            _realisateurRepository = pRealisateurRepository;
        }

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
