using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Services
{
	public class FilmService
	{
		private FilmRepository _filmRepo;

		public FilmService()
		{
			_filmRepo = new FilmRepository();
		}

		public async Task<List<Film>?> ChargerListeFilms()
		{
			try
			{

				return await _filmRepo.ChargerListeFilms();

			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return null;
		}

		public async Task<bool> CreerFilm(Film film)
		{
			try
			{
				return await _filmRepo.CreerFilm(film);
			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return false;
		}
	}
}
