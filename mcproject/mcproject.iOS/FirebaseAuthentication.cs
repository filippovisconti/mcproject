using System;
using System.Threading.Tasks;
using Firebase.Auth;
using mcproject.Services;
using Xamarin.Forms;

namespace mcproject.iOS
{
    public class FirebaseAuthentication : IAuthService
    {
        public async Task<bool> CreateUser(string username, string email, string password)
        {
            var authResult = await Auth.DefaultInstance
                   .CreateUserAsync(email, password);

            var changeRequest = authResult.User.ProfileChangeRequest();
            changeRequest.DisplayName = username;
            await changeRequest.CommitChangesAsync();

            return await Task.FromResult(true);
        }

        public bool IsSignedIn()
        {
            var currentUser = Auth.DefaultInstance.CurrentUser;
            return currentUser != null;
        }

        public async Task ResetPassword(string email)
        {
            await Auth.DefaultInstance.SendPasswordResetAsync(email);
        }

        public async Task<string> SignIn(string email, string password)
        {
            var authResult = await Auth.DefaultInstance
                .SignInWithPasswordAsync(email, password);

            return await authResult.User.GetIdTokenAsync();
        }

        public void SignOut()
        {
            Auth.DefaultInstance.SignOut(out _);
        }

        public async Task<Models.User> RetrieveUserInfo()
        {
            try
            {
                if (IsSignedIn())
                {
                    var currentUser = Auth.DefaultInstance.CurrentUser;
                    return new Models.User(currentUser.DisplayName, currentUser.Email);

                }
                else
                {
                    throw new Exception("You are not signed in.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Shell.Current
                    .DisplayAlert("Retrieval of User Info", "An error occured: " + ex.Message, "OK");
                return null;
            }
        }

        public async Task<string> SignInAnonymously()
        {
            var authResult = await Auth.DefaultInstance
                .SignInAnonymouslyAsync();

            return await authResult.User.GetIdTokenAsync();
        }
    }
}
