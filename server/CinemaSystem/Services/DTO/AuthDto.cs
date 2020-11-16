using System.ComponentModel.DataAnnotations;

namespace CinemaSystem.Services.DTO
{
    public class AuthDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
