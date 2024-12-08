

using theatre_booking.DataAccess.models;

namespace theatre_booking.Services.Dto.eventt

{
    public class EventDto
{
        public string EventName { get; set; }

        public string EventType { get; set; }


        public DateTime Date { get; set; }


        public string Description { get; set; }

        public string Image { get; set; }


        // location as lat and long
        public double LatLocation { get; set; }
        public double LongLocation { get; set; }



        public int ThreatreId { get; set; }


    }
}
