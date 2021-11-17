using System;
using System.Threading.Tasks;
using mcproject.Models;
using mcproject.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public static User user;
        public AsyncCommand LoginCommand { get; }

#pragma warning disable IDE0090 // Use 'new(...)'
        readonly Uri url =
            new Uri("https://mcproject.auth.us-east-2.amazoncognito.com/login?client_id=havou4cvj0sbfuuij0ulrocaq&response_type=token&scope=email+openid+profile&redirect_uri=com.yodadev.mcproject://");
        readonly Uri callbackUrl =
            new Uri("com.yodadev.mcproject://");
#pragma warning restore IDE0090 // Use 'new(...)'
        WebAuthenticatorResult authResult;

        private string _accessToken;
        public string AccessToken
        {
            get => _accessToken;
            set => SetProperty(ref _accessToken, value);
        }

        private string _IDToken;
        public string IDToken
        {
            get => _IDToken;
            set => SetProperty(ref _IDToken, value);
        }


        public LoginViewModel()
        {
            Title = "Login Page";
            user = new User();
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
                AccessToken = authResult?.AccessToken;
                IDToken = authResult?.IdToken;

                var handler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
                var id = handler.ReadJsonWebToken(IDToken);

                user.EmailAddress = id.GetClaim("email").Value.ToString();
                user.Name = id.GetClaim("name").Value.ToString();
                user.Nickname = id.GetClaim("nickname").Value.ToString();
                user.AccessToken = AccessToken;
                user.IDToken = IDToken;

                await Shell.Current.GoToAsync("//ManagePage");


            }
            catch (TaskCanceledException)
            {
                AccessToken = "You've cancelled.";
            }
        }
    }


    //System.Diagnostics.Debug.WriteLine();
    //var idArray = id.Claims.AsEnumerable();
    //foreach (var i in idArray)
    //{
    //    System.Diagnostics.Debug.WriteLine(i);
    //}
    ////System.Diagnostics.Debug.WriteLine("AT: " + AccessToken);
    ////System.Diagnostics.Debug.WriteLine("IDT:" + IDToken);
    //await Shell.Current.GoToAsync("//ManagePage");
    //await Shell.Current.GoToAsync($"{ nameof(ManagePage)}?user ={ user }");
}
