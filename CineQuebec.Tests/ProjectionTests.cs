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
    public class ProjectionTests
    {
        [Fact]
        public void ObtenirProjection_By_Id_Projection()
        {
            Mock<ProjectionRepository> mockRepo = new Mock<ProjectionRepository>();
            ObjectId idProjection = ObjectId.GenerateNewId();
            Projection projection = new Projection { Id = idProjection };
            mockRepo.Setup(y => y.ObtenirProjection(idProjection)).Returns(projection);
            ProjectionService projectionService = new ProjectionService(mockRepo.Object);

            //act
            Projection resultat = projectionService.ObtenirProjection(idProjection);

            //Assert
            Assert.NotNull(resultat);
            Assert.Equal(projection.Id, resultat.Id);
        }

    }
}
