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
        IMongoCollection<Reservation> _collection;

        public ReservationRepository()
        {
            _collection = database.GetCollection<Reservation>("Reservations");
		}

        /// <summary>
        /// Obtiens les Réservations associés à un Abonné grâce à son ID passé en paramètre.
        /// </summary>
        /// <param name="idAbonne">L'ID de l'Abonné</param>
        /// <returns>Une Liste des Réservation</returns>
        public virtual List<Reservation> ObtenirReservationsAbonne(ObjectId idAbonne)
        {
            var reservations = new List<Reservation>();

            try
            {
                reservations = _collection.Aggregate().ToList().Where(x => x.IdAbonne == idAbonne).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return reservations;
        }
    }
}
