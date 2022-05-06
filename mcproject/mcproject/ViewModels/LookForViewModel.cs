
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using mcproject.Models;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class LookForViewModel : ViewModelBase
    {
        private ObservableCollection<EventoSportivo> _Eventi;
        public ObservableCollection<EventoSportivo> Eventi
        {
            get => _Eventi;
            set => SetProperty(ref _Eventi, value);
        }

        public AsyncCommand<EventoSportivo> SelectedCommand { get; }

        public LookForViewModel()
        {
            SelectedCommand = new AsyncCommand<EventoSportivo>(Selected);

            Eventi = new ObservableCollection<EventoSportivo>();

            Eventi.Add(new EventoSportivo
            {
                Sport = new Sport()
                {
                    Name = "Golf"
                },
                Level = new Difficulty()
                {
                    Level = "Principiante"
                },
                City = "Milano",
                DateAndTime = new DateTime(2022, 6, 23),
                TGUsername = "tgusr2",
                Notes = "None"

            });

            Eventi.Add(new EventoSportivo
            {
                Sport = new Sport()
                {
                    Name = "Golf"
                },
                Level = new Difficulty()
                {
                    Level = "Blaaaa"
                },
                City = "Roma",
                DateAndTime = new DateTime(2022, 6, 24),
                TGUsername = "tgusr3",
                Notes = "None"

            });

            Eventi.Add(new EventoSportivo
            {
                Sport = new Sport()
                {
                    Name = "Pallavolo"
                },
                Level = new Difficulty()
                {
                    Level = "Avanzato"
                },
                City = "Milano",
                DateAndTime = new DateTime(2022, 6, 25),
                TGUsername = "tgusr2",
                Notes = "None"

            });

            Eventi.Add(new EventoSportivo
            {
                Sport = new Sport()
                {
                    Name = "Citofoni"
                },
                Level = new Difficulty()
                {
                    Level = "Fraaaa"
                },
                City = "Milano",
                DateAndTime = new DateTime(2022, 6, 26),
                TGUsername = "tgusr3",
                Notes = "None"

            });

            OnPropertyChanged(nameof(Eventi));
        }


        public EventoSportivo PreviouslySelected;
        private EventoSportivo _SelectedEvent;

        public EventoSportivo SelectedEvent
        {
            get => _SelectedEvent;
            set => SetProperty(ref _SelectedEvent, value);
        }


        async Task Selected(EventoSportivo eventoSportivo)
        {
            if (eventoSportivo == null)
                return;

            await Application.Current.MainPage.DisplayAlert("Selected", eventoSportivo.Sport.Name, "OK");
        }


        /*   public void ApplyQueryAttributes(IDictionary<string, string> query)
           {
               this.SelectedSport = HttpUtility.UrlDecode(query["sport"]);
               this.SelectedLevel = HttpUtility.UrlDecode(query["level"]);
               this.SelectedCity = HttpUtility.UrlDecode(query["city"]);
           }

           public void GetAttributes()
           {
               IDictionary<string, string> openWith = new Dictionary<string, string>();

               openWith.Add("sport", "SelectedSport");
               openWith.Add("level", "SelectedLevel");
               openWith.Add("city", "SelectedCity");

               ApplyQueryAttributes(openWith);
           }
        */

    }
}
