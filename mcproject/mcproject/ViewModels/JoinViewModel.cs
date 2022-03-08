using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;


namespace mcproject.ViewModels
{
    public class JoinViewModel : ViewModelBase
    {
        public Command Search;
        public ObservableRangeCollection<string> AvailableSports
        {

            get => (ObservableRangeCollection<string>)Services.Constants.Sport;
        }
        //public ObservableRangeCollection<Grouping<string, Sport>> SportGroups { get; }
        
        public JoinViewModel()
        {
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