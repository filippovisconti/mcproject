using mcproject.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Login Page";
            user = new User();
            LoginCommand = new AsyncCommand(LoginMethod);
        }
        
        private async Task LoginMethod()
        {
            await Shell.Current.Navigation.PopModalAsync();

        }

        public User user;

        public AsyncCommand LoginCommand;

       
    }
}
