using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using mcproject.Models;
using mcproject.Services;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;

namespace mcproject.ViewModels
{
    class ModifyEventViewModel : ViewModelBase, IQueryAttributable

    {
        #region class properties
        private readonly FirebaseDB db = FirebaseDB.Instance;
        public int ID { get; private set; }

        public EventoSportivo Evento { get; private set; }

        public AsyncCommand ModifyCommand { get; }
        public AsyncCommand DeleteCommand { get; }
        public IList<Sport> ModifySport { get; set; }
        #endregion

        #region event fields

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

        public IList<Difficulty> ModifyLevel { get; set; }

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

        private IList<City> _ModifyCity;
        public IList<City> ModifyCity
        {
            get => _ModifyCity;
            set => SetProperty(ref _ModifyCity, value);
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

        #endregion


        public ModifyEventViewModel()
        {
            PopulateThoseBitches();
            ModifyCommand = new AsyncCommand(ModifyMethod);
            DeleteCommand = new AsyncCommand(DeleteMethod);
        }


        #region delete event
        private void Delete()
        {
            _ = Task.Run(async () => await db.DeleteEventoSportivoAsync(Evento));

        }
        private async Task DeleteMethod()
        {
            Delete();
            await Shell.Current.GoToAsync($"//ManagePage");
            Evento = null;
            ID = 0;
        }
        #endregion

        #region update event
        private void Update()
        {
            _ = Task.Run(async () => await db.UpdateEventoSportivoAsync(Evento));
        }

        private async Task ModifyMethod()
        {

            Evento.Sport = SelectedSport;
            Evento.DateAndTime = SelectedData;
            Evento.Level = SelectedLevel;
            Evento.TGUsername = SelectedTGusername;
            Evento.City = SelectedCity;
            Evento.Notes = SelectedNote;

            //Update();

            try
            {
                if (InfoComplete())
                {
                    Update();
                    await Shell.Current.DisplayAlert("Modify Sporting Event", "Event updated correctly", "OK");
                    await Shell.Current.GoToAsync($"..");
                }

                else
                    await Shell.Current.DisplayAlert("Modify Sporting Event", "An error occured: info not complete", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Modify Sporting Event", "An error occured: " + ex.Message, "OK");
            }

        }
        #endregion

        #region populate fields
        private void PopulateThoseBitches()
        {
            _ = Task.Run(async () =>
            {
                ModifyLevel = new ObservableCollection<Difficulty>(await db.GetAvailableLevelsListAsync());
                OnPropertyChanged(nameof(ModifyLevel));
            });
            _ = Task.Run(async () =>
            {
                ModifySport = new ObservableCollection<Sport>(await db.GetAvailableSportsListAsync());
                OnPropertyChanged(nameof(ModifySport));
            }); _ = Task.Run(async () =>
            {
                //await db.client.Child("CitiesList").PostAsync(new City()
                //{
                // Name = "Roma"
                //});
                ModifyCity = new ObservableCollection<City>(Constants.cities);
                OnPropertyChanged(nameof(ModifyCity));
            });
        }


        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            ID = Convert.ToInt32(HttpUtility.UrlDecode(query["ID"]));

            GetEvento();
            //OnPropertyChanged(nameof(SelectedCity));
        }

        private void GetEvento()
        {
            _ = Task.Run(async () =>
            {
                Evento = (await db.GetEventoAsyncByID(ID));
                OnPropertyChanged(nameof(Evento));

                SelectedSport = Evento.Sport;
                OnPropertyChanged(nameof(SelectedSport));

                SelectedData = Evento.DateAndTime;
                OnPropertyChanged(nameof(SelectedData));

                SelectedLevel = Evento.Level;
                OnPropertyChanged(nameof(SelectedLevel));

                SelectedTGusername = Evento.TGUsername;

                SelectedCity = Evento.City;
                OnPropertyChanged(nameof(SelectedCity));

                SelectedNote = Evento.Notes;

            });
        }
        #endregion

        #region validation
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
    }
}
