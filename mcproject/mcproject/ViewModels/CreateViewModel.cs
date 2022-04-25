using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

                  //QUESTO FUNZIONA
                  //IEnumerable<Difficulty> lev = await db.GetAvailableLevelsListAsync();
                  //var cl = new ObservableCollection<Difficulty>(lev);
                  //CreateLevel = cl;
                  //OnPropertyChanged(nameof(CreateLevel));

              });
            _ = Task.Run(async () =>
              {

                  CreateSport = new ObservableCollection<Sport>(await db.GetAvailableSportsListAsync());
                  OnPropertyChanged(nameof(CreateSport));

                  //QUESTO FUNZIONA
                  //IEnumerable<Sport> sp = await db.GetAvailableSportsListAsync();
                  //var cs = new ObservableCollection<Sport>(sp);
                  //CreateSport = cs;
                  //OnPropertyChanged(nameof(CreateSport));

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

        public ObservableCollection<string> CreateCity
        {
            get => Constants.City;
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

            EventoSportivo CreateEvento = new()
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

        public bool InfoComplete()
        {
            return
                SelectedSport != null &&
                SelectedLevel != null &&
                SelectedTGusername != null;
        }

        public bool AreInfoComplete => InfoComplete();

        #endregion

        private async Task CreateMethod()
        {
            //await Shell.Current.GoToAsync("TestPage");
            try
            {
                if (InfoComplete())
                    await Shell.Current
                        .GoToAsync($"TestPage?sport={SelectedSport}&data={SelectedData}&level={SelectedLevel}&tg={SelectedTGusername}&city={SelectedCity}&note={SelectedNote}");
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
