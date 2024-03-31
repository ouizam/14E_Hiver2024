using Moq;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.BLL.Services;
using MongoDB.Driver;

namespace CineQuebec.Tests
{
	public class FilmServiceTests
	{
		[Fact]
		public async Task ChargerListeFilms_Retourne_Liste_Films()
		{
			// Arrange
			Mock<FilmRepository> mockRepo = new Mock<FilmRepository>();

			List<Film> films = new List<Film> { new Film(), new Film()};

			mockRepo.Setup(repo => repo.ChargerListeFilms()).ReturnsAsync(films);

			FilmService filmService = new FilmService(mockRepo.Object);

			// Act
			List<Film>? result = await filmService.ChargerListeFilms();

			// Assert
			Assert.NotNull(result);
			Assert.Equal(films.Count, result.Count);
		}

		[Fact]
		public async Task CreerFilm_Retourne_True_Succes()
		{
			// Arrange
			Mock<FilmRepository> mockRepository = new Mock<FilmRepository>();
			Film film = new Film();

			mockRepository.Setup(repo => repo.CreerFilm(film)).ReturnsAsync(true);
			FilmService filmService = new FilmService(mockRepository.Object);

			// Act
			bool result = await filmService.CreerFilm(film);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public async Task SupprimerFilm_Retourne_DeleteResultIsAcknowledged_True()
		{
			//Arrange
			Mock<FilmRepository> mockRepo = new Mock<FilmRepository>();
			Film film = new Film();

			mockRepo.Setup(repo => repo.SupprimerFilm(film)).ReturnsAsync(new DeleteResult.Acknowledged(1));
			FilmService filmService = new FilmService(mockRepo.Object);

			//Act
			DeleteResult? result = await filmService.SupprimerFilm(film);

			//Assert
			Assert.True(result!.IsAcknowledged);
		}

		[Fact]
		public async Task ChargerListeFilmsAffiche_RetourneListeFilmAffiche()
		{
			// Arrange
			Mock<FilmRepository> mockRepo = new Mock<FilmRepository>();

			List<Film> films = new List<Film>
			{
				new Film() { Nom = "Film 1", EstAffiche = true },
				new Film() { Nom = "Film 2", EstAffiche = false }
			};

			mockRepo.Setup(repo => repo.ChargerListeFilmsAffiche()).ReturnsAsync(new List<Film> { films[0] });
			FilmService filmService = new FilmService(mockRepo.Object);

			// Act
			List<Film>? result = await filmService.ChargerListeFilmsAffiche();

			// Assert
			Assert.NotNull(result);
			Assert.Equal(1, result?.Count);
		}

	}
}