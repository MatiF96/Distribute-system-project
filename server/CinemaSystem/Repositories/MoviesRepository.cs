using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystem.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly CinemaDbContext _ctx;

        public MoviesRepository(CinemaDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Movie> Add(Movie movie)
        {
            var newMovie = await _ctx.Movies.AddAsync(movie);
            await _ctx.SaveChangesAsync();
            return newMovie.Entity;
        }

        public async Task<int?> Delete(int movieId)
        {
            var movie = await _ctx.Movies.FindAsync(movieId);
            if (movie == null) return null;
            _ctx.Movies.Remove(movie);
            await _ctx.SaveChangesAsync();
            return movieId;
        }

        public async Task<Movie> Edit(Movie movie)
        {
            if (movie == null) return null;
            _ctx.Movies.Update(movie);
            await _ctx.SaveChangesAsync();
            return movie;
        }

        public async Task<IList<Movie>> GetAll()
        {
            return await _ctx.Movies.ToListAsync();
        }

        public async Task<Movie> GetById(int movieId)
        {
            return await _ctx.Movies.FindAsync(movieId);
        }

        public async Task<IList<Showing>> GetShowings(int movieId)
        {
            var movie = await _ctx.Movies.Where(m => m.MovieId == movieId).Include(s => s.Showings).FirstOrDefaultAsync();
            return movie.Showings.ToList();
        }
    }
}
