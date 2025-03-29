using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services;
using Final_Project.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Final_Project;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        LoadData();

        var mainViewModel = ServiceProvider.GetRequiredService<MainViewModel>();
        var navigationService = ServiceProvider.GetRequiredService<INavigationService>() as NavigationService;

        navigationService.SetMainViewModel(mainViewModel);

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

    }

    private void ConfigureServices(ServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<ImdbContext>(options =>
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["IMDBConn"].ConnectionString));

        serviceCollection.AddSingleton<INavigationService, NavigationService>();
        serviceCollection.AddSingleton<HomeViewModel>();
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<MainViewModel>();
        serviceCollection.AddSingleton<SearchTitlesViewModel>();
        serviceCollection.AddSingleton<GenresViewModel>();
        serviceCollection.AddSingleton<SearchActorsViewModel>();
        serviceCollection.AddSingleton<SearchDirectorsViewModel>();
        serviceCollection.AddTransient<ActorViewModel>();
        serviceCollection.AddTransient<TitleViewModel>();


    }

    private void LoadData()
    {
        using (var scope = ServiceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ImdbContext>();

            var searchTitlesViewModel = ServiceProvider.GetRequiredService<SearchTitlesViewModel>();
            var genresViewModel = ServiceProvider.GetRequiredService<GenresViewModel>();
            var searchActorsViewModel = ServiceProvider.GetRequiredService<SearchActorsViewModel>();
            var searchDirectorsViewModel = ServiceProvider.GetRequiredService<SearchDirectorsViewModel>();


            searchTitlesViewModel.Titles = new ObservableCollection<Title>(dbContext.Titles.Take(200).ToList());
            searchTitlesViewModel.FilteredTitles = new ObservableCollection<Title>(dbContext.Titles.Take(200).ToList());
            
            genresViewModel.Titles = new ObservableCollection<Title>(dbContext.Titles.Include(t=>t.Genres).Take(1000).ToList());
            genresViewModel.Genres = new ObservableCollection<Genre>(dbContext.Genres.ToList());
            genresViewModel.FilteredTitles = new ObservableCollection<Title>(dbContext.Titles.Take(200).ToList());

            searchActorsViewModel.Actors = new ObservableCollection<Name>(dbContext.Names.Take(500).ToList());
            searchActorsViewModel.FilteredActors = new ObservableCollection<Name>(
            searchActorsViewModel.Actors.Where(n =>
                n.PrimaryProfession != null &&
                (n.PrimaryProfession.Contains("actor") || n.PrimaryProfession.Contains("actress"))
                )
            );

            searchDirectorsViewModel.Directors = new ObservableCollection<Name>(dbContext.Names.Take(500).ToList());
            
            searchDirectorsViewModel.FilteredDirectors = new ObservableCollection<Name>(
            searchDirectorsViewModel.Directors.Where(n =>
                n.PrimaryProfession != null &&
                n.PrimaryProfession.Contains("director")
                )
            );


        }
    }
}

