using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Repository.Service;
using Superheroes.Presentation;
using Superheroes.Repository.CachingDecorator;
using Superheroes.Repository.Interface;
using SuperheroesRepository.CSV;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SuperheroesViewer
{
    public partial class App : Application
    {
        IContainer _container;
        IConfigurationRoot Configuration;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            var config = new ConfigurationBuilder().AddJsonFile("autofac.json");
            Configuration = config.Build();

            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "Loose Coupling - Superheroes (Autofac)";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {

            var module = new ConfigurationModule(Configuration);
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            _container = builder.Build();

            //var builder = new ContainerBuilder();
            //builder.RegisterType<CSVRepository>().As<ISuperheroRepository>();
            //builder.RegisterType<SuperheroViewModel>().AsSelf();
            //_container = builder.Build();
        }

        private void ComposeObjects()
        {
            SuperheroViewModel viewModel = _container.Resolve<SuperheroViewModel>();
            Application.Current.MainWindow = new SuperheroesViewerWindow(viewModel);
        }
    }
}
