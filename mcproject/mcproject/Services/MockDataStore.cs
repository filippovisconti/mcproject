using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using mcproject.Models;
using SQLite;
using Xamarin.Essentials;

namespace mcproject.Services
{
    public static class MockDataStore
    {
        //static List<Item> items;
        static SQLiteAsyncConnection localDB;


        static async Task Init()
        {
            if (localDB != null) return;

            // absolute path to db file
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "LocalDb.db");
            localDB = new SQLiteAsyncConnection(dbPath);
            await localDB.CreateTableAsync<Event>();
        }

        public static async Task AddItemAsync(Event item)
        {
            await Init();
            await localDB.InsertAsync(item);

        }

        public static async Task UpdateItemAsync(Event item)
        {
            await Init();
            await localDB.UpdateAsync(item);
        }

        public static async Task DeleteItemAsync(string id)
        {
            await Init();
            await localDB.DeleteAsync<Event>(id);
        }

        public static async Task<Event> GetItemAsync(string id)
        {
            await Init();
            var evento = await localDB.GetAsync<Event>(id);
            return evento;
        }

        public static async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            await Init();
            List<Event> eventi = await localDB.Table<Event>().ToListAsync();
            return eventi;
        }
    }
}
