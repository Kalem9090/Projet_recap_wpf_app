using IdeaManager.Data;
using IdeaManager.Services;
using IdeaManager.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace IdeaManager.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        services.AddDataServices("Data Source=ideas.db");
        services.AddDomainServices();
        services.AddUIServices();
        services.AddTransient<IdeaFormViewModel>();
        services.AddTransient<IdeaListViewModel>();
        services.AddSingleton<MainWindow>();


        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}

