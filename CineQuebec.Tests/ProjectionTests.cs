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
    public class ProjectionTests
    {
        [Fact]
        public void ObtenirProjection_By_Id()
        {
            Mock<IProjectionRepository> mockRepo = new Mock<IProjectionRepository>();
            ObjectId idProjection = ObjectId.GenerateNewId();
            Projection projection = new Projection { Id = idProjection };
            mockRepo.Setup(y => y.ObtenirProjection(idProjection)).Returns(projection);
            IProjectionService projectionService = new ProjectionService(mockRepo.Object);

           
            Projection resultat = projectionService.ObtenirProjection(idProjection);

           
            Assert.NotNull(resultat);
            Assert.Equal(projection.Id, resultat.Id);
        }

        [Fact]
        public async Task GetAllProjections_Retourne_Liste_Des_Projections()
        {
            Mock<ProjectionRepository> mockRepo = new();

            List<Projection> projections = new List<Projection>
            {
                new Projection { Id = ObjectId.GenerateNewId(), NoSalle=1 },
                new Projection { Id = ObjectId.GenerateNewId(), NoSalle=2 },
                new Projection { Id = ObjectId.GenerateNewId(), NoSalle=3 },
                new Projection { Id = ObjectId.GenerateNewId(), NoSalle=4 },
                new Projection { Id = ObjectId.GenerateNewId(), NoSalle=5 },
			};

            mockRepo.Setup(x => x.GetAllProjections()).ReturnsAsync(projections);

			IProjectionService projectionService = new ProjectionService(mockRepo.Object);

            List<Projection>? resultat = await projectionService.GetAllProjections();


            Assert.NotNull(resultat);
            Assert.Equal(resultat, projections);
        }

    }
}
