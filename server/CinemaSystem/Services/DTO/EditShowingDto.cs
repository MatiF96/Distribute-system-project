using System;

namespace CinemaSystem.Services.DTO
{
    public class EditShowingDto
    {
        public int? MovieId { get; set; }
        public int? HallId { get; set; }
        public DateTime Date { get; set; }
    }
}
