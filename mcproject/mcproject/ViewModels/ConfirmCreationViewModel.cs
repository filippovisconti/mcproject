using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using mcproject.Models;
using mcproject.Services;
using MvvmHelpers.Commands;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class ConfirmCreationViewModel : ViewModelBase, IQueryAttributable
    {

        public ConfirmCreationViewModel()
        {
            ConfirmCommand = new AsyncCommand(OnConfirm);
        }

        #region properties
        private Sport _sport;
        public Sport Sport
        {
            get => _sport;
            set => SetProperty(ref _sport, value);
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        private Difficulty _level;
        public Difficulty Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        private string _telegramUsername;
        public string TelegramUsername
        {
            get => _telegramUsername;
            set => SetProperty(ref _telegramUsername, value);
        }

        private City _city;
        public City City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _note;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }
        #endregion
        #region set query attributes
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            TelegramUsername = HttpUtility.UrlDecode(query["tg"]);
            Sport = new Sport()
            {
                Name = HttpUtility.UrlDecode(query["sport"])
            };
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
        #endregion

        #region confirm command
        public AsyncCommand ConfirmCommand { get; }

        private async Task OnConfirm()
        {
            User u = await DependencyService.Resolve<IAuthService>().RetrieveUserInfo();

            if (u != null)
            {
                EventoSportivo e = new()
                {
                    Sport = Sport,
                    DateAndTime = Date,
                    Level = Level,
                    TGUsername = TelegramUsername,
                    City = City,
                    Notes = Note,
                    Owner = u.Email,
                    IconName = GetIcon(Sport.Name)

                };
                FirebaseDB db = FirebaseDB.Instance;

                await db.AddNewEventoSportivoAsync(e);

                await Shell.Current
                            .DisplayAlert("Event created", "Everything went smoothly", "OK");

                await Shell.Current
                            .GoToAsync("../JoinPage");
            }
            else
                await Shell.Current
                            .DisplayAlert("Failed", "Retrieval of user info failed.", "OK");
        }

        private string GetIcon(string name)
        {
            //var image = new Image { Source = "xamarin_logo.png" };
            //if (name == "Padel")
            //    image = new Image { Source = "padel_icon.jpg" };

            return $"{name}_icon.png";
        }


        #endregion
    }
}
