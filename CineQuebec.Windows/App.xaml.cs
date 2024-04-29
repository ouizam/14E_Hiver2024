﻿using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace CineQuebec.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IHost host;
        public App()
        {
             host = Host.CreateDefaultBuilder().ConfigureServices((context, services ) =>
            {
                services.AddSingleton<Configuration>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<AdminHomeControl>();
                services.AddSingleton<AjouterFilm>();
                services.AddSingleton<UpdateFilm>();
                services.AddSingleton<FilmsControl>();
                services.AddSingleton<IAbonneService, AbonneService>();
                services.AddSingleton<IActeurService, ActeurService>();
                services.AddSingleton<IUserService, UserService>();
                services.AddSingleton<ICategorieService, CategorieService>();
                services.AddSingleton<IFilmService, FilmService>();
                services.AddSingleton<IPreferenceService, PreferenceService>();
                services.AddSingleton<IProjectionService, ProjectionService>();
                services.AddSingleton<IRealisateurService, RealisateurService>();
                services.AddSingleton<IReservationService, ReservationService>();

                services.AddSingleton<IAbonneRepository, AbonneRepository>();
                services.AddSingleton<IActeurRepository, ActeurRepository>();
                services.AddSingleton<IUserRepository, UserRepository>();
                services.AddSingleton<ICategorieRepository, CategorieRepository>();
                services.AddSingleton<IFilmRepository, FilmRepository>();
                services.AddSingleton<IPreferenceRepository, PreferenceRepository>();
                services.AddSingleton<IProjectionRepository, ProjectionRepository>();
                services.AddSingleton<IRealisateurRepository, RealisateurRepository>();
                services.AddSingleton<IReservationRepository, ReservationRepository>();


            })
                .Build();
           
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            var startupForm = host.Services.GetRequiredService<MainWindow>();
            startupForm.Show();
            base.OnStartup(e);
            
        }



    }

}
