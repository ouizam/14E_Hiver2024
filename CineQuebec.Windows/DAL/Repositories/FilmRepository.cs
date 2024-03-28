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
		public FilmRepository() { }

		public List<Film> ChargerListeFilms()
		{

			List<Film> films = new List<Film>();

			try
			{

				IMongoCollection<Film> collection = database.GetCollection<Film>(name: "Films");
				films = collection.Aggregate().ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Impossible d'obtenir la collection {ex.Message}", "Récupération Films");
			}
			return films;
		}
	}
}
