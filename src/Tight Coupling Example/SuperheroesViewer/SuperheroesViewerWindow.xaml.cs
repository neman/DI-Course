using System.Windows;
using Superheroes.Presentation;

namespace SuperheroesViewer
{
    public partial class SuperheroesViewerWindow : Window
    {
        public SuperheroesViewerWindow()
        {
            InitializeComponent();
            DataContext = new SuperheroViewModel();
        }
    }
}
