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
    public class ActeurService
    {
        private ActeurRepository _acteurRepository;

        public ActeurService()
        {
            _acteurRepository = new ActeurRepository();
        }

        public ActeurService(ActeurRepository pActeurRepository)
        {
            _acteurRepository = pActeurRepository;
        }

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
