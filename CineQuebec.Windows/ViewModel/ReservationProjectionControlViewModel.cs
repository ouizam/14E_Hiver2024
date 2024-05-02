using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Exceptions;
using CineQuebec.Windows.DAL.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CineQuebec.Windows.ViewModel
{
	public class ReservationProjectionControlViewModel: ViewModelBase
	{

		public Projection? Projection { get; set; }
		

		private IProjectionService _projectionService;
		private IFilmService _filmService;

		public ReservationProjectionControlViewModel(IProjectionService projectionService, IFilmService pFilmService)
		{
			_projectionService = projectionService;
			_filmService = pFilmService;
		}

		public async Task Load(ObjectId pProjectionID)
		{
			Projection = await _projectionService.GetProjectionWithID(pProjectionID);

			if (Projection == null)
			{
				throw new ProjectionNotFoundException("Cet ID ne correspond à aucune projection!");
			}

			Projection.Film = await _filmService.GetFilmWithProjection(Projection);

		}
	}
}
