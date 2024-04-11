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

		public virtual async Task<List<Film>?> GetAllFilms()
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

		public virtual async Task<bool> CreateFilm(Film film)
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

		public virtual async Task<DeleteResult?> DeleteFilm(Film pFilm)
		{
			try
			{
				FilterDefinition<Film> filter = Builders<Film>.Filter.Eq(f => f.Id, pFilm.Id);

				return await _collection.DeleteOneAsync(filter);

				
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur lors de la suppression du film: {ex.Message}");
			}
			return null;
		}

		public virtual async Task<List<Film>?> GetAllFilmsAffiche(List<Projection> projections)
		{
			try
			{
				List<ObjectId> filmIds = projections.Where(p => p.DateProjection > DateTime.Now).Select(p => p.IdFilm).ToList();
				var filter = Builders<Film>.Filter.And(
				Builders<Film>.Filter.In(f => f.Id, filmIds)
				);

				return await _collection.Find(filter).ToListAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Impossible d'obtenir la collection : {ex.Message}");
			}
			return null;
		}

		public virtual async Task<UpdateResult?> UpdateFilm(Film film)
		{
			try
			{
				FilterDefinition<Film> filter = Builders<Film>.Filter.Eq(f => f.Id, film.Id);
				UpdateDefinition<Film> update = Builders<Film>.Update
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
