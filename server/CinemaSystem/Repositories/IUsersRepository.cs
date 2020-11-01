using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystem.Repositories
{
    public interface IUsersRepository
    {
        Task<IList<User>> GetAll();
        Task<User> GetByUserName(string username);
        Task<User> GetById(int userId);
        Task<User> AddUser(User user);
        Task<User> EditUser(User user);
        Task<bool> DeleteUser(int userId);
    }
}
