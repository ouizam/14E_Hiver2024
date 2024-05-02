using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Exceptions;
using CineQuebec.Windows.ViewModel;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CineQuebec.Windows.View
{
	/// <summary>
	/// Logique d'interaction pour ReservationProjectionControl.xaml
	/// </summary>
	public partial class ReservationProjectionControl : Window
	{

		private ReservationProjectionControlViewModel _viewModel;
		public ReservationProjectionControl(IProjectionService projectionService, IFilmService pFilmService, ObjectId pProjectionID)
		{
			InitializeComponent();

			_viewModel = new ReservationProjectionControlViewModel(projectionService, pFilmService);

			DataContext = _viewModel;


			Loaded += async (sender, e) =>
			{
				await LoadProjection(pProjectionID);
			};


		}

		private async Task LoadProjection(ObjectId pProjectionID)
		{
			try
			{
				await _viewModel.Load(pProjectionID);
			}
			catch (ProjectionNotFoundException ex)
			{
				Console.WriteLine("Projection non trouvée : " + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erreur lors du chargement de la projection : " + ex.Message);
			}
		}
	}
}
