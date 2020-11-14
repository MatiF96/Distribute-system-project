using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystem.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly CinemaDbContext _ctx;

        public ReservationsRepository(CinemaDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Reservations> Add(Reservations reservation)
        {
            var newReservation = await _ctx.Reservations.AddAsync(reservation);
            await _ctx.SaveChangesAsync();
            return newReservation.Entity;
        }

        public async Task<int?> Delete(int reservationId)
        {
            var reservation = await _ctx.Reservations.FindAsync(reservationId);
            if (reservation == null) return null;
            _ctx.Reservations.Remove(reservation);
            return reservationId;
        }

        public async Task Delete(IList<int> ids)
        {
            var reservations = await GetByIds(ids);
            _ctx.Reservations.RemoveRange(reservations);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Reservations> Edit(Reservations reservation)
        {
            if (reservation == null) return null;
            _ctx.Reservations.Update(reservation);
            await _ctx.SaveChangesAsync();
            return reservation;
        }

        public async Task Edit(IList<Reservations> reservations)
        {
            _ctx.Reservations.UpdateRange(reservations);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IList<Reservations>> GetAll() => await _ctx.Reservations.ToListAsync();

        public Task<Reservations> GetById(int reservationId) => _ctx.Reservations
                .Include(r => r.ReservationShowing)
                .SingleOrDefaultAsync(r => r.ReservationId == reservationId);

        public async Task<IList<Reservations>> GetByIds(IList<int> ids) => await _ctx.Reservations
            .Where(r => ids.Contains(r.ReservationId))
            .ToListAsync();
    }
}
