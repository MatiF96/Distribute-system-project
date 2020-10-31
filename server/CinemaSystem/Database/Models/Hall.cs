using System;
using System.Collections.Generic;

namespace CinemaSystem.Database.Models
{
    public partial class Hall
    {
        public Hall()
        {
            Showings = new HashSet<Showing>();
        }

        public int HallId { get; set; }
        public string HallName { get; set; }

        public virtual ICollection<Showing> Showings { get; set; }
    }
}
