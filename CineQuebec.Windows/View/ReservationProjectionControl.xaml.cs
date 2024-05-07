using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Data;
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
		private IReservationService _reservationService;
		public ReservationProjectionControl(IProjectionService projectionService, IFilmService pFilmService, IReservationService pReservationService, ObjectId pProjectionID)
		{
			InitializeComponent();

			_reservationService = pReservationService;

			_viewModel = new ReservationProjectionControlViewModel(projectionService, pFilmService, pProjectionID);

			DataContext = _viewModel;


			Loaded += _viewModel.Load;

		}

		private void Button_Reserver_Click(object sender, RoutedEventArgs e)
		{
			SaveReservation();
		}

		private async void SaveReservation()
		{
			try
			{
				await _reservationService.ReserverPlaceProjection(_viewModel.Projection!, (Abonne)App.Current.Properties["UserConnect"]!);
			}
			catch
			{
				MessageBox.Show("La réservation a échouée. Veuillez réessayer plus tard.",
						"Réservation non disponible", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
	}
}
