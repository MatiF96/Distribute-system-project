namespace CinemaSystem.Services.DTO
{
    public class ReservationDto
    {
        public int Id { get; set; }

        public int Seat { get; set; }
        public int UserId { get; set; }
        public int IsCompleted { get; set; }

        public ShowingDto Showing { get; set; }
    }
}
