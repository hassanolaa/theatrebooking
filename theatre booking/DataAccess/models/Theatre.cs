using System.ComponentModel.DataAnnotations.Schema;

namespace theatre_booking.DataAccess.models
{
    public class Theatre
    {
        public int Id { get; set; }
        
        public string TheatreName { get; set; }
        public int Capacity { get; set; }

        public List<Seat> Seats { get; set; }

        // Foreign key to Event (one-to-one relationship)
        public int? EventId { get; set; }

        // Navigation property to Event
        public Event? Event { get; set; }
    }
}
