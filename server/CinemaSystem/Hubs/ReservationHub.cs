using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Services.DTO;
using Microsoft.AspNetCore.SignalR;

namespace CinemaSystem.Hubs
{
    public class ReservationHub: Hub
    {
        public async Task SendReservationMade(int showingId, AddReservationDto reservation)
        {
            await Clients.All.SendAsync("ReservationMade", showingId, reservation);
        }

        public async Task SendReservationClosed(int showingId)
        {
            await Clients.Caller.SendAsync("ReservationClosed", showingId);
        }
    }
}
