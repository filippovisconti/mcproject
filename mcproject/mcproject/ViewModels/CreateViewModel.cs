using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mcproject.Models;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {

        public AsyncCommand CreateCommand { get; }
        public CreateViewModel()
        {
            Title = "Create a new event";
            CreateCommand = new AsyncCommand(CreateMethod);
        }

        public ObservableCollection<string> CreateSport
        {

            get => Services.Constants.Sport;
        }

        private string _SelectedSport;
        public string SelectedSport
        {
            get => _SelectedSport;
            set => SetProperty(ref _SelectedSport, value);
        }

        private DateTime _SelectedData;
        public DateTime SelectedData
        {
            get => _SelectedData;
            set => SetProperty(ref _SelectedData, value);
        }

        public ObservableCollection<string> CreateLevel
        {
            get => Services.Constants.Livello;
        }


        private string _SelectedLevel;
        public string SelectedLevel
        {
            get => _SelectedLevel;
            set => SetProperty(ref _SelectedLevel, value);
        }


        private string _SelectedTGusername;
        public string SelectedTGusername
        {
            get => _SelectedTGusername;
            set => SetProperty(ref _SelectedTGusername, value);
        }



        public ObservableCollection<string> CreateCity
        {
            get => Services.Constants.City;
        }


        private string _SelectedCity;
        public string SelectedCity
        {
            get => _SelectedCity;
            set => SetProperty(ref _SelectedCity, value);
        }


        private string _SelectedNote;
        public string SelectedNote
        {
            get => _SelectedNote;
            set => SetProperty(ref _SelectedNote, value);
        }



        public EventoSportivo Create()
        {
#pragma warning disable IDE0017 // Simplify object initialization
#pragma warning disable IDE0090 // Use 'new(...)'
            EventoSportivo CreateEvento = new EventoSportivo();
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE0017 // Simplify object initialization
            CreateEvento.Sport = SelectedSport;
            CreateEvento.DateAndTime = SelectedData;
            CreateEvento.Level = SelectedLevel;
            CreateEvento.TGUsername = SelectedTGusername;
            CreateEvento.City = SelectedCity;
            CreateEvento.Notes = SelectedNote;
            return CreateEvento;

        }

        public bool InfoComplete => (
               SelectedSport != null &&
               SelectedLevel != null &&
               SelectedTGusername != null);


        private async Task CreateMethod()
        {
            await Shell.Current.GoToAsync("TestPage");
        }

    }

}
