using theatre_booking.DataAccess.contracts;
using theatre_booking.DataAccess.models;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.seat;

namespace theatre_booking.Services.ServicesRepos
{
    public class SeatDtoServices : ISeatDto
    {
        readonly IUnitofWork unitofWork;

        public SeatDtoServices(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
        public List<Seat> GetAllSeats()
        {
            var seats = unitofWork.SeatRepo.GetAll();
            return seats.ToList();
        }


        public Seat GetSeatById(int id)
        {
            var seat = unitofWork.SeatRepo.FindById(id);

            if (seat == null)
            {
                return null;
            }

            // Check if UserId is null before trying to find the user
            if (!seat.UserId.HasValue)
            {
                // If UserId is null, return a Seat object without assigning a user
                Seat seat1 = new Seat()
                {
                    Id = seat.Id,
                    IsBooked = seat.IsBooked,
                    UserId = seat.UserId,
                    user = null,  // No user assigned
                    TheatreId = seat.TheatreId,
                    theatre = null,  // No theatre assigned
                    Seat_number = seat.Seat_number,
                    Type = seat.Type
                };

                return seat1;
            }

            // If UserId has a value, retrieve the user
            var user = unitofWork.UserRepo.FindById(seat.UserId.Value);  // Use Value because UserId is not null here

            if (user == null)
            {
                // If user is not found, return the seat without a user
                Seat seat1 = new Seat()
                {
                    Id = seat.Id,
                    IsBooked = seat.IsBooked,
                    UserId = seat.UserId,
                    user = null,  // No user found
                    TheatreId = seat.TheatreId,
                    theatre = null,  // No theatre assigned
                    Seat_number = seat.Seat_number,
                    Type = seat.Type
                };

                return seat1;
            }

            // If user is found, map the user properties to a new User object
            User user1 = new User()
            {
                Fullname = user.Fullname,
                Email = user.Email,
                Age = user.Age,
                IsMan = user.IsMan,
                Role = user.Role
            };

            // Assign the user to the seat object
            seat.user = user1;
            return seat;
        }

        public List<Seat> GetSeatsByTheatreId(int id)
        {
            var theatre = unitofWork.TheatreRepo.FindById(id);
            if (theatre == null)
            {
                return null;
            }

            var seats = unitofWork.SeatRepo.GetAll().Where(s=>s.TheatreId==theatre.Id);


            return seats.ToList();
        }


        public List<Seat> GetSeatsByTheatreIdWithUserData(int id)
        {
            var theatre = unitofWork.TheatreRepo.FindById(id);
            if (theatre == null)
            {
                return null;
            }

            // Materialize the query by calling ToList() here
            var seats = unitofWork.SeatRepo.GetAll().Where(s => s.TheatreId == theatre.Id).ToList();

            foreach (var seat in seats)
            {
                if (seat.UserId.HasValue)
                {
                    // Fetch the user data outside of the loop to avoid multiple database calls in a single transaction
                    User user = unitofWork.UserRepo.FindById(seat.UserId.Value);

                    if (user != null)
                    {
                        User user1 = new User()
                        {
                            Id = user.Id,
                            Fullname = user.Fullname,
                            Email = user.Email,
                            Age = user.Age,
                            IsMan = user.IsMan,
                            Role = user.Role
                        };

                        seat.user = user1;
                    }
                }
            }

            return seats;
        }

        public List<Seat> GetSeatsByTheatreIdAndSeatNumber(GetSeatsByTheatreIdAndSeatsNumber getSeatsByTheatreIdAndSeatsNumber)
        {
            var theatre = unitofWork.TheatreRepo.FindById(getSeatsByTheatreIdAndSeatsNumber.TheatreId);
            if (theatre == null)
            {
                return null;
            }

            List<Seat> seats = new List<Seat>();

            foreach (var seatNumber in getSeatsByTheatreIdAndSeatsNumber.SeatNumbers)
            {
                var seat = unitofWork.SeatRepo.GetAll().Where(s => s.TheatreId == theatre.Id && s.Seat_number == seatNumber).FirstOrDefault();
                if (seat != null)
                {
                    if (seat.UserId.HasValue)
                    {
                        User user = unitofWork.UserRepo.FindById(seat.UserId.Value);

                            User user1 = new User()
                            {
                                Fullname = user.Fullname,
                                Email = user.Email,
                                Age = user.Age,
                                IsMan = user.IsMan,
                                Role = user.Role
                            };

                            seat.user = user1;


                        
                        seats.Add(seat);
                    }


                    else
                    {
                        seats.Add(seat);

                    }

                }
            }
            return seats;

        }
        
        public string UpdateSeat(SeatDto seatDto, int id)
                {
                    var seat = unitofWork.SeatRepo.FindById(id);

                    if (seat == null)
                    {
                        return "Seat not found";
                    }

                    var user = unitofWork.UserRepo.FindById(seatDto.UserId);
                    if (user == null)
                    {
                        return "User not found";
                    }

                    User user1 = new User() {
                        Fullname = user.Fullname,
                        Email = user.Email,
                        Age = user.Age,
                        IsMan = user.IsMan,
                        Role = user.Role

                    };

                    seat.UserId = seatDto.UserId;
                    seat.IsBooked = true;
                    seat.user = user1;
                    unitofWork.SeatRepo.Update(seat);
                    unitofWork.Save();
                    return "Seat updated successfully";
                }

        public string BookSeats(BookSeats bookSeats)
        {
            var theatre = unitofWork.TheatreRepo.FindById(bookSeats.TheatreId);
            if (theatre == null)
            {
                return "Theatre not found";
            }

            foreach (var seatNumber in bookSeats.SeatsNumber)
            {
                var seat = unitofWork.SeatRepo.GetAll().Where(s => s.TheatreId == theatre.Id && s.Seat_number == seatNumber).FirstOrDefault();
                if (seat != null)
                {
                    if (seat.IsBooked)
                    {
                        return "Seat already booked";
                    }

                    var user = unitofWork.UserRepo.FindById(bookSeats.UserId);
                    if (user == null)
                    {
                        return "User not found";
                    }

                    User user1 = new User()
                    {
                        Fullname = user.Fullname,
                        Email = user.Email,
                        Age = user.Age,
                        IsMan = user.IsMan,
                        Role = user.Role
                    };

                    seat.UserId = bookSeats.UserId;
                    seat.IsBooked = true;
                    seat.user = user1;
                    unitofWork.SeatRepo.Update(seat);
                }
            }

            unitofWork.Save();
            return "Seats booked successfully";
            
        }

        public string DeleteSeat(int id)
        {
            var seat = unitofWork.SeatRepo.FindById(id);
            if (seat == null)
            {
                return "Seat not found";
            }
            unitofWork.SeatRepo.Delete(id);
            unitofWork.Save();
            return "Seat deleted successfully";
        }
    }
 }


