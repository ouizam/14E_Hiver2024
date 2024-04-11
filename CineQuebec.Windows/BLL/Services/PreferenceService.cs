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
        private CategorieService _categorieService;

        public PreferenceService() 
        {
            _preferenceRepository = new PreferenceRepository();
            _acteurService = new ActeurService();
            _realisateurService = new RealisateurService();
            _categorieService = new CategorieService();
        }
        public PreferenceService(PreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;        
        }
        public PreferenceService(PreferenceRepository preferenceRepository, ActeurService acteurService, RealisateurService realisateurService, CategorieService categorieService)
        {
            _preferenceRepository = preferenceRepository;
            _acteurService = acteurService;
            _realisateurService = realisateurService;
            _categorieService = categorieService;
        }
        public virtual Preference ObtenirPreference(ObjectId idPrefernce)
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

        public virtual List<Preference> ObtenirPreferencesAbonne(ObjectId idAbonne)
        {
            var preferences = new List<Preference>();

            try
            {
                preferences = _preferenceRepository.ObtenirPreferencesAbonne(idAbonne);
                foreach (var preference in preferences)
                {
                    preference.Realisateur = _realisateurService.ObtenirUnRealisateur(preference.IdRealisateur);
                    preference.Acteur = _acteurService.ObtenirUnActeur(preference.IdActeur);
                    preference.Categorie = _categorieService.ObtenirCategorie(preference.IdCategorie);
                                  
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
