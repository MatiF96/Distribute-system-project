using System.Collections.Generic;
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
        Task<int?> Delete(int movieId);
        Task<IList<Showing>> GetShowings(int movieId);
    }
}
