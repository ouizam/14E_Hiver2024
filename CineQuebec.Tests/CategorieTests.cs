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
    public class CategorieTests
    {
        [Fact]
        public void ObteniCategorie_By_Id()
        {
			Mock<ICategorieRepository> repoCategorie = new Mock<ICategorieRepository>();
            ObjectId idCategorie = ObjectId.GenerateNewId();
            Categorie categorie = new Categorie { Id = idCategorie };
            repoCategorie.Setup(x => x.ObtenirCategorie(idCategorie)).Returns(categorie);
            ICategorieService categorieService = new CategorieService(repoCategorie.Object);


            Categorie resultatAttendu = categorieService.ObtenirCategorie(idCategorie);


            Assert.NotNull(resultatAttendu);
            Assert.Equal(categorie.Id, resultatAttendu.Id);
        }

        [Fact]
        public async Task GetAllCategories_Retourne_Liste_Des_Categories()
        {
            Mock<ICategorieRepository> mockRep = new();

            List<Categorie> categories = new List<Categorie>
            {
                new Categorie() {NameCategorie="Action"},
                new Categorie() {NameCategorie="Aventure"},
                new Categorie() {NameCategorie="Science Fiction"},
                new Categorie() {NameCategorie="Documentaire"},
                new Categorie() {NameCategorie="Drame"},
			};

            mockRep.Setup(x => x.GetAllCategories()).ReturnsAsync(categories);

			ICategorieService categorieService = new CategorieService(mockRep.Object);

            List<Categorie>? resultat = await categorieService.GetAllCategories();

            Assert.NotNull(resultat);
            Assert.Equal(resultat, categories);
        }
    }
}
