using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Interfaces;
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
        //private readonly IReservationService _reservationService;
        //public ReservationTests(IReservationService reservationService)
        //{
        //    _reservationService = reservationService;
        //}

        [Fact]
        public void ObtenirReservationsAbonne_By_Id_Abonne()
        {
            Mock<IReservationRepository> mockRepo = new Mock<IReservationRepository>();
            Mock<IProjectionService> mockProjection = new Mock<IProjectionService>();           
            ObjectId idAbonne = ObjectId.GenerateNewId();
            ObjectId idProjection = ObjectId.GenerateNewId();
            Projection projection = new Projection { Id = idProjection };
            List<Reservation> reservations = new List<Reservation> { new Reservation { IdAbonne = idAbonne, IdProjection = idProjection }, new Reservation { IdAbonne = idAbonne, IdProjection = idProjection } };

            mockRepo.Setup(x => x.ObtenirReservationsAbonne(idAbonne)).Returns(reservations);
            mockProjection.Setup(y => y.ObtenirProjection(idProjection)).Returns(projection);
            IReservationService reservationService = new ReservationService(mockRepo.Object, mockProjection.Object);

           
            List<Reservation> resultat = reservationService.ObtenirReservationsAbonne(idAbonne);


            Assert.NotNull(resultat);
            Assert.Equal(reservations.Count, resultat.Count);
            Assert.Equal(reservations[0].Projection, resultat[0].Projection);
        }
    }
}
