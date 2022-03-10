using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mcproject.Services
{
    public interface IDataStore<T, W>
    {
        void Init();
        void Close();
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);

        Task<bool> AddUserInfoAsync(W item);
        Task<bool> UpdateUserInfoAsync(W item);
        Task<bool> DeleteUserInfoAsync(string uid);

        T GetItem(string id);
        IEnumerable<T> GetItems();

        W GetUserInfo(string id);
    }
}
