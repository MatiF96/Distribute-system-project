using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using CinemaSystem.Repositories;
using CinemaSystem.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;
using System.Text;

namespace CinemaSystem.Services
{
    public class AuthService : IAuthService
    {


        private readonly IUsersRepository _usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserDto> Login(AuthDto credentials)
        {
            var user = await _usersRepository.GetByUserName(credentials.Username);
            if (user == null || !await IsPaswordValid(credentials.Password, user.UserPassword)) return null;
            return new UserDto(user);
        }

        public async Task<UserDto> Register(AuthDto credentials)
        {   
            var user = new User
            {
                UserLogin = credentials.Username,
                UserPassword = await HashPassword(credentials.Password),
                UserType = UserRoles.ADMIN,
            };

            var result = await _usersRepository.AddUser(user);
            return new UserDto(result);
        }

        private async Task<string> HashPassword(string password)
        {
            var hashBytes = await GetPasswordHash(password);
            return Convert.ToBase64String(hashBytes);
        }
        private async Task<byte[]> GetPasswordHash(string password)
        {
            var argon2 = new Argon2i(Encoding.UTF8.GetBytes(password))
            {
                DegreeOfParallelism = 8,
                MemorySize = 4096,
                Iterations = 40
            };
            return await argon2.GetBytesAsync(128); 
        }
        private async Task<bool> IsPaswordValid(string password, string hashedPassword)
        {
            var storedHash = Convert.FromBase64String(hashedPassword);
            var passwordHashBytes = await GetPasswordHash(password);
            for (int i = 0; i < passwordHashBytes.Length; i++)
            {
                if (passwordHashBytes[i] != storedHash[i]) return false;
            }
            return true;
        }
    }
}
