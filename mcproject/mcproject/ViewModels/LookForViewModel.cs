
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

        public AsyncCommand SelectedCommand { get; }
        //public AsyncCommand JoinCommand { get; }

        public LookForViewModel()
        {
            SelectedCommand = new AsyncCommand(Selected);
            //JoinCommand = new AsyncCommand(JoinMethod);

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


        public async Task Selected()
        {
            if (SelectedEvent == null)
                return;

            await Shell.Current.GoToAsync($"SumUpPage?ID={SelectedEvent.ID}");
        }

       // private async Task JoinMethod()
       // {
       //     await Shell.Current.GoToAsync("");
       // }

          
        }
}
