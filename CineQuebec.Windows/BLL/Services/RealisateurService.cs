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

        public List<Realisateur> ReadRealisateurs()
        {
            var realisateurs = new List<Realisateur>();

            try
            {
                realisateurs = _realisateurRepository.ReadRealisateurs();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateurs;
        }

        public virtual Realisateur ObtenirRealisateur(ObjectId idRealisateur)
        {
            var realisateur = new Realisateur();

            try
            {
                realisateur = _realisateurRepository.ObtenireRealisateur(idRealisateur);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return realisateur;
        }
    }
}
