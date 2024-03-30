﻿using CineQuebec.Windows.BLL.Services;
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

		private async void ModifierFilmButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				InitialiserFilm();
				UpdateResult? reponse = await _filmService.ModifierFilm(_film!);

				if (reponse!.IsAcknowledged)
					this.DialogResult = true;

			}catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Une erreur c'est produite", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void InitialiserFilm()
		{
			_film!.Nom = txtNomFilm.Text.ToString().Trim();
			_film.Categorie.NameCategorie = txtCategorie.Text.ToString().Trim();
			_film.DateSortieFilm = dateSortieFilm.SelectedDate!.Value;

			if (checkAffiche.IsChecked == true)
				_film.EstAffiche = true;
			else
				_film.EstAffiche = false;


			_film.Realisateurs.Clear();
			_film.Acteurs.Clear();

			foreach (string nom in txtRealisateurs.Text.Split(","))
			{
				_film.Realisateurs.Add(new Realisateur(nom.Trim()));
			}

			foreach (string nom in txtActeurs.Text.Split(","))
			{
				_film.Acteurs.Add(new Acteur(nom.Trim()));
			}
		}
    }
}
