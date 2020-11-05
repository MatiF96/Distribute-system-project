using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public interface IShowingsService
    {
        Task<IList<ShowingDto>> GetAll();
        Task<ShowingDto> GetById(int showingId);
        Task<ShowingDto> AddShowing(AddShowingDto showing);
        Task<int?> DeleteShowing(int showingId);
        Task<ShowingDto> EditShowing(int showingId, AddShowingDto showing);
        Task<IList<SeatDto>> GetTakenSeats(int showingId);
    }
}
