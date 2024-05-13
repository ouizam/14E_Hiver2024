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
    /// Logique d'interaction pour Recompenses.xaml
    /// </summary>
    public partial class Recompenses : Window
    {
        public Recompense Recompense { get; set; }
        public Abonne _abonne;
        private readonly ITypeRecompenseService _typeRecompenseService;
        private readonly IRecompenseService _recompenseService;
        public Recompenses(ITypeRecompenseService pTypeRecompenseService, Abonne abonne, IRecompenseService pRecompenseService)
        {
            InitializeComponent();
            _typeRecompenseService = pTypeRecompenseService;
            _abonne = abonne;
            _recompenseService = pRecompenseService;
        }

      

        private void Button_Avant_premier_Click(object sender, RoutedEventArgs e)
        {
            var typeRecompense = _typeRecompenseService.ObtenirToutTypesRecompenses().FirstOrDefault(x => x.NomRecompense == "Assister à une avant première");
            Recompense = new Recompense { IdTypeRecompense = typeRecompense.Id, IdAbonne = _abonne.Id, TypeRecompense = typeRecompense };
            _recompenseService.AjouterRecompense(Recompense);
            DialogResult = true;
        }

       

        private void Button_Ticket_Gratuit_Click(object sender, RoutedEventArgs e)
        {
          var typeRecompense =  _typeRecompenseService.ObtenirToutTypesRecompenses().FirstOrDefault(x =>x.NomRecompense == "Ticket gratuit");
            Recompense = new Recompense { IdTypeRecompense = typeRecompense.Id, IdAbonne = _abonne.Id, TypeRecompense = typeRecompense };
            _recompenseService.AjouterRecompense(Recompense);
            DialogResult = true;
        }
    }
}
