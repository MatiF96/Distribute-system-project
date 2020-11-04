using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public interface IMoviesService
    {
        Task<IList<MovieDto>> GetAll();
        Task<MovieDto> GetById(int movieId);
        Task<IList<ShowingDto>> GetShowings(int movieId);
        Task<MovieDto> Add(AddMovieDto movie);
        Task<MovieDto> Edit(int movieId, EditMovieDto movie);
        Task<int?> Delete(int movieId);

    }
}
