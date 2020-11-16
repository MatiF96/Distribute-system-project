using System.ComponentModel.DataAnnotations;
using CinemaSystem.Database.Models;

namespace CinemaSystem.Services.DTO
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Role { get; set; }

        public UserDto(User user)
        {
            Id = user.UserId;
            Username = user.UserLogin;
            Role = user.UserType;
        }
        public UserDto(Task<User> result) { }

    }
}
