using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace mcproject.Services
{
    public interface IDataStore<T, W>
    {
        void Init();
        void Close();

        Task AddItemAsync(T item);
        Task UpdateItemAsync(T item);
        Task DeleteItemAsync(string id);

        Task AddUserInfoAsync(W item);
        Task UpdateUserInfoAsync(W item);
        Task DeleteUserInfoAsync(string uid);

        T GetItem(string id);
        ObservableCollection<T> GetAllItems();

        Task<W> GetUserInfo(string id);
    }
}
