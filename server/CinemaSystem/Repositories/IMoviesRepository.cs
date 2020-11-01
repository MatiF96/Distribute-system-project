using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;

namespace CinemaSystem.Repositories
{
    public interface IMoviesRepository
    {
        Task<IList<Movie>> GetAll();
        Task<Movie> GetById(int movieId);
        Task<Movie> Add(Movie movie);
        Task<Movie> Edit(Movie movie);
        Task Delete(int movieId);
    }
}
