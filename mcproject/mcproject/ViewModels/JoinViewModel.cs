using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace mcproject.ViewModels
{
    public class JoinViewModel : ViewModelBase
    {
        public ICommand Search;
        public Collection<string> AvailableSports
        {

            get => Services.Constants.Sport;
        }
        //public ObservableRangeCollection<Grouping<string, Sport>> SportGroups { get; }

        public JoinViewModel()
        {
            Title = "Join in";
            Search = new Command(OnSearch);
        }

        private async void OnSearch()
        {
            await Shell.Current.GoToAsync("TestPage");
        }

        private string _SelectedSport;
        public string SelectedSport
        {
            get => _SelectedSport;
            set => SetProperty(ref _SelectedSport, value);
        }

        public Collection<string> Level
        {
            get => Services.Constants.Livello;
        }


        private string _SelectedLevel;
        public string SelectedLevel
        {
            get => _SelectedLevel;
            set => SetProperty(ref _SelectedLevel, value);
        }

        public Collection<string> City
        {
            get => Services.Constants.City;
        }


        private string _SelectedCity;
        public string SelectedCity
        {
            get => _SelectedCity;
            set => SetProperty(ref _SelectedCity, value);
        }





    }
}