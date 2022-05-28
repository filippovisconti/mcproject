using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using mcproject.Models;
using mcproject.Services;
using MvvmHelpers.Commands;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class SumUpViewModel : ViewModelBase, IQueryAttributable
    {
        EventoSportivo eventoSportivo;
        private readonly FirebaseDB db = FirebaseDB.Instance;
        public AsyncCommand OpenTelegramCommand { get; }

        public SumUpViewModel()
        {


            OpenTelegramCommand = new AsyncCommand(OnOpenTelegram);

            //bottone t.me/nomeutente
        }

        private string _iconName;
        public string IconName
        {
            get => _iconName;
            set => SetProperty(ref _iconName, value);
        }

        private string GetIcon(string name)
        {
            //var image = new Image { Source = "xamarin_logo.png" };
            //if (name == "Padel")
            //    image = new Image { Source = "padel_icon.jpg" };

            return $"{name}_icon.png";
        }

        private async Task OnOpenTelegram()
        {
            Uri uri = new("https://t.me/" + TG);
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                // No browser installed ?!?!}
            }
        }

        private void GetEvento()
        {
            _ = Task.Run(async () =>
            {
                eventoSportivo = (await db.GetEventoAsyncByID(ID));
                OnPropertyChanged(nameof(eventoSportivo));

                Sport = eventoSportivo.Sport;
                Date = eventoSportivo.DateAndTime;
                Level = eventoSportivo.Level;
                TG = eventoSportivo.TGUsername;
                City = eventoSportivo.City;
                Note = eventoSportivo.Notes;
                IconName = GetIcon(Sport.Name);

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

        // this instead is called by magic IDK but it works
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            ID = Convert.ToInt32(HttpUtility.UrlDecode(query["ID"]));

            GetEvento();
        }

        // this never gets called automatically
        //public void GetAttributes()
        //{
        //    IDictionary<string, string> openWith = new Dictionary<string, string>
        //    {
        //        { "ID", "SelectedEvent.ID" }
        //    };

        //    ApplyQueryAttributes(openWith);

        //}

    }
}
