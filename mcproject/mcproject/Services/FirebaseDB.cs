using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mcproject.Models;

namespace mcproject.Services
{
    public sealed class FirebaseDB

    {
        private static readonly FirebaseDB instance = new();

        public static FirebaseDB Instance
        {
            get
            {
                return instance;
            }
        }


        public readonly FirebaseClient client = null;
        #region properties
        readonly string EventList = "EventList";
        readonly string CitiesList = "CitiesList";      // TODO to be implemented
        readonly string SportsList = "SportsList";
        readonly string LevelsList = "LevelsList";
        readonly string UserInfoList = "UserInfoList";
        #endregion

        #region init and dispose
        private FirebaseDB()
        {
            client = new FirebaseClient("https://mcproject-1234-default-rtdb.europe-west1.firebasedatabase.app/");

        }

        static FirebaseDB()
        {

        }

        #endregion

        #region CRUD evento sportivo
        public async Task AddNewEventoSportivoAsync(EventoSportivo item)
        {
            var eventID = (await GetAllEventiAsync()).Count;
            await client.Child(EventList).PostAsync(new EventoSportivo()
            {
                ID = eventID++,
                Owner = item.Owner,
                Sport = item.Sport,
                City = item.City,
                Level = item.Level,
                DateAndTime = item.DateAndTime,
                Notes = item.Notes,
                TGUsername = item.TGUsername,
                Icon = item.Icon
            });
        }
        public async Task UpdateEventoSportivoAsync(EventoSportivo item)
        {
            var toBeUpdated = (await client.Child(EventList).OnceAsync<EventoSportivo>())
                .Where(a => a.Object.ID == item.ID).FirstOrDefault();

            await client.Child(EventList).Child(toBeUpdated.Key)
                .PutAsync(new EventoSportivo()
                {
                    Owner = item.Owner,
                    Sport = item.Sport,
                    City = item.City,
                    Level = item.Level,
                    DateAndTime = item.DateAndTime,
                    Notes = item.Notes,
                    TGUsername = item.TGUsername,
                    Icon = item.Icon
                });
        }
        public async Task DeleteEventoSportivoAsync(EventoSportivo item)
        {
            var toBeDeleted = (await client.Child(EventList).OnceAsync<EventoSportivo>())
                .Where(a => a.Object.ID == item.ID).FirstOrDefault();

            await client.Child(EventList).Child(toBeDeleted.Key).DeleteAsync();
        }

        public async Task<EventoSportivo> GetEventoAsync(int id)
        {
            return (await client.Child(EventList).OnceAsync<EventoSportivo>())
               .Where(a => a.Object.ID == id).FirstOrDefault().Object;
        }

        public async Task<IList<EventoSportivo>> GetAllEventiAsync()
        {
            var events = (await client.Child(EventList)
                .OnceAsync<EventoSportivo>())
                .Select(item => new EventoSportivo
                {
                    ID = item.Object.ID,
                    Owner = item.Object.Owner,
                    Sport = item.Object.Sport,
                    City = item.Object.City,
                    Level = item.Object.Level,
                    DateAndTime = item.Object.DateAndTime,
                    Notes = item.Object.Notes,
                    TGUsername = item.Object.TGUsername,
                    Icon = item.Object.Icon
                }).ToList();

            return events;
        }


        #endregion

        #region CRUD User
        public async Task AddUserInfoAsync(User item)
        {
            var userID = (await GetAllEventiAsync()).Count;
            await client.Child(UserInfoList).PostAsync(new User()
            {
                ID = userID++,
                Name = item.Name,
                TelegramUsername = item.TelegramUsername,
                EmailAddress = item.EmailAddress
            });
        }
        public async Task UpdateUserInfoAsync(User item)
        {
            var toBeUpdated = (await client.Child(UserInfoList).OnceAsync<User>())
                .Where(a => a.Object.ID == item.ID).FirstOrDefault();

            await client.Child(UserInfoList).Child(toBeUpdated.Key)
                .PutAsync(new User()
                {
                    Name = item.Name,
                    TelegramUsername = item.TelegramUsername,
                    EmailAddress = item.EmailAddress
                });
        }
        public async Task DeleteUserInfoAsync(User item)
        {
            var toBeDeleted = (await client.Child(UserInfoList).OnceAsync<User>())
                .Where(a => a.Object.ID == item.ID).FirstOrDefault();

            await client.Child(UserInfoList).Child(toBeDeleted.Key).DeleteAsync();
        }

        public async Task<User> GetUserInfo(int id)
        {
            return (await client.Child(UserInfoList).OnceAsync<User>())
               .Where(a => a.Object.ID == id).FirstOrDefault().Object;
        }
        #endregion

        #region retrive available sports and difficulty levels
        public async Task<IList<Sport>> GetAvailableSportsListAsync()
        {
            //return (await client.Child(SportsList)
            //    .OnceAsync<Sport>())
            //    .Select(item => item.Object);

            var l1 = await client.Child(SportsList).OnceAsync<Sport>();
            var l2 = l1.Select(item => item.Object);
            return l2.ToList();

        }

        public async Task<IList<Difficulty>> GetAvailableLevelsListAsync()
        {
            //return (await client.Child(LevelsList)
            //    .OnceAsync<Difficulty>())
            //    .Select(item => item.Object);

            var l1 = await client.Child(LevelsList).OnceAsync<Difficulty>();
            var l2 = l1.Select(item => item.Object);
            return l2.ToList();

        }

        #endregion

        #region look for an event


        /* --- da correggere --- */
        public async Task<IList<EventoSportivo>> SearchBySportLevelCityAsync(string sport, string level, string city)
        {

            var a = await client.Child(EventList).OnceAsync<EventoSportivo>();
            var lst = a.Where(a => a.Object.Sport.Name == sport && a.Object.Level.Level == level && a.Object.City.Name == city);
            var l2 = lst.Select(item => item.Object);
            return l2
                .ToList();

        }


        #endregion
    }
}
