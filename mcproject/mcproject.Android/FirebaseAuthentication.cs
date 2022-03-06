using Firebase.Auth;
using mcproject.Droid;
using mcproject.Models;
using mcproject.Services;
using System;
using System.Threading.Tasks;


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

        User IAuthService.RetrieveUserInfo()
        {
            throw new NotImplementedException();
        }
    }
}