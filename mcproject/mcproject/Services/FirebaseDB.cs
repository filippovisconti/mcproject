using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Offline;
using Firebase.Database.Query;
using mcproject.Models;

namespace mcproject.Services
{
    public class FirebaseDB : IDataStore<EventoSportivo, User>

    {
        FirebaseClient client = null;
        string EventList = "EventList";
        string UserInfoList = "UserInfoList";

        public FirebaseDB()
        {
        }


        public void Init()
        {
            client = new FirebaseClient("https://mcproject-1234-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public void Close()
        {
            client.Dispose();
        }

        public async Task<bool> AddItemAsync(EventoSportivo item)
        {
            if (client == null) Init();

            var res = await client
                .Child(EventList)
                .PostAsync(item);

            return res != null;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public EventoSportivo GetItem(string id)
        {
            return GetItems().
                FirstOrDefault<EventoSportivo>(a => a.ID.Equals(id));

        }

        public ObservableCollection<EventoSportivo> GetItems()
        {
            if (client == null) Init();

            return client
                .Child(EventList)
                .AsObservable<EventoSportivo>()
                .AsObservableCollection();
        }

        public async Task<bool> UpdateItemAsync(EventoSportivo item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddUserInfoAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserInfoAsync(User item)
        {
            throw new NotImplementedException();
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

        public User GetUserInfo(string email)
        {
            if (client == null) Init();

            var res = client
                .Child(UserInfoList)
                .AsObservable<User>()
                .AsObservableCollection();

            foreach (User user in res)
                if (user.EmailAddress.Equals(email)) return user;
            return null;
        }


    }
}
