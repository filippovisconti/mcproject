using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using MvvmHelpers.Commands;
using mcproject.Models;
using System.Collections.Generic;
using mcproject.Services;

namespace mcproject.ViewModels
{
    public class JoinViewModel : ViewModelBase
    {

        private IList<Sport> _AvailableSports;
        public IList<Sport> AvailableSports
        {

            get => _AvailableSports;
            set => SetProperty(ref _AvailableSports, value);
        }

        private IList<Difficulty> _Level;
        public IList<Difficulty> Level
        {
            get => _Level;
            set => SetProperty(ref _Level, value);
        }

        private IList<City> _Cities;
        public IList<City> Cities
        {
            get => _Cities;
            set => SetProperty(ref _Cities, value);
        }


        public ICommand Search { get; }
        public JoinViewModel()
        {
            Search = new AsyncCommand(OnSearch);
            PopulateThoseBitches();
        }

        private async Task OnSearch()
        {
            //await Shell.Current.GoToAsync("LookForPage");
            await Shell.Current.GoToAsync($"LookForPage?sport={SelectedSport}&level={SelectedLevel}&city={SelectedCity}");
        }

        private readonly FirebaseDB db = FirebaseDB.Instance;
        private void PopulateThoseBitches()
        {
            _ = Task.Run(async () =>
            {

                Level = new ObservableCollection<Difficulty>(await db.GetAvailableLevelsListAsync());
                OnPropertyChanged(nameof(Level));
            });
            _ = Task.Run(async () =>
            {

                AvailableSports = new ObservableCollection<Sport>(await db.GetAvailableSportsListAsync());
                OnPropertyChanged(nameof(AvailableSports));

            });
            _ = Task.Run(async () =>
            {

                Cities = new ObservableCollection<City>(Constants.cities);
                OnPropertyChanged(nameof(Cities));

            });

        }




        private Sport _SelectedSport;
        public Sport SelectedSport
        {
            get => _SelectedSport;
            set => SetProperty(ref _SelectedSport, value);
        }

        private Difficulty _SelectedLevel;
        public Difficulty SelectedLevel
        {
            get => _SelectedLevel;
            set => SetProperty(ref _SelectedLevel, value);
        }

        private City _SelectedCity;
        public City SelectedCity
        {
            get => _SelectedCity;
            set => SetProperty(ref _SelectedCity, value);
        }
    }
}
