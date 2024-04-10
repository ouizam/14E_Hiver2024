using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using MongoDB.Driver;
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
	/// Logique d'interaction pour FilmsControl.xaml
	/// </summary>
	public partial class FilmsControl : Window
	{
		private FilmService _filmService;
		private ProjectionService _projectionService;

		private List<Film>? _films;
		private List<Film>? _filmAffiche;

		public FilmsControl()
		{
			InitializeComponent();

			_filmService = new FilmService();
			_projectionService = new();

			ChargerFilms();

		}

		private async void ChargerFilms()
		{
			try
			{
				_films = await _filmService.GetAllFilms();

				List<Projection>? projections = await _projectionService.GetAllProjections();
				_filmAffiche = await _filmService.GetAllFilmsAffiche(projections!);

				AfficherListeFilms();
				AfficherListeFilmsAffiche();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,"Une erreur est survenue", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void AfficherListeFilms()
		{
			lstFilms.Items.Clear();

			if (_films is not null)
			{
				foreach (Film film in _films)
				{
					lstFilms.Items.Add(film);
				}
			}
		}

		private void AfficherListeFilmsAffiche()
		{
			lstFilmsAffiche.Items.Clear();

			if(_filmAffiche is not null)
			{
				foreach(Film film in _filmAffiche)
				{
					lstFilmsAffiche.Items.Add(film);
				}
			}
		}

		private void Button_Ajouter_Film(object sender, RoutedEventArgs e)
		{
			AjouterFilm ajouterFilm = new AjouterFilm();

			bool? resultat = ajouterFilm.ShowDialog();

			if (resultat == true)
			{
				ChargerFilms();
			}

		}

		private async void Button_Click_SupprimerFilm(object sender, RoutedEventArgs e)
		{
			// Obtenez le film associé au bouton cliqué
			Film? film = ((Button)sender).DataContext as Film;

			MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce film ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					DeleteResult? reponse = await _filmService.DeleteFilm(pFilm: film!);

					if (reponse!.IsAcknowledged)
						ChargerFilms();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Une erreur c'est produite", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

		}

		private void Button_Click_DetailsFilm(object sender, RoutedEventArgs e)
		{

			Film? filmSelectionnee = ((Button)sender).DataContext as Film;

			InformationsFilm informationsFilm = new InformationsFilm(filmSelectionnee!);
			bool? resultat = informationsFilm.ShowDialog();

			if (resultat == true)
				ChargerFilms();
		}
	}
}
