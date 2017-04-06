using Repository.Service;
using Superheroes.Presentation;
using Superheroes.Repository.CachingDecorator;
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
            ComposeObjects();
            Application.Current.MainWindow.Title = "Loose Coupling - Superheroes";
            Application.Current.MainWindow.Show();
        }

        private void ComposeObjects()
        {

            //ISuperheroRepository repository = new CSVRepository();
            var decoratedRepository = new SuperheroRepository();
            var repository = new CachingRepository(decoratedRepository);
            SuperheroViewModel viewModel = new SuperheroViewModel(repository);
            Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
        }
    }
}
