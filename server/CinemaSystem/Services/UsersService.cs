using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Repositories;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _usersRepository.DeleteUser(userId);
        }

        public async Task<UserDto> EditUserRole(int userId, string role)
        {
            var user = await _usersRepository.GetById(userId);
            if (user == null) return null;
            user.UserType = role;
            await _usersRepository.EditUser(user);
            return new UserDto(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _usersRepository.GetAll();
            return users.ToList().Select(user => new UserDto(user)).ToList();
        }
    }
}
