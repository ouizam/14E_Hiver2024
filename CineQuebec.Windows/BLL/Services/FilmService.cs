﻿using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Services
{
	public class FilmService: IFilmService
	{
		private readonly IFilmRepository _filmRepo;

		//public FilmService()
		//{
		//	_filmRepo = new FilmRepository();
		//}

		public FilmService(IFilmRepository pFilmRepo)
		{
			_filmRepo = pFilmRepo;
		}

		/// <summary>
		/// Méthode qui retourne la liste de tous les films
		/// </summary>
		/// <returns></returns>
		public async Task<List<Film>?> GetAllFilms()
		{
			try
			{

				return await _filmRepo.GetAllFilms();

			}catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
            return new List<Film>();
        }

		/// <summary>
		/// Méthode qui crée un film dans la base de donnée
		/// </summary>
		/// <param name="film"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Méthode qui supprime un film dans la base de donnée
		/// </summary>
		/// <param name="pFilm"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Méthode qui retourne la liste des films qui sont a l'affiche
		/// </summary>
		/// <param name="projections"></param>
		/// <returns></returns>
		public async Task<List<Film>?> GetAllFilmsAffiche(List<Projection> projections)
		{
			try
			{
				return await _filmRepo.GetAllFilmsAffiche(projections);
			}catch(Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return null;
		}

		/// <summary>
		/// Méthode qui médifie un film
		/// </summary>
		/// <param name="film"></param>
		/// <returns></returns>
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
