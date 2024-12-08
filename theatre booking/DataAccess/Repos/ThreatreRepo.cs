using theatre_booking.DataAccess.contracts;
using theatre_booking.DataAccess.models;

namespace theatre_booking.DataAccess.Repos
{
    public class ThreatreRepo : BaseRepo<Theatre> , IThreatreRepo
    {
        public ThreatreRepo(AppDbContext db):base(db) 
        { }
    }
}
