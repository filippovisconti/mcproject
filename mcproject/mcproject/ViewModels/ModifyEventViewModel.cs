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
        public AsyncCommand ModifyCommand { get; }
        public AsyncCommand DeleteCommand { get; }
        public IList<Sport> ModifySport { get; set; }

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

        private readonly FirebaseDB db = FirebaseDB.Instance;

        public int ID { get; private set; }

        public EventoSportivo Evento { get; private set; }


        public ModifyEventViewModel()
        {
            PopulateThoseBitches();
            ModifyCommand = new AsyncCommand(ModifyMethod);
            DeleteCommand = new AsyncCommand(DeleteMethod);
        }


        private async Task DeleteMethod()
        {

            Delete();
           
             await Shell.Current.GoToAsync($"");
              

        }


        private void Delete()
        {
            _ = Task.Run(async () => await db.DeleteEventoSportivoAsync(Evento));

        }


        private async Task ModifyMethod()
        {
            
            Evento.Sport = SelectedSport;
            Evento.DateAndTime = SelectedData;
            Evento.Level = SelectedLevel;
            Evento.TGUsername = SelectedTGusername;
            Evento.City = SelectedCity;
            Evento.Notes = SelectedNote;

            Update();

            try
            {
                if (InfoComplete())
                    await Shell.Current.GoToAsync($"");
                else
                    await Shell.Current.DisplayAlert("Modify Sporting Event", "An error occured: info non complete", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Modify Sporting Event", "An error occured: " + ex.Message, "OK");
            }

        }

        private void Update()
        {
            _ = Task.Run(async () => await db.UpdateEventoSportivoAsync(Evento));

        }

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

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            ID = Convert.ToInt32(HttpUtility.UrlDecode(query["ID"]));

            GetEvento();
        }

        private void GetEvento()
        {
            _ = Task.Run(async () =>
            {
                Evento = (await db.GetEventoAsyncByID(ID));
                OnPropertyChanged(nameof(Evento));

                SelectedSport = Evento.Sport;
                SelectedData = Evento.DateAndTime;
                SelectedLevel = Evento.Level;
                SelectedTGusername = Evento.TGUsername;
                SelectedCity = Evento.City;
                SelectedNote = Evento.Notes;
            });
        }


    }
}
