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

		public async Task<List<Film>?> GetFilms()
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

	}
}
