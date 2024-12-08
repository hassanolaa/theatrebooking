using System.ComponentModel.DataAnnotations.Schema;

namespace theatre_booking.DataAccess.models
{
    public class User
    {
        // bacis user model

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public bool IsMan { get; set; }

        // user seats

        [ForeignKey("Seat")]
        public List<Seat> Seats { get; set; }

    }
}
