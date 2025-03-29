using Final_Project.Models;
using Final_Project.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Final_Project.ViewModels
{
    public class GenresViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Genre> _genres;
        private ObservableCollection<Title> _filteredTitles;
        private ObservableCollection<Title> _title;
        private Genre _selectedGenre;
        private Title _selectedTitle;

        public GenresViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Titles = new ObservableCollection<Title>();
            FilteredTitles = new ObservableCollection<Title>();
            Genres = new ObservableCollection<Genre>();
        }

        public ObservableCollection<Genre> Genres
        {
            get => _genres;
            set
            {
                _genres = value;
                OnPropertyChanged(nameof(Genres));
            }
        }

        public ObservableCollection<Title> Titles
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Titles));
            }
        }

        public ObservableCollection<Title> FilteredTitles
        {
            get => _filteredTitles;
            set
            {
                _filteredTitles = value;
                OnPropertyChanged(nameof(FilteredTitles));
            }
        }

        public Genre SelectedGenre
        {
            get => _selectedGenre;
            set
            {
                _selectedGenre = value;
                OnPropertyChanged(nameof(SelectedGenre));
                FilterTitlesByGenre(); // Trigger filtering when a genre is selected
            }
        }

        public Title SelectedTitle
        {
            get => _selectedTitle;
            set
            {
                _selectedTitle = value;
                OnPropertyChanged(nameof(SelectedTitle));
                NavigateToTitleDetails(); // Trigger navigation when a title is selected
            }
        }

        private void FilterTitlesByGenre()
        {
            if (SelectedGenre != null)
            {
                // Filter titles based on whether one of their genres matches the selected genre
                FilteredTitles = new ObservableCollection<Title>(
                    Titles.Where(t => t.Genres.Any(g => g.GenreId == SelectedGenre.GenreId))
                );
            }
            else
            {
                // Clear the filtered titles when no genre is selected
                FilteredTitles = new ObservableCollection<Title>();
            }
        }

        private void NavigateToTitleDetails()
        {
            if (SelectedTitle != null)
            {
                _navigationService.NavigateTo<TitleViewModel>(SelectedTitle); // Navigate to TitleViewModel with the selected title
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
