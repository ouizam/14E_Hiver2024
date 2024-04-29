using CineQuebec.Windows.BLL.Interfaces;
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
    /// Logique d'interaction pour PreferencesAbonne.xaml
    /// </summary>
    public partial class PreferencesAbonne : Window
    {
        private readonly IAbonneService _abonneService;
        List<Abonne> _listeDesUsers;
        public PreferencesAbonne(IAbonneService abonneService)
        {
            InitializeComponent();
            _abonneService = abonneService;
            _listeDesUsers = _abonneService.ObtenirAbonnes();
        }
    }
}
