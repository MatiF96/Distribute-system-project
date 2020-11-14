using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaSystem.Services.DTO
{
    public class AddShowingDto
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int HallId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
