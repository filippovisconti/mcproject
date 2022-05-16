using mcproject.Models;
using mcproject.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

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
        }

    }

}
