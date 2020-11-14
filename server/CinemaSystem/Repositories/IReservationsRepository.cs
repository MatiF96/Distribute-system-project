using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;

namespace CinemaSystem.Repositories
{
    public interface IReservationsRepository
    {
        Task<IList<Reservations>> GetAll();
        Task<Reservations> GetById(int reservationId);
        Task<Reservations> Add(Reservations reservation);
        Task<Reservations> Edit(Reservations reservation);
        Task<int?> Delete(int reservationId);
        Task Delete(IList<int> ids);
        Task Edit(IList<Reservations> reservation);
        Task<IList<Reservations>> GetByIds(IList<int> ids);

    }
}
