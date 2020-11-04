using System;
using System.Collections.Generic;

namespace CinemaSystem.Database.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Showings = new HashSet<Showing>();
        }

        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int MovieDuration { get; set; }

        public virtual ICollection<Showing> Showings { get; set; }
    }
}
