using Repository.Service;
using Superheroes.Presentation;
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
            SuperheroRepository repository = new SuperheroRepository();
            SuperheroViewModel viewModel = new SuperheroViewModel(repository);
            Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
            Application.Current.MainWindow.Title = "Loose Coupling - Superheroes";
            Application.Current.MainWindow.Show();
        }
    }
}
