using System;
using System.Collections.Generic;

namespace CinemaSystem.Database.Models
{
    public partial class Reservations
    {
        public int ReservationId { get; set; }
        public int ReservationShowingId { get; set; }
        public int ReservationUserId { get; set; }
        public int ReservationSeat { get; set; }
        public bool IsCompleted { get; set; }
        public virtual Showing ReservationShowing { get; set; }
        public virtual User ReservationUser { get; set; }
    }
}
