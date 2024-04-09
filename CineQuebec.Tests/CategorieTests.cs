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
    public class CategorieTests
    {
        [Fact]
        public void ObteniCategorie_By_Id()
        {
            Mock<CategorieRepository> repoCategorie = new Mock<CategorieRepository>();
            ObjectId idCategorie = ObjectId.GenerateNewId();
            Categorie categorie = new Categorie { Id = idCategorie };
            repoCategorie.Setup(x => x.ObtenirCategorie(idCategorie)).Returns(categorie);
            CategorieService categorieService = new CategorieService(repoCategorie.Object);


            Categorie resultatAttendu = categorieService.ObtenirCategorie(idCategorie);


            Assert.NotNull(resultatAttendu);
            Assert.Equal(categorie.Id, resultatAttendu.Id);
        }
    }
}
