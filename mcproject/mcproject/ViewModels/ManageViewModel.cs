using mcproject.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public IList<City> Cities
        {

            get => Services.Constants.cities;
        }

        //public ObservableCollection<string> CreateCity
        //{
        //    get => Services.Constants.City;
        //}

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

    }

}
