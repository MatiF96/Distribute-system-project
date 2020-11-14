using System.Collections.Generic;

namespace CinemaSystem.Database.Models
{
    public partial class User
    {
        public User()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
