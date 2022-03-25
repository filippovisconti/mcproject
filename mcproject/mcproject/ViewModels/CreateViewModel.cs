using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mcproject.Models;
using mcproject.Services;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {
        public CreateViewModel()
        {
            Title = "Create a new event";
            CreateCommand = new AsyncCommand(CreateMethod);
            TestCreateSportCommand = new AsyncCommand(TestCreateSports);
            PopulateLists();
        }

        #region DBStuff

        FirebaseDB client;
        private void PopulateLists()
        {
            client = new FirebaseDB();
            CreateLevel = client.GetAvailableLevelsList();
            CreateSport = client.GetAvailableSportsList();
        }
        #endregion

        #region Commands

        public AsyncCommand CreateCommand { get; }

        private async Task CreateMethod()
        {

            await Shell.Current.GoToAsync("TestPage");
        }

        public AsyncCommand TestCreateSportCommand { get; }

        private async Task TestCreateSports()
        {

            await client.AddSportAsync("Pallavolo");
            await client.AddSportAsync("Padel");
            await client.AddSportAsync("Calcetto");
            await client.AddSportAsync("Bocce");
            await client.AddSportAsync("Lancio di Coriandoli");
            await client.AddSportAsync("Soffio di minestrine");
            await client.AddSportAsync("Suonare i citofoni");

            await client.AddLevelAsync("Principiante");
            await client.AddLevelAsync("Dilettante");
            await client.AddLevelAsync("Avanzato");
            await client.AddLevelAsync("Esperto");


        }
        #endregion

        #region EventProperties

        public ObservableCollection<string> CreateSport { get; set; }

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

        public ObservableCollection<string> CreateLevel { get; set; }


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

        public bool InfoComplete()
        {
            return SelectedSport != null &&
                   SelectedLevel != null &&
                   SelectedCity != null &&
                   SelectedNote != null &&
                   SelectedTGusername != null;
        }

        #endregion

        public EventoSportivo CreateEventFromProperties()
        {
            EventoSportivo CreateEvento;
            if (InfoComplete()) throw new ArgumentNullException();
            else

                CreateEvento = new()
                {
                    Sport = SelectedSport,
                    DateAndTime = SelectedData,
                    Level = SelectedLevel,
                    TGUsername = SelectedTGusername,
                    City = SelectedCity,
                    Notes = SelectedNote
                };

            return CreateEvento;

        }





    }

}
