using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;
using CinemaSystem.Services.DTO;
using Microsoft.AspNetCore.SignalR;

namespace CinemaSystem.Hubs
{
    
    public class ReservationHub: Hub
    {
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}
