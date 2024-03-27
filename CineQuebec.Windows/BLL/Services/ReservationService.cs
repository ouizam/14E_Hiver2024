﻿using CineQuebec.Windows.DAL.Data;
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
    public class ReservationService
    {
        private ReservationRepository _reservationRepository;
        private ProjectionService _projectionService;

        public ReservationService()
        {
            _reservationRepository = new ReservationRepository();
            _projectionService = new ProjectionService();
        }

        public List<Reservation> ObtenirReservationsAbonne(ObjectId idAbonne)
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
    }
}