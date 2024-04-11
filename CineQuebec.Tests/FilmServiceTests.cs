using Moq;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.BLL.Services;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CineQuebec.Tests
{
	public class FilmServiceTests
	{
		[Fact]
		public async Task GetAllFilms_Retourne_Liste_Films()
		{
			// Arrange
			Mock<FilmRepository> mockRepo = new Mock<FilmRepository>();

			List<Film> films = new List<Film> { new Film(), new Film()};

			mockRepo.Setup(repo => repo.GetAllFilms()).ReturnsAsync(films);

			FilmService filmService = new FilmService(mockRepo.Object);

			// Act
			List<Film>? result = await filmService.GetAllFilms();

			// Assert
			Assert.NotNull(result);
			Assert.Equal(films.Count, result.Count);
		}

		[Fact]
		public async Task CreateFilm_Retourne_True_Si_Succes()
		{
			// Arrange
			Mock<FilmRepository> mockRepository = new Mock<FilmRepository>();
			Film film = new Film();

			mockRepository.Setup(repo => repo.CreateFilm(film)).ReturnsAsync(true);
			FilmService filmService = new FilmService(mockRepository.Object);

			// Act
			bool result = await filmService.CreateFilm(film);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public async Task DeleteFilm_Retourne_DeleteResultIsAcknowledged_True()
		{
			//Arrange
			Mock<FilmRepository> mockRepo = new Mock<FilmRepository>();
			Film film = new Film();

			mockRepo.Setup(repo => repo.DeleteFilm(film)).ReturnsAsync(new DeleteResult.Acknowledged(1));
			FilmService filmService = new FilmService(mockRepo.Object);

			//Act
			DeleteResult? result = await filmService.DeleteFilm(film);

			//Assert
			Assert.True(result!.IsAcknowledged);
		}

		[Fact]
		public async Task GetAllFilmsAffiche_Retourne_Liste_Film_Affiche()
		{
			// Arrange
			Mock<FilmRepository> mockRepo = new Mock<FilmRepository>();

			List<Film> films = new List<Film>
			{
				new Film() { Nom = "Film 1" },
				new Film() { Nom = "Film 2" }
			};

			List<Projection> projections = new List<Projection>
			{
				new Projection() {DateProjection = new DateTime(2024, 4, 10, 15, 30, 0), Id = ObjectId.GenerateNewId(), NoSalle= 1, IdFilm = films[0].Id, Film = films[0]},
				new Projection() {DateProjection = new DateTime(2024, 6, 13, 15, 30, 0), Id = ObjectId.GenerateNewId(), NoSalle= 1, IdFilm = films[1].Id, Film = films[1]},
			};

			

			mockRepo.Setup(repo => repo.GetAllFilmsAffiche(projections)).ReturnsAsync(new List<Film> { films[1] });
			FilmService filmService = new FilmService(mockRepo.Object);

			// Act
			List<Film>? result = await filmService.GetAllFilmsAffiche(projections);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(1, result?.Count);
		}

		[Fact]
		public async Task UpdateFilm_Retourne_UpdateResult()
		{
			// Arrange
			Mock<FilmRepository> mockRepo = new Mock<FilmRepository>();

			Film film = new Film
			{
				Id = ObjectId.GenerateNewId(),
				Nom = "Nouveau film",
				DateSortieFilm = DateTime.Now,
				EstAffiche = true,
				Categorie = new Categorie { NameCategorie = "Action" },
				Realisateurs = new List<Realisateur> { new Realisateur { NameRealisateur = "Nom Réalisateur" } },
				Acteurs = new List<Acteur> { new Acteur { NameActeur = "Nom Acteur" } }
			};

			UpdateResult updateResult = new UpdateResult.Acknowledged(1, 1, film.Id);
			mockRepo.Setup(repo => repo.UpdateFilm(It.IsAny<Film>())).ReturnsAsync(updateResult);
			FilmService filmService = new FilmService(mockRepo.Object);

			// Act
			UpdateResult? result = await filmService.UpdateFilm(film);

			// Assert
			Assert.True(result!.IsAcknowledged);
			Assert.Equal(film.Id, result.UpsertedId);
		}

	}
}