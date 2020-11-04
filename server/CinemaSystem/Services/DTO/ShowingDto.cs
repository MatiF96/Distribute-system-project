using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;

namespace CinemaSystem.Services.DTO
{
    public class ShowingDto
    {
        public int Id { get; set; }
        public HallDto Hall { get; set; }
        public MovieDto Movie { get; set; }
        public DateTime Date { get; set; }

        public ShowingDto() { }
        public ShowingDto(Showing showing)
        {
            Id = showing.ShowingId;
            Hall = new HallDto(showing.ShowingHall);
            Movie = new MovieDto(showing.ShowingMovie);
            Date = showing.ShowingDate;
        }
    }
}
