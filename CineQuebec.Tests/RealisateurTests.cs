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
    public  class RealisateurTests
    {
        [Fact]
        public void ObtenirRealisateurs_Retourne_Liste_Des_Utilisateurs()
        {
            Mock<RealisateurRepository> mockRepoRealisateur = new Mock<RealisateurRepository>();
            List<Realisateur> realisateurs = new List<Realisateur> { new Realisateur(), new Realisateur()};
            mockRepoRealisateur.Setup(x => x.ObtenirRealisateurs()).Returns(realisateurs);
            RealisateurService realisateurService = new RealisateurService(mockRepoRealisateur.Object);


            List<Realisateur> resultat = realisateurService.ObtenirRealisateurs();


            Assert.NotNull(resultat);
            Assert.Equal(realisateurs.Count, resultat.Count);
        }

        [Fact]
        public void ObtenirUnRealisateur_By_Id()
        {
            Mock<RealisateurRepository> mockRepoRealisateur = new Mock<RealisateurRepository>();
            ObjectId idRealisateur = ObjectId.GenerateNewId();
            Realisateur realisateur = new Realisateur() { Id = idRealisateur };
            mockRepoRealisateur.Setup(x => x.ObtenirUnRealisateur(idRealisateur)).Returns(realisateur);
            RealisateurService realisateurService = new RealisateurService(mockRepoRealisateur.Object);

            Realisateur resultat = realisateurService.ObtenirUnRealisateur(idRealisateur);

          
            Assert.NotNull(resultat);
            Assert.Equivalent(resultat, realisateur);
        }
    }
}
