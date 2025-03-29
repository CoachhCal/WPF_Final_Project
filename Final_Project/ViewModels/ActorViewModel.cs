using Final_Project.Models;
using Final_Project.Services;
using System.Diagnostics;

namespace Final_Project.ViewModels
{

    public class ActorViewModel : IParameterizedViewModel
    {
        public Name SelectedActor { get; private set; }

        public void Initialize(object parameter)
        {
            if (parameter is Name actor)
            {
                SelectedActor = actor;
                Debug.WriteLine($"ActorViewModel initialized with: {SelectedActor?.PrimaryName}");
            }
        }

        public string PrimaryName => SelectedActor?.PrimaryName ?? "Unknown";
        public string PrimaryProfession => SelectedActor?.PrimaryProfession ?? "N/A";
        public int? BirthYear => SelectedActor?.BirthYear;
        public int? DeathYear => SelectedActor?.DeathYear;
    }
}
