using System;
using System.Windows.Input;
using mcproject.Services;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class NewUserViewModel : BaseViewModel
    {
        public NewUserViewModel()
        {
            SignUpCommand = new Command(OnSignUp);
            BypassCommand = new Command(OnBypassLogin);
        }

        #region Commands

        public ICommand SignUpCommand { get; }

        public ICommand BypassCommand { get; }
        #endregion

        private string password;
        private string repPassword;
        private string email;
        private string telegramUsername;

        #region Properties
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string RepPassword
        {
            get => password;
            set => SetProperty(ref repPassword, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string TelegramUsername
        {
            get => email;
            set => SetProperty(ref telegramUsername, value);
        }
        #endregion

        private async void OnSignUp()
        {
            try
            {
                if (Password != RepPassword) throw new Exception("Different Passwords");

                var authService = DependencyService.Resolve<IAuthService>();
                var token = await authService.CreateUser(TelegramUsername, Email, Password);

                await Xamarin.Forms.Shell.Current.GoToAsync("//HomePage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Shell.Current
                    .DisplayAlert("SignIn", "An error occurs", "OK");
            }
        }

        private async void OnBypassLogin() // FIXME to be removed
        {
            await Xamarin.Forms.Shell.Current.GoToAsync("//HomePage");
        }

    }
}
