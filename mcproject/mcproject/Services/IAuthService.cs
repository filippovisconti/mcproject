using System.Threading.Tasks;

namespace mcproject.Services
{
    public interface IAuthService
    {

        bool IsSignedIn();

        Task<bool> CreateUser(string username, string email, string password);
        Task ResetPassword(string email);

        Task<string> SignIn(string email, string password);
        Task<string> SignInAnonymously();
        void SignOut();

        Task<Models.User> RetrieveUserInfo();
    }
}
