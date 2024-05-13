﻿using CineQuebec.Windows.BLL.Interfaces;
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
		private readonly IReservationService _reservationService;
		private List<Projection>? _filmAffiche;

		public ProjectionsControl(IProjectionService pProjectionService, IFilmService pFilmService, IReservationService pReservationService)
		{
			InitializeComponent();
			_projectionService = pProjectionService;
			_filmService = pFilmService;
			_reservationService = pReservationService;

			ChargerFilms();
		}

		private async void ChargerFilms()
		{
			try
			{
				_filmAffiche = await _projectionService.GetAllProjections();

				if (_filmAffiche != null)
				{
					foreach(Projection proj in _filmAffiche)
					{
						proj.Film =  await _filmService.GetFilmWithProjection(proj);
					}

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
				foreach (Projection film in _filmAffiche)
				{
					if(film.Film is not null)
						lstFilmsAffiche.Items.Add(film);
				}
			}
		}

		private void Click_Projection(object sender, MouseButtonEventArgs e)
		{
			Projection? projection = ((TextBlock)sender).DataContext as Projection;

			ReservationProjectionControl control = new ReservationProjectionControl(_projectionService, _filmService, _reservationService, projection!.Id);

			bool? result = control.ShowDialog();

			if (result == true)
			{
				MessageBox.Show("La réservation a été effectuée avec succès!", "Réservation", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
	}
}
