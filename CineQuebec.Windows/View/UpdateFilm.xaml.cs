using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour UpdateFilm.xaml
    /// </summary>
    public partial class UpdateFilm : Window
    {
        private Film _film;

		FilmService _filmService;
		CategorieService _categorieService;
		RealisateurService _realisateurService;
		ActeurService _acteurService;

		List<Categorie>? _categories;
		List<Realisateur>? _realisateurs;
		List<Acteur>? _acteurs;

		List<Acteur> _checkedActeurs;
		List<Realisateur> _checkedRealisateurs;

		public class RealisateurSelectionne
		{
			public Realisateur Realisateur { get; set; }
			public bool IsSelected { get; set; }
		}

		public class ActeursSelectionne
		{
			public Acteur Acteur { get; set; }
			public bool IsSelected { get; set; }
		}


		public UpdateFilm(Film film)
        {
            InitializeComponent();

            _film = film;

            _filmService = new();
            _categorieService = new();
            _realisateurService = new();
            _acteurService = new();

			_checkedActeurs = new();
			_checkedRealisateurs = new();

			AfficherDetailsFilm();
		}

        private void AfficherDetailsFilm()
        {
            txtNomFilm.Text = _film.Nom;

            dateSortieFilm.SelectedDate = _film.DateSortieFilm;

			ChargerRealisateurs();
			ChargerCategories();
			ChargerActeurs();

		}

		private async void ChargerCategories()
		{
			try
			{
				_categories = await _categorieService.GetAllCategories();
				AfficherCategories();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erreur lors de la récupération des Catégories", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private async void ChargerRealisateurs()
		{
			try
			{
				_realisateurs = await _realisateurService.GetAllRealisateurs();
				AfficherRealisateurs();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erreur lors de la récupération des Realisateurs", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void ChargerActeurs()
		{
			try
			{
				_acteurs = await _acteurService.GetAllActeurs();
				AfficherActeurs();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erreur lors de la récupération des Acteurs", MessageBoxButton.OK, MessageBoxImage.None);
			}
		}

		private void AfficherCategories()
		{
			cmbCategorie.Items.Clear();
			foreach (Categorie cat in _categories!)
			{
				cmbCategorie.Items.Add(cat);
			}
			cmbCategorie.SelectedItem = _film.Categorie;
		}

		private void AfficherRealisateurs()
		{
			cmbRealisateurs.Items.Clear();

			List<RealisateurSelectionne> realisateursSelectionnes = new List<RealisateurSelectionne>();

			foreach (Realisateur realisateur in _realisateurs)
			{
				bool estSelectionne = _film.Realisateurs.Contains(realisateur);

				RealisateurSelectionne realisateurSelectionne = new RealisateurSelectionne
				{
					Realisateur = realisateur,
					IsSelected = estSelectionne
				};

				if (estSelectionne)
					_checkedRealisateurs.Add(realisateur);

				realisateursSelectionnes.Add(realisateurSelectionne);
			}

			cmbRealisateurs.ItemsSource = realisateursSelectionnes;
		}


		private void AfficherActeurs()
		{
			cmbActeurs.Items.Clear();

			List<ActeursSelectionne> acteursSelectionnes = new();

			foreach(Acteur acteur in _acteurs)
			{
				bool estSelectionne = _film.Acteurs.Contains(acteur);

				ActeursSelectionne act = new ActeursSelectionne
				{
					Acteur = acteur,
					IsSelected = estSelectionne
				};

				if(estSelectionne)
					_checkedActeurs.Add(acteur);

				acteursSelectionnes.Add(act);
			}
			cmbActeurs.ItemsSource = acteursSelectionnes;
		}

		private void CheckBox_Realisateurs_Checked(object sender, RoutedEventArgs e)
		{
			RealisateurSelectionne realisateur = (RealisateurSelectionne)((CheckBox)sender).DataContext;

			_checkedRealisateurs.Add(realisateur.Realisateur);
		}

		private void CheckBox_Realisateurs_Unchecked(object sender, RoutedEventArgs e)
		{
			RealisateurSelectionne realisateur = (RealisateurSelectionne)((CheckBox)sender).DataContext;

			_checkedRealisateurs.Remove(realisateur.Realisateur);
		}

		private void CheckBox_Acteurs_Unchecked(object sender, RoutedEventArgs e)
		{
			ActeursSelectionne acteur = (ActeursSelectionne)((CheckBox)sender).DataContext;

			_checkedActeurs.Remove(acteur.Acteur);
		}

		private void CheckBox_Acteurs_Checked(object sender, RoutedEventArgs e)
		{
			ActeursSelectionne acteur = (ActeursSelectionne)((CheckBox)sender).DataContext;

			_checkedActeurs.Add(acteur.Acteur);
		}

		private void Button_UpdateFilm_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult resultat = MessageBox.Show("Voulez-vous vraiment modifier ce film ?", "Modification Film", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

			if(resultat == MessageBoxResult.Yes)
			{
				if (ValidationChamps())
				{
					InitialiserFilm();
					ModifierFilm();

				}
				else
				{
					MessageBox.Show("Vous avez laissé des champs vides!", "Modification Film", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				}
			}
		}

		private bool ValidationChamps()
		{
			if (string.IsNullOrEmpty(txtNomFilm.Text))
				return false;
			if (dateSortieFilm.SelectedDate is null)
				return false;
			if(_checkedActeurs.Count == 0)
				return false;
			if(_checkedRealisateurs.Count == 0)
				return false;
			if (cmbCategorie.SelectedItem == null)
				return false;

			return true;
		}

		private void InitialiserFilm()
		{
			_film.Nom = txtNomFilm.Text;
			_film.DateSortieFilm = dateSortieFilm.SelectedDate!.Value;
			_film.Acteurs = _checkedActeurs;
			_film.Realisateurs = _checkedRealisateurs;
			_film.Categorie = (Categorie)cmbCategorie.SelectedItem;
		}

		private async void ModifierFilm()
		{
			try
			{
				UpdateResult? resultat = await _filmService.UpdateFilm(_film);

				if (resultat!.IsAcknowledged)
					this.DialogResult = true;

			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Erreur lors de la modification", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
