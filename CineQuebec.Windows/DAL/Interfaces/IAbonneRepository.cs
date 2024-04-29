using CineQuebec.Windows.DAL.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Interfaces
{
    public interface IAbonneRepository
    {
		Task<UpdateResult> AddReservation(Abonne pAbonne, Reservation pReservation);
		List<Abonne> ObtenirAbonnes();
    }
}
