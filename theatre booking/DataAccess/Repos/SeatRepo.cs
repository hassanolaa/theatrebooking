using theatre_booking.DataAccess.contracts;
using theatre_booking.DataAccess.models;

namespace theatre_booking.DataAccess.Repos
{
    public class SeatRepo : BaseRepo<Seat> , ISeatRepo
    {
        public SeatRepo(AppDbContext db) : base(db)
        {
        }
    
    
    }
}
