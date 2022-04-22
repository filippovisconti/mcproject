using System;
using System.Collections.Generic;
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
            TestCreateSportsCommand = new AsyncCommand(TestCreateSports);
            PopulateLists();
        }

        #region DBStuff

        FirebaseDB client;
        private void PopulateLists()
        {
            client = new FirebaseDB();
            var temp = client.GetAvailableLevelsList();
            CreateLevel = new List<string>();
            foreach (Difficulty d in temp) { CreateLevel.Add(d.Level); }

            var temp2 = client.GetAvailableSportsList();
            foreach (Sport s in temp2) { CreateSport.Add(s.Name); }
            CreateSport = new List<string>();
        }
        #endregion

        #region Commands

        public AsyncCommand CreateCommand { get; }

        private async Task CreateMethod()
        {

            await Shell.Current.GoToAsync("TestPage");
        }

        public AsyncCommand TestCreateSportsCommand { get; }

        private async Task TestCreateSports()
        {

            await client.AddSportAsync(new Sport("Pallavolo"));
            await client.AddSportAsync(new Sport("Padel"));
            await client.AddSportAsync(new Sport("Calcetto"));
            await client.AddSportAsync(new Sport("Bocce"));
            await client.AddSportAsync(new Sport("Lancio di Coriandoli"));
            await client.AddSportAsync(new Sport("Soffio di minestrine"));
            await client.AddSportAsync(new Sport("Suonare i citofoni"));

            await client.AddLevelAsync(new Difficulty("Principiante"));
            await client.AddLevelAsync(new Difficulty("Dilettante"));
            await client.AddLevelAsync(new Difficulty("Avanzato"));
            await client.AddLevelAsync(new Difficulty("Esperto"));


        }
        #endregion

        #region EventProperties

        public List<string> CreateSport { get; set; }

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

        public List<string> CreateLevel { get; set; }


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

        public bool AreInfoComplete { get => InfoComplete(); }

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
