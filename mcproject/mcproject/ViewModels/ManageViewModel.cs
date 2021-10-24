using mcproject.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class ManageViewModel : ViewModelBase
    {
        public ManageViewModel()
        {
            notLoggedIn = true;
            GoToHomePage = new AsyncCommand(goToHomePage);

        }

        public bool notLoggedIn { get; set; }

        public AsyncCommand GoToHomePage { get; }

        public async Task goToHomePage()
        {
            await Shell.Current.Navigation.PushModalAsync(new AboutPage());
        }
    }

}
