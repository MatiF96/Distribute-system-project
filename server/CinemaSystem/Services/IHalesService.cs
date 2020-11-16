using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public interface IHalesService
    {
        Task<IList<HallDto>> GetHales();
        Task<HallDto> GetById(int hallId);
        Task<HallDto> AddHall(AddEditHallDto hall);
        Task<int?> DeleteHall(int hallId);
        Task<HallDto> EditHall(int hallId, AddEditHallDto hall);
    }
}
