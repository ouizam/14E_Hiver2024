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
	/// Logique d'interaction pour FilmsControl.xaml
	/// </summary>
	public partial class FilmsControl : Window
	{
		private FilmService _filmService;

		private List<Film>? _films;
		public FilmsControl()
		{
			InitializeComponent();

			_filmService = new FilmService();

			ChargerFilms();

		}

		private void lstFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

			if(lstFilms.SelectedItems != null)
			{
				Film? filmSelectionnee = lstFilms.SelectedItem as Film;

				InformationsFilm informationsFilm = new InformationsFilm(filmSelectionnee!);
				informationsFilm.Show();
			}

        }

		private async void ChargerFilms()
		{
			try
			{
				_films = await _filmService.ChargerListeFilms();
				AfficherListeFilms();

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

		private void Button_Ajouter_Film(object sender, RoutedEventArgs e)
		{
			AjouterFilm ajouterFilm = new AjouterFilm();

			bool? resultat = ajouterFilm.ShowDialog();

			if (resultat == true)
			{
				MessageBox.Show("Le film a bien été ajouté", "Ajout Film", MessageBoxButton.OK, MessageBoxImage.Information);
				ChargerFilms();
			}

		}
    }
}
