using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace theatre_booking.DataAccess.models
{
    public class Seat
    {
        public int Id { get; set; }
        public string Seat_number { get; set; }
        public bool IsBooked { get; set; }

        // owner - optional since seats start without an owner
        public int? UserId { get; set; }
        public User? user { get; set; }

        public string Type { get; set; }

        public int TheatreId { get; set; }
        
        [JsonIgnore]
        public Theatre theatre { get; set; }
    }
}
