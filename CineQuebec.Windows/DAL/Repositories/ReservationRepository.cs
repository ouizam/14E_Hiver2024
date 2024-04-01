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
    public class ReservationRepository:BaseRepository
    {
        public ReservationRepository()
        {

        }

        public virtual List<Reservation> ObtenirReservationsAbonne(ObjectId idAbonne)
        {
            var reservations = new List<Reservation>();

            try
            {
                IMongoCollection<Reservation> collection = database.GetCollection<Reservation>("Reservations");
                reservations = collection.Aggregate().ToList().Where(x => x.IdAbonne == idAbonne).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return reservations;
        }
    }
}
