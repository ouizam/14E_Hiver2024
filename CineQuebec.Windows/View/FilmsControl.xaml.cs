using CineQuebec.Windows.BLL.Interfaces;
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
		private IFilmService _filmService;
		private IProjectionService _projectionService;
		private ICategorieService _categorieService;
		private IRealisateurService _realisateurService;
		private IActeurService _acteurService;

		private List<Film>? _films;
		private List<Film>? _filmAffiche;

		public FilmsControl(IFilmService filmService, IProjectionService projectionService, ICategorieService categorieService, IRealisateurService realisateurService, IActeurService acteurService)
		{
			InitializeComponent();

			_filmService = filmService;
			_projectionService = projectionService;
			_categorieService = categorieService;
			_realisateurService = realisateurService;
			_acteurService = acteurService;
            ChargerFilms();

		}

		private async void ChargerFilms()
		{
			try
			{
				_films = await _filmService.GetAllFilms();

				List<Projection>? projections = await _projectionService.GetAllProjections();
				if (projections != null)
				{
                    _filmAffiche = await _filmService.GetAllFilmsAffiche(projections!);

                    AfficherListeFilms();
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

		private void Button_Ajouter_Film_Formulaire(object sender, RoutedEventArgs e)
		{
			AjouterFilm ajouterFilm = new AjouterFilm( _filmService,  _categorieService,  _realisateurService, _acteurService );

			bool? resultat = ajouterFilm.ShowDialog();

			if (resultat == true)
			{
				ChargerFilms();
			}

		}

		private async void Button_SupprimerFilm_Click(object sender, RoutedEventArgs e)
		{
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

		private void Button_DetailsFilm_Click(object sender, RoutedEventArgs e)
		{

			Film? filmSelectionnee = ((Button)sender).DataContext as Film;

			InformationsFilm informationsFilm = new InformationsFilm(filmSelectionnee!, _filmService);
			bool? resultat = informationsFilm.ShowDialog();

			if (resultat == true)
				ChargerFilms();
		}

		private void Button_UpdateFilm_Click(object sender, RoutedEventArgs e)
		{
			Film? filmSelectionnee = ((Button)sender).DataContext as Film;

			UpdateFilm updateFilm = new UpdateFilm(filmSelectionnee!,  _filmService,  _categorieService,  _realisateurService,  _acteurService);
			bool? resultat = updateFilm.ShowDialog();

			if (resultat == true)
				ChargerFilms();
        }
    }
}
