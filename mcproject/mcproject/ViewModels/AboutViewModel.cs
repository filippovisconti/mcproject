using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            GoToHomePage = new AsyncCommand(goToHomePage);
                   }

        public AsyncCommand GoToHomePage { get; }

        public async Task goToHomePage()
        {
            await Shell.Current.GoToAsync("HomePage");
        }
    }
}
