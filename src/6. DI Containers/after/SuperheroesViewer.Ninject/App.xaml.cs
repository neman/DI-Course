using Ninject;
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
        IKernel _container;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "Loose Coupling - Superheroes";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            _container = new StandardKernel();
            _container.Bind<ISuperheroRepository>().To<CSVRepository>()
                .InSingletonScope();
        }

        private void ComposeObjects()
        {
            SuperheroViewModel viewModel = _container.Get<SuperheroViewModel>();
            Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
        }
    }
}
