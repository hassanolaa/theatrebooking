using theatre_booking.DataAccess.models;
using theatre_booking.Services.Dto.theatre;

namespace theatre_booking.Services.Contracts
{
    public interface ITheatreDto
    {
        string InsertTheatre(InsertTheatreDto insertTheatreDto);
        TheatreResponseDto GetTheatre(int id);
    }
}
