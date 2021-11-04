using System;
using System.Threading.Tasks;
using mcproject.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public User user;
        public AsyncCommand LoginCommand { get; }

#pragma warning disable IDE0090 // Use 'new(...)'
        readonly Uri url =
            new Uri("https://mcproject.auth.us-east-2.amazoncognito.com/login?client_id=havou4cvj0sbfuuij0ulrocaq&response_type=code&scope=aws.cognito.signin.user.admin+email+openid&redirect_uri=com.yodadev.mcproject://");
        readonly Uri callbackUrl = new Uri("com.yodadev.mcproject://");
#pragma warning restore IDE0090 // Use 'new(...)'
        WebAuthenticatorResult authResult;
        //private readonly IWebAuthenticator _webAuthenticator;

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
            //_webAuthenticator = new WebAuthenticator();
            LoginCommand = new AsyncCommand(LoginMethod);
        }

        private async Task LoginMethod()
        {
            try
            {
                authResult = await WebAuthenticator.AuthenticateAsync(new WebAuthenticatorOptions
                {
                    Url = url,
                    CallbackUrl = callbackUrl,
                    PrefersEphemeralWebBrowserSession = true
                });
                var accessToken = authResult?.AccessToken;
                await Shell.Current.GoToAsync("//ManagePage");
            }
            catch (TaskCanceledException e)
            {
                AccessToken = "You've cancelled.";
            }

        }


    }
}
