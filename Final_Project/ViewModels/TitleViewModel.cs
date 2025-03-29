using Final_Project.Models;
using Final_Project.Services;

namespace Final_Project.ViewModels
{
    public class TitleViewModel : IParameterizedViewModel
    {
        public Title SelectedTitle { get; private set; }

        public void Initialize(object parameter)
        {
            if (parameter is Title title)
            {
                SelectedTitle = title;
            }
        }

        // Properties for displaying Title information
        public string TitleId => SelectedTitle?.TitleId ?? "Unknown ID";
        public string TitleType => SelectedTitle?.TitleType ?? "Unknown Type";
        public string PrimaryTitle => SelectedTitle?.PrimaryTitle ?? "Unknown Primary Title";
        public string OriginalTitle => SelectedTitle?.OriginalTitle ?? "Unknown Original Title";
        public string IsAdult => SelectedTitle?.IsAdult == true ? "Yes" : "No";
        public string StartYear => SelectedTitle?.StartYear?.ToString() ?? "N/A";
        public string EndYear => SelectedTitle?.EndYear?.ToString() ?? "N/A";
        public string RuntimeMinutes => SelectedTitle?.RuntimeMinutes?.ToString() ?? "N/A";

        // Properties for related data (e.g., genres and ratings)
        public string Genres => SelectedTitle?.Genres.Count > 0
            ? string.Join(", ", SelectedTitle.Genres.Select(g => g.Name))
            : "No genres available";

        public string Rating => SelectedTitle?.Rating?.AverageRating?.ToString("F1") ?? "No rating available";
    }
}
