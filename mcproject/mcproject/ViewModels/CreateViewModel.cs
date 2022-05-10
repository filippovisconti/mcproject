using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Firebase.Database.Query;
using mcproject.Models;
using mcproject.Services;

using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {
        public CreateViewModel()
        {
            Title = "Create a new event";

            CreateCommand = new AsyncCommand(CreateMethod);
            PopulateThoseBitches();
        }

        #region DBStuff
        private readonly FirebaseDB db = FirebaseDB.Instance;

        private void PopulateThoseBitches()
        {
            _ = Task.Run(async () =>
              {
                  CreateLevel = new ObservableCollection<Difficulty>(await db.GetAvailableLevelsListAsync());
                  OnPropertyChanged(nameof(CreateLevel));
              });
            _ = Task.Run(async () =>
              {
                  CreateSport = new ObservableCollection<Sport>(await db.GetAvailableSportsListAsync());
                  OnPropertyChanged(nameof(CreateSport));
              });

            _ = Task.Run(async () =>
            {
                //await db.client.Child("CitiesList").PostAsync(new City()
                //{
                //    Name = "Roma"
                //});
                CreateCity = new ObservableCollection<City>(Constants.cities);
                OnPropertyChanged(nameof(CreateCity));

            });
        }


        #endregion

        #region Commands

        public AsyncCommand CreateCommand { get; }

        #endregion

        #region EventProperties

        public IList<Sport> CreateSport { get; set; }

        private Sport _SelectedSport;
        public Sport SelectedSport
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

        private TimeSpan _SelectedTime;
        public TimeSpan SelectedTime
        {
            get => _SelectedTime;
            set => SetProperty(ref _SelectedTime, value);
        }

        public IList<Difficulty> CreateLevel { get; set; }

        private Difficulty _SelectedLevel;
        public Difficulty SelectedLevel
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

        private IList<City> _CreateCity;
        public IList<City> CreateCity
        {
            get => _CreateCity;
            set => SetProperty(ref _CreateCity, value);
        }


        private City _SelectedCity;
        public City SelectedCity
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



        //public EventoSportivo Create()
        //{


        //    EventoSportivo CreateEvento = new()
        //    {
        //        Sport = SelectedSport,
        //        DateAndTime = SelectedData,
        //        Level = SelectedLevel,
        //        TGUsername = SelectedTGusername,
        //        City = SelectedCity,
        //        Notes = SelectedNote
        //    };
        //    return CreateEvento;

        //}

        // used in the viewmodel
        public bool InfoComplete()
        {
            return
                SelectedSport != null &&
                SelectedLevel != null &&
                SelectedTGusername != null;
        }

        // used in the view
        public bool AreInfoComplete => InfoComplete();

        #endregion

        private async Task CreateMethod()
        {
            //await Shell.Current.GoToAsync("TestPage");
            SelectedData = SelectedData.AddHours(SelectedTime.Hours).AddMinutes(SelectedTime.Minutes);
            try
            {
                if (InfoComplete())
                    await Shell.Current
                        .GoToAsync($"ConfirmCreationPage?sport={SelectedSport}&data={SelectedData}&level={SelectedLevel}&tg={SelectedTGusername}&city={SelectedCity}&note={SelectedNote}");
                else
                    await Shell.Current
                        .DisplayAlert("Create Sporting Event", "An error occured: info non complete", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Shell.Current
                    .DisplayAlert("Create Sporting Event", "An error occured: " + ex.Message, "OK");
            }
        }
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

//_ = Task.Run(async () =>
//{

//    CreateLevel = new ObservableCollection<Difficulty>(await db.GetAvailableLevelsListAsync());
//    OnPropertyChanged(nameof(CreateLevel));

//    //QUESTO FUNZIONA
//    //IEnumerable<Difficulty> lev = await db.GetAvailableLevelsListAsync();
//    //var cl = new ObservableCollection<Difficulty>(lev);
//    //CreateLevel = cl;
//    //OnPropertyChanged(nameof(CreateLevel));

//});