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

		public FilmService(FilmRepository pFilmRepo)
		{
			_filmRepo = pFilmRepo;
		}

		public async Task<List<Film>?> GetAllFilms()
		{
			try
			{

				return await _filmRepo.GetAllFilms();

			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return null;
		}

		public async Task<bool> CreateFilm(Film film)
		{
			try
			{
				return await _filmRepo.CreateFilm(film);
			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return false;
		}

		public async Task<DeleteResult?> DeleteFilm(Film pFilm)
		{
			try
			{
				return await _filmRepo.DeleteFilm(pFilm);
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

		public async Task<UpdateResult?> UpdateFilm(Film film)
		{
			try
			{
				return await _filmRepo.UpdateFilm(film);
			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return null;
		}
	}
}
