
using theatre_booking.DataAccess.models;

namespace theatre_booking.Services.Dto.User
{
    public class UserDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsMan { get; set; }

        public string Role { get; set; }

        public List<Seat> seats { get; set; }


    }
}
