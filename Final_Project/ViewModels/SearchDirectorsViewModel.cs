using Final_Project.Models;
using Final_Project.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Final_Project.ViewModels
{
    public class SearchDirectorsViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Name> _directors;
        private ObservableCollection<Name> _filteredDirectors;
        private string _searchQueryDirector;
        private Name _selectedDirector;

        public SearchDirectorsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Directors = new ObservableCollection<Name>();
            FilteredDirectors = new ObservableCollection<Name>();
        }

        public ObservableCollection<Name> Directors
        {
            get => _directors;
            set
            {
                _directors = value;
                OnPropertyChanged(nameof(Directors));
                FilterDirectors();
            }
        }

        public ObservableCollection<Name> FilteredDirectors
        {
            get => _filteredDirectors;
            set
            {
                _filteredDirectors = value;
                OnPropertyChanged(nameof(FilteredDirectors));
            }
        }

        public string SearchQueryDirector
        {
            get => _searchQueryDirector;
            set
            {
                _searchQueryDirector = value;
                OnPropertyChanged(nameof(SearchQueryDirector));
                FilterDirectors();
            }
        }

        public Name SelectedDirector
        {
            get => _selectedDirector;
            set
            {
                _selectedDirector = value;
                OnPropertyChanged(nameof(SelectedDirector));
                NavigateToDirectorDetails();
            }
        }

        private void FilterDirectors()
        {
            if (string.IsNullOrEmpty(SearchQueryDirector))
            {
                FilteredDirectors = new ObservableCollection<Name>(
                    Directors.Where(n => n.PrimaryProfession != null &&
                                         n.PrimaryProfession.Contains("director"))
                );
            }
            else
            {
                FilteredDirectors = new ObservableCollection<Name>(
                    Directors.Where(n =>
                        n.PrimaryProfession != null &&
                        n.PrimaryProfession.Contains("director") &&
                        n.PrimaryName != null &&
                        n.PrimaryName.ToLower().Contains(SearchQueryDirector.ToLower()))
                );
            }
        }

        private void NavigateToDirectorDetails()
        {
            if (SelectedDirector != null)
            {
                _navigationService.NavigateTo<ActorViewModel>(SelectedDirector); // Change to DirectorViewModel if applicable
            }
            else
            {
                Debug.WriteLine("SelectedDirector is null.");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
