using theatre_booking.DataAccess.models;
using theatre_booking.Services.Dto.seat;

namespace theatre_booking.Services.Contracts
{
    public interface ISeatDto
    {
        // get all seats
        List<Seat> GetAllSeats();

        // get seat by id
        Seat GetSeatById(int id);


        // get seats by theatre id
        List<Seat> GetSeatsByTheatreId(int id);

        // get seats by theatre id with user data
        List<Seat> GetSeatsByTheatreIdWithUserData(int id);

        // get seats by theatre id and seat number
        List<Seat> GetSeatsByTheatreIdAndSeatNumber(GetSeatsByTheatreIdAndSeatsNumber getSeatsByTheatreIdAndSeatsNumber);

        // update seat
        String UpdateSeat(SeatDto seatDto, int id);

        // Book seats
        String BookSeats(BookSeats bookSeats);

        // delete seat
        String DeleteSeat(int id);

    }
}
