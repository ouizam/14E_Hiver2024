using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CineQuebec.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAbonneService _abonneService;
        private readonly IUserService _adminService;
        private IFilmService _filmService;
        private IProjectionService _projectionService;
        private ICategorieService _categorieService;
        private IRealisateurService _realisateurService;
        private IActeurService _acteurService;
        private AdminHomeControl _adminHomeControl;
        public MainWindow(IAbonneService abonneService, IUserService adminService, AdminHomeControl adminHomeControl)
        {
            _abonneService = abonneService;
            _adminService = adminService;
            InitializeComponent();
            mainContentControl.Content = new ConnexionControl(_adminService);
            _adminHomeControl = adminHomeControl;
        }

        public void AdminHomeControl()
        {
            mainContentControl.Content = _adminHomeControl;
        }
    }
}