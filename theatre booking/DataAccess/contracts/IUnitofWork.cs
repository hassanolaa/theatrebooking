namespace theatre_booking.DataAccess.contracts
{
    public interface IUnitofWork
    { 
        IUserRepo UserRepo { get; }
        IEventRepo EventRepo { get; }
        ISeatRepo SeatRepo { get; }
        IThreatreRepo TheatreRepo { get; }
        void Save();
    }
}
