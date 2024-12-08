namespace theatre_booking.Services.Dto.seat
{
    public class BookSeats
    {
        public int TheatreId { get; set; }

        public int UserId { get; set; }

        public List<String> SeatsNumber { get; set; }
    }
}
