namespace theatre_booking.Services.Dto.seat
{
    public class GetSeatsByTheatreIdAndSeatsNumber
    {

        public int TheatreId { get; set; }

        public List<String> SeatNumbers { get; set; }
    }
}
