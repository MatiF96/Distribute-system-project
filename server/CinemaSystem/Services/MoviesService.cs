using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;
using CinemaSystem.Repositories;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<MovieDto> Add(AddMovieDto movie)
        {
            var entity = new Movie {
                MovieTitle = movie.Title,
                MovieDuration = movie.Duration
            };
            var newMovie = await _moviesRepository.Add(entity);
            return new MovieDto(newMovie);
        }

        public async Task<int?> Delete(int movieId)
        {
            return await _moviesRepository.Delete(movieId);
        }

        public async Task<MovieDto> Edit(int movieId, EditMovieDto movie)
        {
            var entity = await _moviesRepository.GetById(movieId);
            if (entity == null) return null;
            if (!string.IsNullOrEmpty(movie.Title))
            {
                entity.MovieTitle = movie.Title;
            }
            if (movie.Duration != null && movie.Duration > 0)
            {
                entity.MovieDuration = (int)movie.Duration;
            }
            var editedMovie = await _moviesRepository.Edit(entity);
            return new MovieDto(editedMovie);
        }

        public async Task<IList<MovieDto>> GetAll()
        {
            var movies = await _moviesRepository.GetAll();
            return movies.Select(m => new MovieDto(m)).ToList();
        }

        public async Task<MovieDto> GetById(int movieId)
        {
            var movie = await _moviesRepository.GetById(movieId);
            return movie == null ? null : new MovieDto(movie);
        }

        public async Task<IList<ShowingDto>> GetShowings(int movieId)
        {
            var showings = await _moviesRepository.GetShowings(movieId);
            if (showings == null) return null;
            return showings.Select(s => new ShowingDto {
                Id = s.ShowingId,
                Date = s.ShowingDate,
                Movie = new MovieDto(s.ShowingMovie)
            }).ToList();
        }
    }
}
