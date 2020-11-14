using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public interface IReservationsService
    {
        Task SetCompleted(IList<int> ids);
        Task Add(AddReservationDto reservation);
        Task DeleteReservations(IList<int> ids);
    }
}
