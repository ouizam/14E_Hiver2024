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
    public class AbonneServiceTests
    {
        [Fact]
        public void ObtenirAbonnes_RetourneListeAbonnes()
        {
            //Arrange
            Mock<IAbonneRepository> mockRepo = new Mock<IAbonneRepository>();
            Mock<IReservationRepository> mockReservation = new Mock<IReservationRepository>();
            Mock<IPreferenceRepository> mockPreference = new Mock<IPreferenceRepository>();
            List<Reservation> reservations = new List<Reservation> { new Reservation(), new Reservation() };
            List<Preference> preferences = new List<Preference>() { new Preference(), new Preference() };
            List<Abonne> abonnes = new List<Abonne> { new Abonne { Id = ObjectId.GenerateNewId(), Reservations = reservations, Preferences = preferences }, new Abonne { Id = ObjectId.GenerateNewId(), Reservations = reservations, Preferences = preferences } };
            mockRepo.Setup(repo => repo.ObtenirAbonnes()).Returns(abonnes);
            mockReservation.Setup(x => x.ObtenirReservationsAbonne(It.IsAny<ObjectId>())).Returns(reservations);
            mockPreference.Setup(y => y.ObtenirPreferencesAbonne(It.IsAny<ObjectId>())).Returns(preferences);
            IAbonneService abonneService = new AbonneService(mockRepo.Object, mockReservation.Object, mockPreference.Object);

           
            List<Abonne> resultat = abonneService.ObtenirAbonnes();

         
            Assert.NotNull(resultat);
            Assert.Equal(abonnes.Count, resultat.Count);
            Assert.Equal(abonnes[0].Reservations.Count, resultat[0].Reservations.Count);
            Assert.Equal(abonnes[0].Preferences.Count, resultat[0].Preferences.Count);
        }
    }
}
