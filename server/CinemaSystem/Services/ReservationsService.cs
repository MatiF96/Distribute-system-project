using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;
using CinemaSystem.Repositories;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly IReservationsRepository _reservationsRepository;

        public ReservationsService(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }

        public async Task Add(AddReservationDto reservation)
        {
            var newReservation = new Reservations {
                ReservationSeat = reservation.Seat,
                ReservationShowingId = reservation.ShowingId,
                ReservationUserId = reservation.UserId
            };
            await _reservationsRepository.Add(newReservation);
        }

        public Task DeleteReservations(IList<int> ids)
        {
            return _reservationsRepository.Delete(ids);
        }

        public async Task SetCompleted(IList<int> ids)
        {
            var reservations = (List<Reservations>)await _reservationsRepository.GetByIds(ids);
            reservations.ForEach(r =>
           {
               r.IsCompleted = true;

           });
            await _reservationsRepository.Edit(reservations);
        }
    }
}
