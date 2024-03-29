using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Services
{
    public class PreferenceRepository:BaseRepository
    {
        public PreferenceRepository() { }

        public Preference ObtenirePreference(ObjectId idPreference)
        {
            var preference = new Preference();

            try
            {
                IMongoCollection<Preference> collection = database.GetCollection<Preference>("Preferences");
                preference = collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idPreference);
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
                IMongoCollection<Preference> collection = database.GetCollection<Preference>("Preferences");
                preferences = collection.Aggregate().ToList().Where(x => x.IdAbonne == idAbonne).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return preferences;
        }
    }
}
