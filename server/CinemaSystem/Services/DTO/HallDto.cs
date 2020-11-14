using CinemaSystem.Database.Models;

namespace CinemaSystem.Services.DTO
{
    public class HallDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HallDto() { }

        public HallDto(Hall hall)
        {
            Id = hall.HallId;
            Name = hall.HallName;
        }
    }
}
