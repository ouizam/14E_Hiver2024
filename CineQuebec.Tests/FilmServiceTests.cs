using Moq;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.BLL.Services;

namespace CineQuebec.Tests
{
	public class FilmServiceTests
	{
		[Fact]
		public async Task ChargerListeFilms_RetourneUneListeDeFilms()
		{
			var mockRepo = new Mock<FilmRepository>();

			var films = new List<Film> { new Film(), new Film()};

			mockRepo.Setup(repo => repo.ChargerListeFilms()).ReturnsAsync(films);

			var filmService = new FilmService(mockRepo.Object);

			
			var result = await filmService.ChargerListeFilms();

			Assert.NotNull(result);
			Assert.Equal(films.Count, result.Count);
		}

		[Fact]
		public async Task CreerFilm_RetourneTrueSiSucces()
		{
			// Arrange
			var mockRepository = new Mock<FilmRepository>();
			var film = new Film();
			mockRepository.Setup(repo => repo.CreerFilm(film)).ReturnsAsync(true);
			var filmService = new FilmService(mockRepository.Object);

			// Act
			var result = await filmService.CreerFilm(film);

			// Assert
			Assert.True(result);
		}
	}
}