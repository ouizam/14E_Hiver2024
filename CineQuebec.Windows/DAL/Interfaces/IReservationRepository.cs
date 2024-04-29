using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Interfaces
{
    public interface IReservationRepository
    {
        List<Reservation> ObtenirReservationsAbonne(ObjectId idAbonne);
		Task<Reservation> ReserverPlaceProjection(Projection pProjection, Abonne pAbonne, string pSiege);

	}
}
