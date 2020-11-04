using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;

namespace CinemaSystem.Services.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public MovieDto(){}

        public MovieDto(Movie movie)
        {
            Id = movie.MovieId;
            Title = movie.MovieTitle;
            Duration = movie.MovieDuration;
        }

    }
}
