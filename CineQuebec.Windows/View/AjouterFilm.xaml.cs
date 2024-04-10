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
        List<Categorie> _categories;
        public AjouterFilm()
        {
            InitializeComponent();
            _filmService = new FilmService();
            _categorieService = new CategorieService();

            ChargerCategories();
            AfficherCategories();

		}

        private async void ChargerCategories()
        {
            try
            {
                _categories =  await _categorieService.GetCategories();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la récupération des Catégories", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AfficherCategories()
        {
            cmbCategorie.DataContext = _categories;
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
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
            if (string.IsNullOrEmpty(txtNomFilm.Text.ToString().Trim()) || string.IsNullOrEmpty(txtActeurs.Text.ToString().Trim()) || cmbCategorie.SelectedItem is null || string.IsNullOrEmpty(txtRealisateurs.Text.ToString().Trim())
                || dateSortieFilm.SelectedDate is null)
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

				EstAffiche = checkAffiche.IsChecked.GetValueOrDefault(defaultValue: false),

				Categorie = (Categorie)cmbCategorie.SelectedItem
			};

			foreach (string nom in txtActeurs.Text.ToString().Split(','))
			{
				nouveau_film.Acteurs.Add(new Acteur(nom.Trim()));
			}

			foreach (string nom in txtRealisateurs.Text.ToString().Split(","))
			{
				nouveau_film.Realisateurs.Add(new Realisateur(nom.Trim()));
			}

            return nouveau_film;
		}

        private async Task<bool> CreerFilm(Film film)
        {
            if (film is null)
                return false;

            try
            {
                return await _filmService.CreerFilm(film);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de la création", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

		}
    }
}
