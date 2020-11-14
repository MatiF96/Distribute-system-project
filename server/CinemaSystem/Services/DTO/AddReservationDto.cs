using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystem.Services.DTO
{
    public class AddReservationDto
    {
        public int ShowingId { get; set; }
        public int UserId { get; set; }
        public int Seat { get; set; }
    }
}
