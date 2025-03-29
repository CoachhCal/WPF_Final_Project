using Final_Project.Commands;
using Final_Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Final_Project.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {

                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));

            }
        }

        private readonly INavigationService _navigationService;
        public ICommand ExitCommand { get; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CurrentViewModel = new HomeViewModel();
            ExitCommand = new RelayCommand(_ => Application.Current.Shutdown());
        }

        public ICommand NavigateToHomeCommand => new RelayCommand(_ => _navigationService.NavigateTo<HomeViewModel>());
        public ICommand NavigateToGenresCommand => new RelayCommand(_ => _navigationService.NavigateTo<GenresViewModel>());
        public ICommand NavigateToSearchMoviesCommand => new RelayCommand(_ => _navigationService.NavigateTo<SearchMoviesViewModel>());
        public ICommand NavigateToSearchActorsCommand => new RelayCommand(_ => _navigationService.NavigateTo<SearchActorsViewModel>());
        public ICommand NavigateToSearchDirectorsCommand => new RelayCommand(_ => _navigationService.NavigateTo<SearchDirectorsViewModel>());

        //public ICommand NavigateToWritersCommand => new RelayCommand(_ => _navigationService.NavigateTo<MusicCatalogViewModel>());
        public ICommand GoBackCommand => new RelayCommand(_ => _navigationService.GoBack());


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
}
