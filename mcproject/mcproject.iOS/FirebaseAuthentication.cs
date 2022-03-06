using System.Threading.Tasks;
using Firebase.Auth;
using mcproject.Services;

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

        User RetrieveUserInfo()
        {
            if (IsSignedIn()) ;
        }
    }
}
