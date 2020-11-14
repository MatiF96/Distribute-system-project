using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> EditUserRole(int userId, string role);
        Task<bool> DeleteUser(int userId);
    }
}
