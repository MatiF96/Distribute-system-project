using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Services.Models;
namespace CinemaSystem.Services
{
    public interface IAuthService
    {
        Task<UserDto> Register(AuthDto credentials);
        Task<UserDto> Login(AuthDto credentials);
    }
}
