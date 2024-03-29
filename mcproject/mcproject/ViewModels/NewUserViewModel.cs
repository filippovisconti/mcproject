﻿using System;
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
        private string firstName;
        private string lastName;

        #region Properties
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string RepPassword
        {
            get => repPassword;
            set => SetProperty(ref repPassword, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string TelegramUsername
        {
            get => telegramUsername;
            set => SetProperty(ref telegramUsername, value);
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
        #endregion

        private async void OnSignUp()
        {
            try
            {
                if (Password != RepPassword) throw new Exception("Different Passwords");

                var authService = DependencyService.Resolve<IAuthService>();
                var token = await authService.CreateUser(FirstName + LastName, Email, Password);

                await Xamarin.Forms.Shell.Current.GoToAsync("//JoinPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Shell.Current
                    .DisplayAlert("Sign-up error", "An error occured: " + ex.Message, "OK");
            }
        }

        private async void OnBypassLogin() // FIXME to be removed
        {
            await Xamarin.Forms.Shell.Current.GoToAsync("//JoinPage");
        }

    }
}
