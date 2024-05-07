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
    public class ActeurServiceTests
    {

        [Fact]
        public void ObtenitActeurs_Retourne_liste_des_acteurs()
        {
            Mock<IActeurRepository> mockRepoActeur  = new Mock<IActeurRepository>();
            List<Acteur> acteurs = new List<Acteur>() { new Acteur() , new Acteur()};
            mockRepoActeur.Setup(x => x.ObtenirActeurs()).Returns(acteurs);
           var acteurService = new ActeurService(mockRepoActeur.Object);


            List<Acteur> resultat = acteurService.ObtenirActeurs();

            Assert.NotNull(resultat);
            Assert.Equal(acteurs.Count, resultat.Count);
        }

        [Fact]
        public void ObtenirUnActeur_By_Id()
        {
            Mock<IActeurRepository> mockRepoActeur = new Mock<IActeurRepository>();
            ObjectId idActeur = ObjectId.GenerateNewId();
            Acteur acteur = new Acteur() {  Id = idActeur };
            mockRepoActeur.Setup(x => x.ObtenirUnActeur(idActeur)).Returns(acteur);
            IActeurService acteurService = new ActeurService(mockRepoActeur.Object);


            Acteur resultat = acteurService.ObtenirUnActeur(idActeur);

            Assert.NotNull(resultat);
            Assert.Equal(acteur.Id, resultat.Id);
        }
    }
}
