using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Interfaces
{
	public interface IPreferenceService
	{
		Preference ObtenirPreference(ObjectId pPreferenceID);
		List<Preference> ObtenirPreferencesAbonne(ObjectId pAbonneID);
		bool AjouterPreference(Preference preference);

    }
}
