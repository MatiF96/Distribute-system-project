using System.Threading.Tasks;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public interface IAuthService
    {
        Task<UserDto> Register(AuthDto credentials);
        Task<UserDto> Login(AuthDto credentials);
    }
}
