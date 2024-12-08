using theatre_booking.DataAccess.contracts;
using theatre_booking.DataAccess.models;

namespace theatre_booking.DataAccess.Repos
{
    public class EventRepo : BaseRepo<Event>, IEventRepo
    {
        public EventRepo(AppDbContext context) : base(context)
        {
        }
    }
}
