﻿using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Interfaces;
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
    /// Logique d'interaction pour UtilisateursControl.xaml
    /// </summary>
    public partial class UtilisateursControl : Window
    {
        private readonly IAbonneService _abonneService;

        List<Abonne> _listeDesUsers;
        
        public UtilisateursControl(IAbonneService abonneService)
        {
            InitializeComponent();

			_abonneService = abonneService;
			_listeDesUsers = _abonneService.ObtenirAbonnes().OrderByDescending(x=>x.Reservations.Count).ToList();

            AfficherListeUtilisateurs();
        }

        private void lstUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstUsers.SelectedItems !=null)
            {
                Abonne abonne = lstUsers.SelectedItem as Abonne;             
                InformationsAbonne informationAbonne = new InformationsAbonne(abonne);
                informationAbonne.Show();

            }
        }

        private void AfficherListeUtilisateurs()
        {
            lstUsers.Items.Clear();
            foreach (Abonne abonne in _listeDesUsers)
            {
                lstUsers.Items.Add(abonne);
            }
        }

	}
}
