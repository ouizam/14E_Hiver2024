﻿using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Tests
{
    public class ReservationTests
    {
        [Fact]
        public void ObtenirReservationsAbonne_By_Id_Abonne()
        {
            Mock<ReservationRepository> mockRepo = new Mock<ReservationRepository>();
            Mock<ProjectionService> mockProjection = new Mock<ProjectionService>();
           
            ObjectId idAbonne = ObjectId.GenerateNewId();
            ObjectId idProjection = ObjectId.GenerateNewId();
            Projection projection = new Projection { Id = idProjection };
            List<Reservation> reservations = new List<Reservation> { new Reservation { IdAbonne = idAbonne, IdProjection = idProjection }, new Reservation { IdAbonne = idAbonne, IdProjection = idProjection } };

            mockRepo.Setup(x => x.ObtenirReservationsAbonne(idAbonne)).Returns(reservations);
            mockProjection.Setup(y => y.ObtenirProjection(idProjection)).Returns(projection);
            ReservationService reservationService = new ReservationService(mockRepo.Object, mockProjection.Object);

            //act
            List<Reservation> resultat = reservationService.ObtenirReservationsAbonne(idAbonne);

            //Assert
            Assert.NotNull(resultat);
            Assert.Equal(reservations.Count, resultat.Count);
            Assert.Equal(reservations[0].Projection, resultat[0].Projection);
        }
    }
}