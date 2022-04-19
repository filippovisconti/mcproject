using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmHelpers.Commands;

namespace mcproject.ViewModels
{
    public class JoinViewModel : ViewModelBase
    {
       
        public Collection<string> AvailableSports
        {

            get => Services.Constants.Sport;
        }

        public ICommand Search { get; }
        public JoinViewModel()
        {
            Search = new AsyncCommand(OnSearch);
        }

        private async Task OnSearch()
        {
            //await Shell.Current.GoToAsync("LookForPage");
            await Shell.Current.GoToAsync($"LookForPage?sport={SelectedSport}&level={SelectedLevel}&city={SelectedCity}");
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