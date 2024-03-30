using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Logique d'interaction pour InformationsFilm.xaml
	/// </summary>
	public partial class InformationsFilm : Window
	{
		private Film? _film;
		private FilmService _filmService;
		public InformationsFilm(Film film)
		{
			InitializeComponent();
			_film = film;
			_filmService = new FilmService();

			if(_film is not null)
				AfficherInformations();
		}

		private void AfficherInformations()
		{
			txtNomFilm.Text = _film!.Nom;
			txtRealisateurs.Text = string.Join(", ", _film.Realisateurs);
			txtActeurs.Text = string.Join(", ", _film.Acteurs);
			txtCategorie.Text = _film.Categorie.ToString();

			if (_film.EstAffiche)
				checkAffiche.IsChecked = true;

			dateSortieFilm.Text = _film.DateSortieFilm.ToShortDateString();
		}

	}
}
