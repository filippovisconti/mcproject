using Firebase.Auth;
using mcproject.Droid;
using mcproject.Models;
using mcproject.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(FirebaseAuthentication))]
namespace mcproject.Droid
{
    public class FirebaseAuthentication : IAuthService
    {

        public async Task<bool> CreateUser(string username, string email, string password)
        {
            var authResult = await FirebaseAuth.Instance
                    .CreateUserWithEmailAndPasswordAsync(email, password);

            var userProfileChangeRequestBuilder = new UserProfileChangeRequest.Builder();
            userProfileChangeRequestBuilder.SetDisplayName(username);

            var userProfileChangeRequest = userProfileChangeRequestBuilder.Build();
            await authResult.User.UpdateProfileAsync(userProfileChangeRequest);

            return await Task.FromResult(true);
        }

        public bool IsSignedIn()
            => FirebaseAuth.Instance.CurrentUser != null;

        public async Task ResetPassword(string email)
            => await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);

        public async Task<string> SignIn(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = authResult.User.GetIdToken(false);
            return token.Result.ToString();
        }

        public void SignOut()
            => FirebaseAuth.Instance.SignOut();

        public async Task<Models.User> RetrieveUserInfo()
        {
            try
            {
                if (IsSignedIn())
                {
                    var currentUser = FirebaseAuth.Instance.CurrentUser;
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
            var authResult = await FirebaseAuth.Instance.SignInAnonymouslyAsync();
            var token = authResult.User.GetIdToken(false);
            return token.Result.ToString();
        }
    }
}