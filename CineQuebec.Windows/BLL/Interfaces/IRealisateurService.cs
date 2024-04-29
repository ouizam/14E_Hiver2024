using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Interfaces
{
	public interface IRealisateurService
	{
		List<Realisateur> ObtenirRealisateurs();
		Realisateur ObtenirUnRealisateur(ObjectId pRealisateurID);
	}
}
