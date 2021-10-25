using System;
using System.Threading.Tasks;
using mcproject.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Login Page";
            user = new User();
            LoginCommand = new AsyncCommand(LoginMethod);
        }

        private async Task LoginMethod()
        {
            await Shell.Current.GoToAsync("//ManagePage");

        }

        public User user;

        public AsyncCommand LoginCommand { get; }
    }
}
