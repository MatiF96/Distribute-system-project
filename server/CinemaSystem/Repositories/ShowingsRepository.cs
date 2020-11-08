using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystem.Repositories
{
    public class ShowingsRepository : IShowingsRepository
    {
        private readonly CinemaDbContext _ctx;

        public ShowingsRepository(CinemaDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Showing> Add(Showing showing)
        {
            var newShowing = await _ctx.Showings.AddAsync(showing);
            await _ctx.SaveChangesAsync();
            return newShowing.Entity;
        }

        public async Task<int?> Delete(int showingId)
        {
            var showing = await _ctx.Showings.FindAsync(showingId);
            if (showing == null) return null;
            _ctx.Showings.Remove(showing);
            await _ctx.SaveChangesAsync();
            return showingId;
        }

        public async Task<Showing> Edit(Showing showing)
        {
            if (showing == null) return null;
            _ctx.Showings.Update(showing);
            await _ctx.SaveChangesAsync();
            return showing;
        }

        public async Task<IList<Showing>> GetAll()
        {
            return await _ctx.Showings.Include(s => s.ShowingMovie).Include(s => s.ShowingHall).ToListAsync();
        }

        public async Task<Showing> GetById(int showingId)
        {
            var showing = await _ctx.Showings.Include(s => s.ShowingHall)
                .Include(s => s.ShowingMovie)
                .SingleOrDefaultAsync(s => s.ShowingId == showingId);
            return showing;
        }

        public async Task<IList<Reservations>> GetReservations(int showingId)
        {
            var showing = await _ctx.Showings
                .Include(s => s.ShowingReservations)
                .SingleOrDefaultAsync(s => s.ShowingId == showingId);
            return showing.ShowingReservations.ToList();
        }
    }
}
