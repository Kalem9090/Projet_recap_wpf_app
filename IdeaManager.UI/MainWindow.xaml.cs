using System.Windows;
using System.Windows.Controls;
using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;

namespace IdeaManager.UI
{
    public partial class MainWindow : Window
    {
        private readonly IdeaFormViewModel _formVM;
        private readonly IdeaListViewModel _listVM;

        public MainWindow(IdeaFormViewModel formVM, IdeaListViewModel listVM)
        {
            InitializeComponent();

            _formVM = formVM;
            _listVM = listVM;

            // Affiche la vue formulaire par défaut au lancement
            AfficherVue(new IdeaFormView { DataContext = _formVM });
        }

        public void AfficherVue(UserControl vue)
        {
            ZonePrincipale.Content = vue;
        }
    }
}
