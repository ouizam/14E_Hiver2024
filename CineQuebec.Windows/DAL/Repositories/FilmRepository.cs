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

		public virtual async Task<List<Film>?> ChargerListeFilms()
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

		public virtual async Task<bool> CreerFilm(Film film)
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

		public async Task<DeleteResult?> SupprimerFilm(Film pFilm)
		{
			try
			{
				var filter = Builders<Film>.Filter.Eq(f => f.Id, pFilm.Id);

				return await _collection.DeleteOneAsync(filter);

				
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur lors de la suppression du film: {ex.Message}");
			}
			return null;
		}

		public async Task<List<Film>?> ChargerListeFilmsAffiche()
		{
			try
			{
				return await _collection.Find(Builders<Film>.Filter.Eq(f => f.EstAffiche, true)).ToListAsync<Film>(); ;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Impossible d'obtenir la collection : {ex.Message}");
			}
			return null;
		}

		public async Task<UpdateResult?> ModifierFilm(Film film)
		{
			try
			{
				var filter = Builders<Film>.Filter.Eq(f => f.Id, film.Id);
				var update = Builders<Film>.Update
					.Set(f => f.Nom, film.Nom)
					.Set(f => f.DateSortieFilm, film.DateSortieFilm)
					.Set(f => f.EstAffiche, film.EstAffiche)
					.Set(f => f.Categorie, film.Categorie)
					.Set(f => f.Realisateurs, film.Realisateurs)
					.Set(f => f.Acteurs, film.Acteurs);

				return await _collection.UpdateOneAsync(filter, update);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur lors de la modification du film : {ex.Message}");
			}
			return null;
		}


	}
}
