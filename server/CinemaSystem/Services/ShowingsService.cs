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

        public async Task<ShowingDto> EditShowing(int showingId, EditShowingDto showing)
        {
            var editedShowing = await _showingsRepository.GetById(showingId);
            if (editedShowing == null) return null;
            if (showing.HallId != null)
            {
                var hall = await _halesRepository.GetById((int)showing.HallId);
                if (hall == null) return null;
                else editedShowing.ShowingHall = hall;

            }

            if (showing.MovieId != null)
            {
                var movie = await _moviesRepository.GetById((int)showing.MovieId);
                if (movie == null) return null;
                else editedShowing.ShowingMovie = movie;
            }

            if (showing.Date != null)
            {
                editedShowing.ShowingDate = showing.Date;
            }

            return new ShowingDto(await _showingsRepository.Edit(editedShowing));
        }

        public async Task<IList<ShowingDto>> GetAll()
        {
            var showings = await _showingsRepository.GetAll();
            return showings.Select(s => new ShowingDto(s)).ToList();
        }

        public async Task<ShowingDto> GetById(int showingId)
        {
            var showing = await _showingsRepository.GetById(showingId);
            return showing == null ? null : new ShowingDto(showing);
        }

        public async Task<IList<SeatDto>> GetTakenSeats(int showingId)
        {
            var reservations = await _showingsRepository.GetReservations(showingId);
            if (reservations == null) return null;
            var takenSeats = reservations.Select(r => new SeatDto { Number = r.ReservationSeat, IsTaken = r.IsCompleted });
            return takenSeats.ToList();
        }

        public async Task<IList<int>> GetUserReservations(int showingId, int userId)
        {
            var reservations = await _showingsRepository.GetReservations(showingId);
            if (reservations == null) return null;

            return reservations
                .Where(r => r.ReservationUserId == userId)
                .Select(r => r.ReservationId).ToList();
        }
    }
}
