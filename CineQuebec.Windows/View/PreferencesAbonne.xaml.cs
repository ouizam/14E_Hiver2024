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
            AfficherListeRealisateur();
            AfficherListeFilms();
            AfficherListeCategories();
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
            foreach (Categorie Categorie in _listeCategories)
            {
                lstCategories.Items.Add(Categorie);
            }
        }



        private void Button_Ajouter_Realisateur_Click(object sender, RoutedEventArgs e)
        {
            if (lstRealisateurs.SelectedItems != null)
            {
                Preference preference = new Preference { IdRealisateur = (lstRealisateurs.SelectedItem as Realisateur).Id };
                _preferenceService.AjouterPreference(preference);
            }
            else
            {
                MessageBox.Show($"Vous devez selectionner un réalisateur");
            }
        }

        private void lstRealisateurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
