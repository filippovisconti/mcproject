using mcproject.Models;
using mcproject.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using MvvmHelpers.Commands;

namespace mcproject.ViewModels
{

    public class ManageViewModel : ViewModelBase
    {
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


        public ManageViewModel()
        {

            Title = "Manage your events";
            LoadEvent();
            SelectedCommand = new AsyncCommand(Selected);

        }



        private string _SelectedCity;
        public string SelectedCity
        {
            get => _SelectedCity;
            set => SetProperty(ref _SelectedCity, value);
        }


 private async Task<IList<EventoSportivo>> GetEventsByOwner()
        {
            User u = await DependencyService.Resolve<IAuthService>().RetrieveUserInfo();

            return await FirebaseDB.Instance.GetEventoAsyncByOwner(u);


        private ObservableCollection<EventoSportivo> _Eventi;
        public ObservableCollection<EventoSportivo> Eventi
        {
            get => _Eventi;
            set => SetProperty(ref _Eventi, value);
        }

        private readonly FirebaseDB db = FirebaseDB.Instance;
        private void LoadEvent()
        {
            //if (SelectedSport == null) throw new NullReferenceException();
            _ = Task.Run(async () =>
            {

                Eventi = new ObservableCollection<EventoSportivo>(
                    //await db.SearchBySportLevelCityAsync());
                    await db.GetAllEventiAsync());
                OnPropertyChanged(nameof(Eventi));

            });
        }

        private EventoSportivo _SelectedEvent;
        public EventoSportivo SelectedEvent
        {
            get => _SelectedEvent;
            set => SetProperty(ref _SelectedEvent, value);
        }

        public AsyncCommand SelectedCommand { get; }


        public async Task Selected()
        {
            await Shell.Current.GoToAsync($"ModifyEventPage?ID={SelectedEvent.ID}");
        }


    }

}
