using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mcproject.Models;

namespace mcproject.Services
{
    public class FirebaseDB : IDataStore<EventoSportivo, User>

    {
        FirebaseClient client = null;
        readonly string EventList = "EventList";
        readonly string SportsList = "SportsList";
        readonly string LevelsList = "LevelsList";
        readonly string UserInfoList = "UserInfoList";


        public void Init()
        {
            client = new FirebaseClient("https://mcproject-1234-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public void Close()
        {
            client.Dispose();
        }

        public async Task AddItemAsync(EventoSportivo item)
        {
            if (client == null) Init();

            await client
                .Child(EventList)
                .PostAsync(item);

        }

        public Task DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public EventoSportivo GetItem(string id)
        {
            return GetAllItems().
                FirstOrDefault(a => a.ID.Equals(id));

        }

        internal Task AddItemAsync(string v)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<EventoSportivo> GetAllItems()
        {
            if (client == null) Init();

            return client
                .Child(EventList)
                .AsObservable<EventoSportivo>()
                .AsObservableCollection();
        }

        public async Task UpdateItemAsync(EventoSportivo item)
        {
            if (client == null) Init();

            var res = (await client
                .Child(UserInfoList)
                .OnceAsync<EventoSportivo>())
                .FirstOrDefault(a => a.Object.ID == item.ID);

            await client
                .Child(EventList)
                .Child(res.Key)
                .PutAsync(res.Object);
        }

        public async Task AddUserInfoAsync(User item)
        {
            if (client == null) Init();

            await client
                .Child(UserInfoList)
                .PostAsync(item);
        }

        public async Task UpdateUserInfoAsync(User item)
        {
            if (client == null) Init();

            var res = (await client
                .Child(UserInfoList)
                .OnceAsync<User>())
                .FirstOrDefault(a => a.Object.EmailAddress == item.EmailAddress);

            await client
                .Child(UserInfoList)
                .Child(res.Key)
                .PutAsync(res.Object);
        }

        public async Task DeleteUserInfoAsync(string email)
        {
            if (client == null) Init();

            var res = (await client
                .Child(UserInfoList)
                .OnceAsync<User>())
                .FirstOrDefault(a => a.Object.EmailAddress == email);

            await client
                .Child(UserInfoList)
                .Child(res.Key)
                .DeleteAsync();
        }

        public async Task<User> GetUserInfo(string email)
        {
            if (client == null) Init();

            var res = (await client
                .Child(UserInfoList)
                .OnceAsync<User>())
                .FirstOrDefault(a => a.Object.EmailAddress == email);

            return res.Object;

        }

        public ObservableCollection<string> GetAvailableSportsList()
        {
            if (client == null) Init();

            return client
                .Child(SportsList)
                .AsObservable<string>()
                .AsObservableCollection();
        }

        public ObservableCollection<string> GetAvailableLevelsList()
        {
            if (client == null) Init();

            return client
                .Child(LevelsList)
                .AsObservable<string>()
                .AsObservableCollection();
        }

        public async Task AddSportAsync(string item)
        {
            if (client == null) Init();

            await client
                .Child(SportsList)
                .PostAsync(item);

        }

        public async Task AddLevelAsync(string item)
        {
            if (client == null) Init();

            await client
                .Child(LevelsList)
                .PostAsync(item);

        }
    }
}
