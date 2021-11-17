using mcproject.Models;
using System.Collections.Generic;
using System.Web;
using Xamarin.Forms;

namespace mcproject.ViewModels
{

    public class ManageViewModel : ViewModelBase


    {
        private User UserFromLogin;

        public bool notLoggedIn { get; set; }

        public ManageViewModel()
        {

            UserFromLogin = LoginViewModel.user;
            notLoggedIn = UserFromLogin.Equals(null);

        }



    }

}
