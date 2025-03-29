using Final_Project.Models;
using Final_Project.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Final_Project.ViewModels
{
    public class SearchTitlesViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Title> _titles;
        private ObservableCollection<Title> _filteredTitles;
        private string _searchQueryTitle;
        private Title _selectedTitle;

        public SearchTitlesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Titles = new ObservableCollection<Title>();
            FilteredTitles = new ObservableCollection<Title>();
        }

        public ObservableCollection<Title> Titles
        {
            get => _titles;
            set
            {
                _titles = value;
                OnPropertyChanged(nameof(Titles));
                FilterTitles(); // Automatically filter when titles are updated
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

        public string SearchQueryTitle
        {
            get => _searchQueryTitle;
            set
            {
                _searchQueryTitle = value;
                OnPropertyChanged(nameof(SearchQueryTitle));
                FilterTitles();
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

        private void FilterTitles()
        {
            if (string.IsNullOrEmpty(SearchQueryTitle))
            {
                FilteredTitles = Titles;
            }
            else
            {
                FilteredTitles = new ObservableCollection<Title>(
                    Titles.Where(a => a.OriginalTitle.ToLower().Contains(SearchQueryTitle.ToLower())));
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
