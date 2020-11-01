using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;
using CinemaSystem.Services.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace CinemaSystem.Services
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> EditUserRole(int userId, string role);
        Task<bool> DeleteUser(int userId);
    }
}
