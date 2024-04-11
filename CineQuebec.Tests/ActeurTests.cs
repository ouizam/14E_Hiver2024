using CineQuebec.Windows.BLL.Services;
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
    public class ActeurTests
    {
        [Fact]
        public void ObtenitActeurs_Retourne_liste_des_acteurs()
        {
            Mock<ActeurRepository> mockRepoActeur  = new Mock<ActeurRepository>();
            List<Acteur> acteurs = new List<Acteur>() { new Acteur() , new Acteur()};
            mockRepoActeur.Setup(x => x.ObtenirActeurs()).Returns(acteurs);
            ActeurService acteurService = new ActeurService(mockRepoActeur.Object);


            List<Acteur> resultat = acteurService.ObtenirActeurs();

            Assert.NotNull(resultat);
            Assert.Equal(acteurs.Count, resultat.Count);
        }

        [Fact]
        public void ObtenirUnActeur_By_Id()
        {
            Mock<ActeurRepository> mockRepoActeur = new Mock<ActeurRepository>();
            ObjectId idActeur = ObjectId.GenerateNewId();
            Acteur acteur = new Acteur() {  Id = idActeur };
            mockRepoActeur.Setup(x => x.ObtenirUnActeur(idActeur)).Returns(acteur);
            ActeurService acteurService = new ActeurService(mockRepoActeur.Object);


            Acteur resultat = acteurService.ObtenirUnActeur(idActeur);

            Assert.NotNull(resultat);
            Assert.Equal(acteur.Id, resultat.Id);
        }

        [Fact]
        public async Task GetAllActeurs_Retourne_Liste_De_Tous_Les_Acteurs()
        {
            Mock<ActeurRepository> mockRepo = new();

            List<Acteur> acteurs = new List<Acteur> 
            { 
                new Acteur("Jean"),
                new Acteur("Simon"),
                new Acteur("Sophie"),
                new Acteur("Sarah"),
                new Acteur("Natalie"),
                new Acteur("Ema"),
                new Acteur("Arthur"),
			};

            mockRepo.Setup(x => x.GetAllActeurs()).ReturnsAsync(acteurs);

            ActeurService acteurService = new(mockRepo.Object);

            List<Acteur>? resultat = await acteurService.GetAllActeurs();

            Assert.NotNull(resultat);
            Assert.Equal(resultat, acteurs);
        }
    }
}
