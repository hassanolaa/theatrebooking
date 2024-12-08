using System.ComponentModel.DataAnnotations.Schema;

namespace theatre_booking.DataAccess.models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double LatLocation { get; set; }
        public double LongLocation { get; set; }
        
        [ForeignKey("TheatreId")]

        public int TheatreId { get; set; }

        public  Theatre? Theatre { get; set; }
    }
}
