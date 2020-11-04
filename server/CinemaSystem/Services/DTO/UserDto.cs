using CinemaSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
        public UserDto() { }

    }
}
