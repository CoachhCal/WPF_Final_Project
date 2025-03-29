using Final_Project.Models;
using Final_Project.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Final_Project.ViewModels
{
    public class SearchActorsViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Name> _actors;
        private ObservableCollection<Name> _filteredActors;
        private string _searchQueryActor;
        private Name _selectedActor;

        public SearchActorsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Actors = new ObservableCollection<Name>();
            FilteredActors = new ObservableCollection<Name>();
        }

        public ObservableCollection<Name> Actors
        {
            get => _actors;
            set
            {
                _actors = value;
                OnPropertyChanged(nameof(Actors));
                FilterActors();
            }
        }

        public ObservableCollection<Name> FilteredActors
        {
            get => _filteredActors;
            set
            {
                _filteredActors = value;
                OnPropertyChanged(nameof(FilteredActors));
            }
        }

        public string SearchQueryActor
        {
            get => _searchQueryActor;
            set
            {
                _searchQueryActor = value;
                OnPropertyChanged(nameof(SearchQueryActor));
                FilterActors();
            }
        }

        public Name SelectedActor
        {
            get => _selectedActor;
            set
            {
                _selectedActor = value;
                OnPropertyChanged(nameof(SelectedActor));
                NavigateToActorDetails();
            }
        }

        private void FilterActors()
        {
            if (string.IsNullOrEmpty(SearchQueryActor))
            {
                FilteredActors = new ObservableCollection<Name>(
                    Actors.Where(n => n.PrimaryProfession != null &&
                                      (n.PrimaryProfession.Contains("actor") ||
                                       n.PrimaryProfession.Contains("actress")))
                );
            }
            else
            {
                FilteredActors = new ObservableCollection<Name>(
                    Actors.Where(n =>
                        n.PrimaryProfession != null &&
                        (n.PrimaryProfession.Contains("actor") ||
                         n.PrimaryProfession.Contains("actress")) &&
                        n.PrimaryName != null &&
                        n.PrimaryName.ToLower().Contains(SearchQueryActor.ToLower()))
                );
            }
        }

        private void NavigateToActorDetails()
        {
            if (SelectedActor != null)
            {
                _navigationService.NavigateTo<ActorViewModel>(SelectedActor);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
