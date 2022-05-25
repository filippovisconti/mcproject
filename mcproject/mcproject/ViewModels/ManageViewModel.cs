using mcproject.Models;
using mcproject.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers.Commands;
using System.Security.Authentication;
using System.Windows.Input;

namespace mcproject.ViewModels
{

    public class ManageViewModel : ViewModelBase
    {

        /*
        // TODO GET RID OF THIS

        //public Collection<string> AvailableSports
        //{

        //    get => Services.Constants.Sport;
        //}
        //public ObservableCollection<string> CreateCity
        //{
        //    get => Services.Constants.City;
        //}

        public IList<City> Cities
        {

            get => Services.Constants.cities;
        }
        private string _SelectedCity;
        public string SelectedCity
        {
            get => _SelectedCity;
            set => SetProperty(ref _SelectedCity, value);
        }

        */

        //private readonly FirebaseDB db = FirebaseDB.Instance;

        public ICommand RefreshCommand { get; }

        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        void ExecuteRefreshCommand()
        {
            SelectedEvent = null;
            Eventi.Clear();
            LoadEvent();
            // Stop refreshing
            //IsRefreshing = false;
        }

        private readonly FirebaseDB db = FirebaseDB.Instance;
        private void LoadEvent()
        {
            //if (SelectedSport == null) throw new NullReferenceException();
            _ = Task.Run(async () =>
            {

                Eventi = new ObservableCollection<EventoSportivo>(
                    await db.GetAllEventiAsync());
                    //await GetEventsByOwner());
                OnPropertyChanged(nameof(Eventi));
                IsRefreshing = false;
            });
        }
        public Xamarin.Forms.Command PageAppearingCommand { get; set; }

        public void OnAppearing()
        {
            SelectedEvent = null;
        }


        public AsyncCommand SelectedCommand { get; }

        private EventoSportivo _SelectedEvent;
        public EventoSportivo SelectedEvent
        {
            get => _SelectedEvent;
            set => SetProperty(ref _SelectedEvent, value);
        }
        public async Task Selected()
        {
            if (SelectedEvent != null)
                await Shell.Current.GoToAsync($"ModifyEventPage?ID={SelectedEvent.ID}");
        }

        public ManageViewModel()
        {
            Title = "Edit or delete your events";
            LoadEvent();
            SelectedCommand = new AsyncCommand(Selected);
            //PageAppearingCommand = new Xamarin.Forms.Command(OnAppearing);
            RefreshCommand = new Xamarin.Forms.Command(ExecuteRefreshCommand);
        }

        private ObservableCollection<EventoSportivo> _Eventi;
        public ObservableCollection<EventoSportivo> Eventi
        {
            get => _Eventi;
            set => SetProperty(ref _Eventi, value);
        }

        private async Task<IList<EventoSportivo>> GetEventsByOwner()
        {
            User u = await DependencyService.Resolve<IAuthService>().RetrieveUserInfo();
            if (u != null)
                return await FirebaseDB.Instance.GetEventoAsyncByOwner(u);

            else
            {
                await Shell.Current
                            .DisplayAlert("Failed", "Retrieval of user info failed.", "OK");
                throw new AuthenticationException("Not logged in or failed to retrieve user data.");
            }
        }
    }
}
