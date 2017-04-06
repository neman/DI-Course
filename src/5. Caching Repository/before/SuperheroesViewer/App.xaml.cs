﻿using Repository.Service;
using Superheroes.Presentation;
using Superheroes.Repository.Interface;
using SuperheroesRepository.CSV;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SuperheroesViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CompositionObjects();
            Application.Current.MainWindow.Title = "Loose Coupling - Superheroes";
            Application.Current.MainWindow.Show();
        }

        private static void CompositionObjects()
        {
            //SuperheroRepository repository = new SuperheroRepository();
            ISuperheroRepository repository = new CSVRepository();
            SuperheroViewModel viewModel = new SuperheroViewModel(repository);
            Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
        }
    }
}
