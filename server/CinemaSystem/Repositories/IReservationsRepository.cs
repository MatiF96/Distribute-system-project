using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
