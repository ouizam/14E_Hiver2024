using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
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
	/// Logique d'interaction pour ProjectionsControl.xaml
	/// </summary>
	public partial class ProjectionsControl : Window
	{
		private readonly IProjectionService _projectionService;
		private readonly IFilmService _filmService;
		private List<Film>? _filmAffiche;

		public ProjectionsControl(IProjectionService pProjectionService, IFilmService pFilmService)
		{
			InitializeComponent();
			_projectionService = pProjectionService;
			_filmService = pFilmService;

			ChargerFilms();
		}

		private async void ChargerFilms()
		{
			try
			{
				List<Projection>? projections = await _projectionService.GetAllProjections();

				if (projections != null)
				{
					_filmAffiche = await _filmService.GetAllFilmsAffiche(projections!);

					AfficherListeFilmsAffiche();
				}
				else
				{
					MessageBox.Show("Les projections ne sont pas disponibles pour le moment. Veuillez réessayer plus tard.",
						"Projections non disponibles", MessageBoxButton.OK, MessageBoxImage.Information);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Une erreur est survenue", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void AfficherListeFilmsAffiche()
		{
			lstFilmsAffiche.Items.Clear();

			if(_filmAffiche is not null)
			{
				foreach (Film film in _filmAffiche)
				{
					lstFilmsAffiche.Items.Add(film);
				}
			}
		}

		private void Click_Projection(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
