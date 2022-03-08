using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using mcproject.Models;
using SQLite;
using Xamarin.Essentials;

namespace mcproject.Services
{
    public static class MockDataStore //: IDataStore<EventoSportivo>
    {
        //static List<Item> items;
        static SQLiteAsyncConnection localDB;


        static async Task Init()
        {
            if (localDB != null) return;

            // absolute path to db file
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "LocalDb.db");
            localDB = new SQLiteAsyncConnection(dbPath);
            await localDB.CreateTableAsync<EventoSportivo>();
        }

        public static async Task AddItemAsync(EventoSportivo item)
        {
            await Init();
            await localDB.InsertAsync(item);

        }

        public static async Task UpdateItemAsync(EventoSportivo item)
        {
            await Init();
            await localDB.UpdateAsync(item);
        }

        public static async Task DeleteItemAsync(string id)
        {
            await Init();
            await localDB.DeleteAsync<EventoSportivo>(id);
        }

        public static async Task<EventoSportivo> GetItemAsync(string id)
        {
            await Init();
            var EventoSportivoo = await localDB.GetAsync<EventoSportivo>(id);
            return EventoSportivoo;
        }

        public static async Task<IEnumerable<EventoSportivo>> GetItemsAsync(bool forceRefresh = false)
        {
            await Init();
            List<EventoSportivo> EventoSportivoi = await localDB.Table<EventoSportivo>().ToListAsync();
            return EventoSportivoi;
        }
    }
}
