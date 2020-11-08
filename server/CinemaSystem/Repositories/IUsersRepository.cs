using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;

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
