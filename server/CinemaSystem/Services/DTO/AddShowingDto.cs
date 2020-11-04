using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
