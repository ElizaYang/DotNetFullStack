using System.Collections.Generic;
using System.Threading.Tasks;
using FriendsApp.API.Models;

namespace FriendsApp.API.Data
{
    public interface IUserOpRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll(); // return true if has changes
        Task<IEnumerable<User>> GetUsers(); // return a list of users
        Task<User> GetUser(int id); // return individual user
    }
}