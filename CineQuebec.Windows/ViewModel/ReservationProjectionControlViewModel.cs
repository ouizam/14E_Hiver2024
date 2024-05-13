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
		private Projection _projection;
		public Projection? Projection
		{
			get
			{
				return _projection;
			}
			set { 
				if(value != _projection)
				{
					_projection = value;
					OnPropertyChanged();
				}
			
			}
		}
		

		private IProjectionService _projectionService;
		private IFilmService _filmService;
		private ObjectId _projectionID;

		public ReservationProjectionControlViewModel(IProjectionService projectionService, IFilmService pFilmService, ObjectId pPropjectionId)
		{
			_projectionService = projectionService;
			_filmService = pFilmService;
			_projectionID = pPropjectionId;
		}

		public async void Load(object sender, RoutedEventArgs e)
		{
			Projection projection =  await _projectionService.GetProjectionWithID(_projectionID);

			if (projection == null)
			{
				throw new ProjectionNotFoundException("Cet ID ne correspond à aucune projection!");
			}

			projection.Film =  await _filmService.GetFilmWithProjection(projection);

			Projection = projection;

		}

	}
}
