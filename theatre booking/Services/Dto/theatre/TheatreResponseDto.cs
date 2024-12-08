using theatre_booking.DataAccess.models;

namespace theatre_booking.Services.Dto.theatre
{
    public class TheatreResponseDto
    {
        public int Id { get; set; }
        public string TheatreName { get; set; }
        public int Capacity { get; set; }
        public List<SeatResponseDto> Seats { get; set; }

       
    }

    public class SeatResponseDto
    {
        public int Id { get; set; }
        public string Seat_number { get; set; }
        public bool IsBooked { get; set; }
        public string Type { get; set; }
        public int? UserId { get; set; }
    }

   
}
