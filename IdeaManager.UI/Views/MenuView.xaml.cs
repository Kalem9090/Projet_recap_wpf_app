using System.Windows;
using System.Windows.Controls;

namespace IdeaManager.UI.Views
{
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void BtnForm_Click(object sender, RoutedEventArgs e)
        {
            var form = new IdeaFormView();
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.AfficherVue(form);
        }

        private void BtnListe_Click(object sender, RoutedEventArgs e)
        {
            var liste = new IdeaListView();
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.AfficherVue(liste);
        }
    }
}
