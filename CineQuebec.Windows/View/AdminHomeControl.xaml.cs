using CineQuebec.Windows.BLL.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour AdminHomeControl.xaml
    /// </summary>
    public partial class AdminHomeControl : UserControl
    {
        private readonly IAbonneService _abonneService;
        private readonly IFilmService _filmService;
        private readonly IProjectionService _projectionService;
        private readonly ICategorieService _categorieService;
        private readonly IRealisateurService _realisateurService;
        private readonly IActeurService _acteurService;
        public AdminHomeControl(IAbonneService abonneService, IFilmService filmService, IProjectionService projectionService, ICategorieService categorieService,
            IRealisateurService realisateurService, IActeurService acteurService)
        {
            _abonneService = abonneService;
            _filmService = filmService;
            _projectionService = projectionService;
            _categorieService = categorieService;
            _realisateurService = realisateurService;
            _acteurService = acteurService;
            InitializeComponent();
        }

        private void Button_Utilisateurs_Click(object sender, RoutedEventArgs e)
        {
			var utilisateursControl = new UtilisateursControl(_abonneService);
			utilisateursControl.Show(); 
		}

		private void Button_Films_Click(object sender, RoutedEventArgs e)
		{
            new FilmsControl( _filmService,  _projectionService,  _categorieService, _realisateurService, _acteurService).Show();
		}
	}
}
