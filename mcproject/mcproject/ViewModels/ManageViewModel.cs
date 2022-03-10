using mcproject.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using Xamarin.Forms;

namespace mcproject.ViewModels
{

    public class ManageViewModel : ViewModelBase


    {

        public ManageViewModel()
        {



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

    }

}
