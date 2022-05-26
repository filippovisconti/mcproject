﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using mcproject.Models;
using mcproject.Services;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class ModifyEventReviewViewModel : ViewModelBase, IQueryAttributable
    {

        EventoSportivo Evento;

        private readonly FirebaseDB db = FirebaseDB.Instance;

        /* NEED TO FIX: L'ICON NON VIENE VISUALIZZATA */

        public string IconName { get; set; }

        private int _ID;
        public int ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }

        private Sport _Sport;
        public Sport Sport
        {
            get => _Sport;
            set => SetProperty(ref _Sport, value);
        }

        private DateTime _Date;
        public DateTime Date
        {
            get => _Date;
            set => SetProperty(ref _Date, value);
        }

        private Difficulty _Level;
        public Difficulty Level
        {
            get => _Level;
            set => SetProperty(ref _Level, value);
        }

        private string _TG;
        public string TG
        {
            get => _TG;
            set => SetProperty(ref _TG, value);
        }

        private City _City;
        public City City
        {
            get => _City;
            set => SetProperty(ref _City, value);
        }

        private string _Note;
        public string Note
        {
            get => _Note;
            set => SetProperty(ref _Note, value);
        }

        public ModifyEventReviewViewModel()
        {
        }


        private void GetEvento()
        {
            _ = Task.Run(async () =>
            {
                Evento = (await db.GetEventoAsyncByID(ID));
                OnPropertyChanged(nameof(Evento));

                Sport = Evento.Sport;
                Date = Evento.DateAndTime;
                Level = Evento.Level;
                TG = Evento.TGUsername;
                City = Evento.City;
                Note = Evento.Notes;

            });
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            ID = Convert.ToInt32(HttpUtility.UrlDecode(query["ID"]));

            GetEvento();
        }

        

        
        /*
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            TG = HttpUtility.UrlDecode(query["tg"]);
            Sport = new Sport()
            {
                Name = HttpUtility.UrlDecode(query["sport"])
            };
            IconName = GetIcon(Sport.Name);
            Date = Convert.ToDateTime(HttpUtility.UrlDecode(query["data"]));
            Level = new Difficulty()
            {
                Level = HttpUtility.UrlDecode(query["level"])
            };
            City = new City()
            {
                Name = HttpUtility.UrlDecode(query["city"])
            };
            Note = HttpUtility.UrlDecode(query["note"]);
            
        }

        public void GetAttributes()
        {
            IDictionary<string, string> openWith = new Dictionary<string, string>
            {
                { "sport", "SelectedSport" },
                { "data", "SelectedData" },
                { "level", "SelectedLevel" },
                { "tg", "SelectedTGusername" },
                { "city", "SelectedCity" },
                { "note", "SelectedNote" }
            };

            ApplyQueryAttributes(openWith);


        }
        */
    }
}
