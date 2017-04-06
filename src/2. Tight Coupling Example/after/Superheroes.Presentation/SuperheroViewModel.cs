
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Superheroes.DataModel;
using Superheroes.Repository.Interface;

namespace Superheroes.Presentation
{
    public class SuperheroViewModel : INotifyPropertyChanged
    {
        protected ISuperheroRepository _repository;

        public SuperheroViewModel(ISuperheroRepository repository)
        {
            _repository = repository;
        }

        private IEnumerable<Superhero> _superheroes;
        public IEnumerable<Superhero> Superheroes
        {
            get { return _superheroes; }
            set
            {
                if (_superheroes == value)
                    return;
                _superheroes = value;
                RaisePropertyChanged("Superheroes");
            }
        }       

        #region Commands

        #region RefreshCommand Standard Stuff

        private RefreshCommand _refreshSuperheroesCommand = new RefreshCommand();
        public RefreshCommand RefreshSuperheroesCommand
        {
            get
            {
                if (_refreshSuperheroesCommand.ViewModel == null)
                    _refreshSuperheroesCommand.ViewModel = this;
                return _refreshSuperheroesCommand;
            }
        }

        public class RefreshCommand : ICommand
        {
            public SuperheroViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }
        #endregion RefreshCommand Standard Stuff

            public void Execute(object parameter)
            {
                ViewModel.Superheroes = ViewModel._repository.GetAll();
            }
        }

        #region ClearCommand Standard Stuff

        private ClearCommand _clearSuperheroesCommand = new ClearCommand();
        public ClearCommand ClearSuperheroesCommand
        {
            get
            {
                if (_clearSuperheroesCommand.ViewModel == null)
                    _clearSuperheroesCommand.ViewModel = this;
                return _clearSuperheroesCommand;
            }
        }

        public class ClearCommand : ICommand
        {
            public SuperheroViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }

        #endregion

            public void Execute(object parameter)
            {
                ViewModel.Superheroes = new List<Superhero>();
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
