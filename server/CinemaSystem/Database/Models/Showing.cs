using System;
using System.Collections.Generic;

namespace CinemaSystem.Database.Models
{
    public partial class Showing
    {
        public int ShowingId { get; set; }
        public int ShowingMovieId { get; set; }
        public int ShowingHallId { get; set; }
        public DateTime ShowingDate { get; set; }

        public virtual Hall ShowingHall { get; set; }
        public virtual Movie ShowingMovie { get; set; }
    }
}
