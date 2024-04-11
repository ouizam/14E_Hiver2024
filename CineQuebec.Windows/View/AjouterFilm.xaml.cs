using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
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
    /// Logique d'interaction pour AjouterFilm.xaml
    /// </summary>
    public partial class AjouterFilm : Window
    {

        FilmService _filmService;
        CategorieService _categorieService;
        RealisateurService _realisateurService;
        ActeurService _acteurService;

        List<Categorie>? _categories;
        List<Realisateur>? _realisateurs;
        List<Acteur>? _acteurs;

        List<Acteur> _checkedActeurs;
        List<Realisateur> _checkedRealisateurs;


		public AjouterFilm()
        {
            InitializeComponent();
            _filmService = new FilmService();
            _categorieService = new();
            _realisateurService = new();
			_acteurService = new();


            _checkedActeurs = new();
            _checkedRealisateurs = new();

			ChargerCategories();
            ChargerRealisateurs();
            ChargerActeurs();
		}

        private async void ChargerCategories()
        {
            try
            {
                _categories =  await _categorieService.GetAllCategories();
				AfficherCategories();
			}
			catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la récupération des Catégories", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ChargerRealisateurs()
        {
            try
            {
                _realisateurs =  _realisateurService.ObtenirRealisateurs();
                AfficherRealisateurs();
			}
			catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la récupération des Realisateurs", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

		private void ChargerActeurs()
        {
            try
            {
                _acteurs =  _acteurService.ObtenirActeurs();
                AfficherActeurs();
			}
			catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la récupération des Acteurs", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }

		private void AfficherCategories()
        {
            cmbCategorie.Items.Clear();
            foreach(Categorie cat in _categories)
            {
                cmbCategorie.Items.Add(cat);
            }
		}

        private void AfficherRealisateurs()
        {
            cmbRealisateurs.Items.Clear();
            cmbRealisateurs.ItemsSource = _realisateurs;
		}

        private void AfficherActeurs()
        {
            cmbActeurs.Items.Clear();
            cmbActeurs.ItemsSource = _acteurs;
        }

		private async void Button_CreationFilm_Click(object sender, RoutedEventArgs e)
		{

            if (ValidationChamps())
            {
                Film film = InitialiserFilm();

                bool reponse = await CreerFilm(film);
                
                if (reponse)
                {
                    this.DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Vous devez inscrire une valeur à tous les champs", "Erreur lors de la création", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            


        }

		private bool ValidationChamps()
		{
			if (string.IsNullOrEmpty(txtNomFilm.Text.Trim()))
				return false;

            if (_checkedActeurs.Count == 0)
                return false;
            if (_checkedRealisateurs.Count == 0)
                return false;

			if (dateSortieFilm.SelectedDate == null)
				return false;

			return true;
		}


		private Film InitialiserFilm()
        {
			Film nouveau_film = new Film
			{
				Acteurs = new List<Acteur>(),
				Realisateurs = new List<Realisateur>(),


				Nom = txtNomFilm.Text.ToString().Trim(),

				DateSortieFilm = dateSortieFilm.SelectedDate!.Value,

				EstAffiche = false,

				Categorie = (Categorie)cmbCategorie.SelectedItem
			};

            nouveau_film.Acteurs = _checkedActeurs;
            nouveau_film.Realisateurs = _checkedRealisateurs;

            return nouveau_film;
		}

        private async Task<bool> CreerFilm(Film film)
        {
            if (film is null)
                return false;

            try
            {
                return await _filmService.CreateFilm(film);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la création", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

		}

		private void CheckBox_Acteurs_Checked(object sender, RoutedEventArgs e)
		{
            Acteur acteur = (Acteur)((CheckBox)sender).DataContext;

			_checkedActeurs.Add(acteur);
		}

		private void CheckBox_Acteurs_Unchecked(object sender, RoutedEventArgs e)
		{
			Acteur acteur = (Acteur)((CheckBox)sender).DataContext;

			_checkedActeurs.Remove(acteur);
		}

		private void CheckBox_Realisateurs_Unchecked(object sender, RoutedEventArgs e)
		{
            Realisateur realisateur = (Realisateur)((CheckBox)sender).DataContext;

            _checkedRealisateurs.Remove(realisateur);
		}

		private void CheckBox_Realisateurs_Checked(object sender, RoutedEventArgs e)
		{
			Realisateur realisateur = (Realisateur)((CheckBox)sender).DataContext;

			_checkedRealisateurs.Add(realisateur);
		}
	}
}
