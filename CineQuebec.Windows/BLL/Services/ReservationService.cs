using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Interfaces;
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
    public class ReservationService: IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IProjectionService _projectionService;


        public ReservationService(IReservationRepository pReservationRep, IProjectionService pProjecService)
        {
            _reservationRepository = pReservationRep;
            _projectionService = pProjecService;
        }

        /// <summary>
        /// Obtiens les Réservations associées à l'Abonné contenuent dans la base de donnée.
        /// </summary>
        /// <param name="idAbonne">L'ID de l'Abonné</param>
        /// <returns>Une Liste des Réservations</returns>
        public virtual List<Reservation> ObtenirReservationsAbonne(ObjectId idAbonne)
        {
            var reservations = new List<Reservation>();

            try
            {
                reservations = _reservationRepository.ObtenirReservationsAbonne(idAbonne);
                foreach (var reservation in reservations)
                {
                    reservation.Projection = _projectionService.ObtenirProjection(reservation.IdProjection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return reservations;
        }

		public async Task<Reservation?> ReserverPlaceProjection(Projection pProjection, Abonne pAbonne)
		{
            try
            {
                return await _reservationRepository.ReserverPlaceProjection(pProjection, pAbonne);
            }catch (Exception ex)
            {
                Console.WriteLine("Impossible de faire la réservation " + ex.Message, "Erreur");
            }
            return null;
		}
	}
}
