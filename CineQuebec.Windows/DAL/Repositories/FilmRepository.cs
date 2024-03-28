using CineQuebec.Windows.DAL.Data;
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

		public async Task<List<Film>> ChargerListeFilms()
		{

			List<Film> films = new List<Film>();

			try
			{
				films = await _collection.Aggregate().ToListAsync<Film>();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Impossible d'obtenir la collection {ex.Message}", "Récupération Films");
			}
			return films;
		}
	}
}
