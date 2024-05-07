using CineQuebec.Windows.BLL.Interfaces;
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
    /// Logique d'interaction pour PreferencesAbonne.xaml
    /// </summary>
    public partial class PreferencesAbonne : Window
    {
        private readonly IAbonneService _abonneService;
        private readonly IFilmService _filmService;
        private readonly ICategorieService _categorieService;
        private readonly IRealisateurService _realisateurService;
        private readonly IPreferenceService _preferenceService;

        List<Abonne> _listeDesUsers;
        List<Film>? _listeDesFilms;
        List<Categorie> _listeCategories;
        List<Realisateur> _listeRealisateurs;
        List<Preference> _preferences;
        public PreferencesAbonne(IFilmService filmService, ICategorieService categorieService, IRealisateurService realisateurService, IPreferenceService preferenceService)
        {
            InitializeComponent();
            //_abonneService = abonneService;
            _filmService = filmService;
            _categorieService = categorieService;
            _realisateurService = realisateurService;
            _preferenceService = preferenceService;
            //_listeDesUsers = _abonneService.ObtenirAbonnes();
            _listeDesFilms = _filmService.GetAllFilms().Result;
            _listeCategories = _categorieService.GetAllCategories().Result;
            _listeRealisateurs = _realisateurService.ObtenirRealisateurs();
            var user = App.Current.Properties["UserConnect"] as User;
            _preferences = _preferenceService.ObtenirPreferencesAbonne(user.Id);
            AfficherListeRealisateur();
            AfficherListeFilms();
            AfficherListeCategories();
            AfficherListePreferences();
        }

        private void AfficherListeRealisateur()
        {
            lstRealisateurs.Items.Clear();
            foreach (Realisateur realisateur in _listeRealisateurs)
            {
                lstRealisateurs.Items.Add(realisateur);
            }
        }

        private void AfficherListeFilms()
        {
            lstFilms.Items.Clear();
            foreach (Film film in _listeDesFilms)
            {
                lstFilms.Items.Add(film);
            }
        }
        private void AfficherListeCategories()
        {
            lstCategories.Items.Clear();
            foreach (Categorie categorie in _listeCategories)
            {
                lstCategories.Items.Add(categorie);
            }
        }
        private void AfficherListePreferences()
        {
            lstPrefUser.Items.Clear();
            foreach (Preference preference in _preferences)
            {
                lstPrefUser.Items.Add(preference);
            }
        }


        private void Button_Ajouter_Realisateur_Click(object sender, RoutedEventArgs e)
        {
            if (lstRealisateurs.SelectedItem != null)
            {
                Preference preference = new Preference { IdRealisateur = (lstRealisateurs.SelectedItem as Realisateur).Id };
                _preferenceService.AjouterPreference(preference);
                preference.Realisateur = lstRealisateurs.SelectedItem as Realisateur;
                lstPrefUser.Items.Add(preference);
            }
            else
            {
                MessageBox.Show($"Vous devez selectionner un réalisateur");
            }
        }

        private void lstRealisateurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bouton_Ajouter_Film(object sender, RoutedEventArgs e)
        {
            if (lstFilms.SelectedItem != null)
            {
                Preference preference = new Preference { IdFilm = (lstFilms.SelectedItem as Film).Id };
                _preferenceService.AjouterPreference(preference);
                preference.Film = lstFilms.SelectedItem as Film;
                lstPrefUser.Items.Add(preference);
            }
            else
            {
                MessageBox.Show($"Vous devez selectionner un film");
            }
        }

        private void Button_Ajouter_Categorie(object sender, RoutedEventArgs e)
        {
            if (lstCategories.SelectedItem != null)
            {
                Preference preference = new Preference { IdCategorie = (lstCategories.SelectedItem as Categorie).Id };
                _preferenceService.AjouterPreference(preference);
                preference.Categorie = lstCategories.SelectedItem as Categorie;
                lstPrefUser.Items.Add(preference);
            }
            else
            {
                MessageBox.Show($"Vous devez selectionner une catégorie");
            }
        }
    }
}
