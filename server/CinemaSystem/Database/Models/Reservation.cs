using System;
using System.Collections.Generic;

namespace CinemaSystem.Database.Models
{
    public partial class Reservations
    {
        public Reservations()
        {
            InverseReservationShowing = new HashSet<Reservations>();
        }

        public int ReservationId { get; set; }
        public int ReservationShowingId { get; set; }
        public int ReservationUserId { get; set; }
        public int ReservationSeat { get; set; }

        public virtual Reservations ReservationShowing { get; set; }
        public virtual User ReservationUser { get; set; }
        public virtual ICollection<Reservations> InverseReservationShowing { get; set; }
    }
}
