using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using mcproject.Models;
using mcproject.Services;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class SumUpViewModel : ViewModelBase, IQueryAttributable
    {
        EventoSportivo eventoSportivo;
        private readonly FirebaseDB db = FirebaseDB.Instance;
        public SumUpViewModel()
        {
            getEvento();

            this.Sport = eventoSportivo.Sport;
            this.Date = eventoSportivo.DateAndTime;
            this.Level = eventoSportivo.Level;
            this.TG = eventoSportivo.TGUsername;
            this.City = eventoSportivo.City;
            this.Note = eventoSportivo.Notes;

            //bottone t.me/nomeutente
        }

        private void getEvento()
        {
            _ = Task.Run(async () =>
            {
                eventoSportivo = (await db.GetEventoAsync(ID));
                OnPropertyChanged(nameof(eventoSportivo));

            });
        }

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

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            this.ID = Convert.ToInt32(HttpUtility.UrlDecode(query["ID"]));
        }

        public void GetAttributes()
        {
            IDictionary<string, string> openWith = new Dictionary<string, string>();

            openWith.Add("ID", "SelectedEvent.ID");

            ApplyQueryAttributes(openWith);

        }

    }
}
