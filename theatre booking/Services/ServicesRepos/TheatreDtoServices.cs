using theatre_booking.DataAccess.models;
using theatre_booking.DataAccess.Repos;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.theatre;

namespace theatre_booking.Services.ServicesRepos
{
    public class TheatreDtoServices : ITheatreDto
    {
        readonly UnitOfWorkRepo unitOfWorkRepo;
        
        public TheatreDtoServices(UnitOfWorkRepo unitOfWork) {
            unitOfWorkRepo = unitOfWork;
        }

        public TheatreResponseDto GetTheatre(int id)
        {
            var theatre= unitOfWorkRepo.TheatreRepo.FindById(id);


            if (theatre==null)
            {
                return null;
            }


            List<Seat> seats = unitOfWorkRepo.SeatRepo.GetAll().Where(s=>s.TheatreId==id).ToList();
            
            List<SeatResponseDto> seatResponseDtos = new List<SeatResponseDto>();

            foreach (var seat in seats)
            {
                seatResponseDtos.Add(new SeatResponseDto
                {
                    Id = seat.Id,
                    Seat_number = seat.Seat_number,
                    IsBooked = seat.IsBooked,
                    Type = seat.Type,
                    UserId = seat.UserId
                });
            }

            

         
            
            TheatreResponseDto theatreResponseDto = new TheatreResponseDto() { 
            TheatreName = theatre.TheatreName,
            Id = theatre.Id,
            Capacity = theatre.Capacity,
            Seats=seatResponseDtos,
            };

            return theatreResponseDto;
        }

        public string InsertTheatre(InsertTheatreDto insertTheatreDto)
        {
            var theatre = new Theatre 
            { 
                TheatreName = insertTheatreDto.TheatreName,
                Capacity = insertTheatreDto.capacity,
                Seats = new List<Seat>()
            };

            // First save the theatre to get its ID
            unitOfWorkRepo.TheatreRepo.Insert(theatre);
            unitOfWorkRepo.Save();

             const int SEATS_PER_ROW = 20;
            int totalRows = (int)Math.Ceiling((double)insertTheatreDto.capacity / SEATS_PER_ROW);

            // Create seats row by row
            for (int row = 0; row < totalRows; row++)
            {
                string rowLetter = ((char)('A' + row)).ToString();
                string seatType = GetSeatType(row);

                // Create seats in this row
                for (int seatNum = 1; seatNum <= SEATS_PER_ROW; seatNum++)
                {
                    // Stop if we've reached the total capacity
                    if ((row * SEATS_PER_ROW + seatNum) > insertTheatreDto.capacity)
                        break;

                    var seat = new Seat
                    {
                        IsBooked = false,
                        Seat_number = $"{rowLetter}-{seatNum:D2}", // This will format numbers as 01, 02, etc.
                        Type = seatType,
                        TheatreId = theatre.Id,
                        theatre = theatre
                    };
                    theatre.Seats.Add(seat);
                }
            }

            // Save again to persist the seats
            unitOfWorkRepo.Save();

            return "Added Successfully";
        }

         private string GetSeatType(int rowIndex)
        {
            if (rowIndex < 2) // First two rows (A, B)
                return "VIP";
            else if (rowIndex < 4) // Next two rows (C, D)
                return "Premium";
            else // All remaining rows
                return "Normal";
        }
    }
}
