using mcproject.Models;
using mcproject.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers.Commands;

namespace mcproject.ViewModels
{

    public class ManageViewModel : ViewModelBase
    {
        // TODO aggiungere un Reload (altrimenti non si vedono eventi appena creati rientrando nella pagina). c'è un metodo che viene chiamato quando si apre la pagina (OnAppearing o simili) che potrebbe aiutare
        // TODO fix eventByuser
        #region BS
        // TODO GET RID OF THIS 

        public IList<City> Cities
        {

            get => Services.Constants.cities;
        }
        #endregion

        #region constructor and properties
        private readonly FirebaseDB db = FirebaseDB.Instance;

        private ObservableCollection<EventoSportivo> _Eventi;
        public ObservableCollection<EventoSportivo> Eventi
        {
            get => _Eventi;
            set => SetProperty(ref _Eventi, value);
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


        public ManageViewModel()
        {

            Title = "Manage your events";
            LoadEvent();
            SelectedCommand = new AsyncCommand(Selected);

        }
        #endregion

        #region helper methods
        private async Task<IList<EventoSportivo>> GetEventsByOwner()
        {
            User u = await DependencyService.Resolve<IAuthService>().RetrieveUserInfo();

            return await db.GetEventoAsyncByOwner(u);
        }

        private void LoadEvent()
        {
            //if (SelectedSport == null) throw new NullReferenceException();
            _ = Task.Run(async () =>
            {

                Eventi = new ObservableCollection<EventoSportivo>(
                    //await db.SearchBySportLevelCityAsync());
                    await GetEventsByOwner()
                    );
                OnPropertyChanged(nameof(Eventi));

            });
        }
        #endregion

    }

}
