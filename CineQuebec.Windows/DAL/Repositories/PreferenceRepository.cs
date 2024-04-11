using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class PreferenceRepository : BaseRepository
    {
        IMongoCollection<Preference> _collection;

        public PreferenceRepository()
        {
            _collection = database.GetCollection<Preference>("Preferences");
        }

        public virtual Preference ObtenirePreference(ObjectId idPreference)
        {
            var preference = new Preference();

            try
            {
                preference = _collection.Aggregate().ToList().FirstOrDefault(x => x.Id == idPreference);
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
                preferences = _collection.Aggregate().ToList().Where(x => x.IdAbonne == idAbonne).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return preferences;
        }
    }
}
