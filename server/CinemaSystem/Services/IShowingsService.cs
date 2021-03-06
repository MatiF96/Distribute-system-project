﻿using System.Collections.Generic;
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
        Task<ShowingDto> EditShowing(int showingId, EditShowingDto showing);
        Task<IList<SeatDto>> GetTakenSeats(int showingId);
        Task<IList<int>> GetUserReservations(int showingId, int userId);
    }
}
