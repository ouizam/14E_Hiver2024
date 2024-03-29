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
    public class PreferenceService
    {
        private PreferenceRepository _preferenceRepository;
        private ActeurService _acteurService;
        private RealisateurService _realisateurService;

        public PreferenceService() 
        {
            _preferenceRepository = new PreferenceRepository();
            _acteurService = new ActeurService();
            _realisateurService = new RealisateurService();
        }

        public Preference ObtenirPreference(ObjectId idPrefernce)
        {
            var preference = new Preference();

            try
            {
                preference = _preferenceRepository.ObtenirePreference(idPrefernce);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return preference;
        }

        public List<Preference> ObtenirPreferencesAbonne(ObjectId idAbonne)
        {
            var preferences = new List<Preference>();

            try
            {
                preferences = _preferenceRepository.ObtenirPreferencesAbonne(idAbonne);
                foreach (var preference in preferences)
                {
                    preference.Realisateur = _realisateurService.ObtenirRealisateur(preference.IdRealisateur);
                    preference.Acteur = _acteurService.ObtenirActeur(preference.IdActeur);
                                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return preferences;
        }
    }
}
