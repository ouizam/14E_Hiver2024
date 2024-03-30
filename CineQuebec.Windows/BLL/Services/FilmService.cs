using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Driver;
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

		public async Task<DeleteResult?> SupprimerFilm(Film pFilm)
		{
			try
			{
				return await _filmRepo.SupprimerFilm(pFilm);
			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return null;
		}

		public async Task<List<Film>?> ChargerListeFilmsAffiche()
		{
			try
			{
				return await _filmRepo.ChargerListeFilmsAffiche();
			}catch(Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return null;
		}

		public async Task<UpdateResult?> ModifierFilm(Film film)
		{
			try
			{
				return await _filmRepo.ModifierFilm(film);
			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return null;
		}
	}
}
