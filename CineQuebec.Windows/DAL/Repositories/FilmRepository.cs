using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Repositories
{
	public class FilmRepository:BaseRepository
	{
		IMongoCollection<Film> _collection;
		public FilmRepository()
		{
			_collection = database.GetCollection<Film>(name: "Films");
		}

		public async Task<List<Film>?> ChargerListeFilms()
		{
			try
			{
				return await _collection.Aggregate().ToListAsync<Film>();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Impossible d'obtenir la collection {ex.Message}", "Récupération Films");
			}
			return null;
		}

		public async Task<bool> CreerFilm(Film film)
		{
			try
			{
				await _collection.InsertOneAsync(film);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur lors de la création du film : {ex.Message}");
				return false;
			}
		}

	}
}
