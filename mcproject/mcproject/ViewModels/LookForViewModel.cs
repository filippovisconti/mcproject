
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using mcproject.Models;
using mcproject.Services;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class LookForViewModel : ViewModelBase, IQueryAttributable
    {
        private ObservableCollection<EventoSportivo> _Eventi;
        public ObservableCollection<EventoSportivo> Eventi
        {
            get => _Eventi;
            set => SetProperty(ref _Eventi, value);
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

        public EventoSportivo PreviouslySelected;
        private EventoSportivo _SelectedEvent;

        public EventoSportivo SelectedEvent
        {
            get => _SelectedEvent;
            set => SetProperty(ref _SelectedEvent, value);
        }


        public AsyncCommand SelectedCommand { get; }

        private readonly FirebaseDB db = FirebaseDB.Instance;






        public LookForViewModel()
        {

            SelectedCommand = new AsyncCommand(Selected);

        }

        private void LoadEvent()
        {
            //if (SelectedSport == null) throw new NullReferenceException();
            _ = Task.Run(async () =>
              {

                  Eventi = new ObservableCollection<EventoSportivo>(
                      await db.SearchBySportLevelCityAsync(SelectedSport.Name, SelectedLevel.Level, SelectedCity.Name));
                  OnPropertyChanged(nameof(Eventi));

              });
        }


        public async Task Selected()
        {
            // await Shell.Current.GoToAsync($"..?parameterToPassBack={parameterValueToPassBack}");
            await Shell.Current.GoToAsync($"SumUpPage?ID={SelectedEvent.ID}");
        }


        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            SelectedSport = new Sport()
            {
                Name = (HttpUtility.UrlDecode(query["sport"]))
            };
            SelectedLevel = new Difficulty()
            {
                Level = (HttpUtility.UrlDecode(query["level"]))
            };
            SelectedCity = new City()
            {
                Name = (HttpUtility.UrlDecode(query["city"]))
            };

            // wait for the variables to be filled with the right value
            // while (SelectedSport == null || SelectedLevel == null || SelectedCity == null) ;

            LoadEvent();
        }

        public void GetAttributes()
        {
            IDictionary<string, string> openWith = new Dictionary<string, string>
            {
                { "sport", "SelectedSport" },
                { "level", "SelectedLevel" },
                { "city", "SelectedCity" }
            };

            ApplyQueryAttributes(openWith);

        }



    }
}
