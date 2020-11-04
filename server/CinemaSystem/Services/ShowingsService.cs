using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;
using CinemaSystem.Repositories;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public class ShowingsService : IShowingsService
    {
        private readonly IShowingsRepository _showingsRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IHalesRepository _halesRepository;

        public ShowingsService(IShowingsRepository showingsRepository, IHalesRepository halesRepository, IMoviesRepository moviesRepository)
        {
            _showingsRepository = showingsRepository;
            _halesRepository = halesRepository;
            _moviesRepository = moviesRepository;
        }

        public async Task<ShowingDto> AddShowing(AddShowingDto showing)
        {
            var movie = await _moviesRepository.GetById(showing.MovieId);
            var hall = await _halesRepository.GetById(showing.HallId);
            if (movie == null || hall == null) return null;
            var newShowing = new Showing {
                ShowingDate = showing.Date,
                ShowingMovie = movie,
                ShowingHall = hall
            };
            var result = await _showingsRepository.Add(newShowing);
            return new ShowingDto(result);
        }

        public async Task<int?> DeleteShowing(int showingId)
        {
            return await _showingsRepository.Delete(showingId);
        }

        public Task<ShowingDto> EditShowing(int showingId, AddShowingDto showing)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ShowingDto>> GetAll()
        {
            var showings = await _showingsRepository.GetAll();
            return showings.Select(s => new ShowingDto(s)).ToList();
        }

        public Task<ShowingDto> GetById(int showingId)
        {
            throw new NotImplementedException();
        }
    }
}
