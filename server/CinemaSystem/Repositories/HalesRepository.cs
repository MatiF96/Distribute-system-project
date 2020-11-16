using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystem.Repositories
{
    public class HalesRepository : IHalesRepository
    {
        private readonly CinemaDbContext _ctx;

        public HalesRepository(CinemaDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Hall> Add(Hall hall)
        {
            var newHall = await _ctx.Hales.AddAsync(hall);
            await _ctx.SaveChangesAsync();
            return newHall.Entity;
        }

        public async Task<int?> Delete(int hallId)
        {
            var hall = await _ctx.Hales.FindAsync(hallId);
            if (hall == null) return null;
            _ctx.Hales.Remove(hall);
            await _ctx.SaveChangesAsync();
            return hallId;
        }

        public async Task<Hall> Edit(Hall hall)
        {
            if (hall == null) return null;
            _ctx.Hales.Update(hall);
            await _ctx.SaveChangesAsync();
            return hall;
        }

        public async Task<IList<Hall>> GetAll()
        {
            return await _ctx.Hales.ToListAsync();
        }

        public async Task<Hall> GetById(int hallId)
        {
            return await _ctx.Hales.FindAsync(hallId);
        }

        public async Task<IList<Showing>> GetShowings(int hallId)
        {
            var hall = await _ctx.Hales.Include(h => h.Showings).SingleOrDefaultAsync();
            return hall.Showings.ToList();
        }
    }
}
