using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystem.Services.DTO
{
    public class AddReservationDto
    {
        public SeatDto seat { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
