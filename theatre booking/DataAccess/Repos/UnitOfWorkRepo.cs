using theatre_booking.DataAccess.contracts;

namespace theatre_booking.DataAccess.Repos
{
    public class UnitOfWorkRepo : IUnitofWork
    {

        private readonly AppDbContext _db;
        private IUserRepo _userRepo;
        private IEventRepo _eventRepo;
        private ISeatRepo _seatRepo;
        private IThreatreRepo _theatreRepo;

        public UnitOfWorkRepo(AppDbContext db)
        {
            _db = db;
            _userRepo = new UserRepo(_db);
            _eventRepo = new EventRepo(_db);
            _seatRepo = new SeatRepo(_db);
            _theatreRepo = new ThreatreRepo(_db);

        }
        public IUserRepo UserRepo => _userRepo;

        public IEventRepo EventRepo => _eventRepo;

        public ISeatRepo SeatRepo => _seatRepo;


        public IThreatreRepo TheatreRepo => _theatreRepo;

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
