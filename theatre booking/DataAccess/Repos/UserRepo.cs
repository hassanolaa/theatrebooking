using theatre_booking.DataAccess.contracts;
using theatre_booking.DataAccess.models;

namespace theatre_booking.DataAccess.Repos
{
    public class UserRepo : BaseRepo<User> , IUserRepo
    {
        public UserRepo(AppDbContext db) : base(db)
        {
        }
     
    }
}
