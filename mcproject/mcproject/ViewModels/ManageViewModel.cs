using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace mcproject.ViewModels
{

    public class ManageViewModel : ViewModelBase
    {

        public Collection<string> AvailableSports
        {

            get => Services.Constants.Sport;
        }

        public ManageViewModel()
        {
            GoToEvents = new AsyncCommand(OnGoToEvents);


        }

        private async Task OnGoToEvents()
        {
            await Shell.Current.GoToAsync("EventsManagePage");
        }

        public Collection<string> City
        {
            get => Services.Constants.City;
        }


        private string _SelectedCity;
        public string SelectedCity
        {
            get => _SelectedCity;
            set => SetProperty(ref _SelectedCity, value);
        }
        public ICommand GoToEvents { get; }
    }

}
