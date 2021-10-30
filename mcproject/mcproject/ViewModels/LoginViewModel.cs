using System;
using System.Threading.Tasks;
using mcproject.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public User user;
        public AsyncCommand LoginCommand { get; }
        Uri url = new Uri("https://mcproject.auth.us-east-2.amazoncognito.com");
        Uri callbackUrl = new Uri("myapp://");
        WebAuthenticatorResult authResult;

        private string _accessToken;
        public string AccessToken
        {
            get => _accessToken;
            set => SetProperty(ref _accessToken, value);
        }

        public LoginViewModel()
        {
            Title = "Login Page";
            user = new User();
            LoginCommand = new AsyncCommand(LoginMethod);
        }

        private async Task LoginMethod()
        {
            authResult = await WebAuthenticator.AuthenticateAsync(new WebAuthenticatorOptions
            {
                Url = url,
                CallbackUrl = callbackUrl,
                PrefersEphemeralWebBrowserSession = true
            });
            await Shell.Current.GoToAsync("//ManagePage");

        }


    }
}
