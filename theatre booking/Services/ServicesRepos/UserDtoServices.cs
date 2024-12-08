using theatre_booking.DataAccess.contracts;
using theatre_booking.DataAccess.models;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.User;

namespace theatre_booking.Services.ServicesRepos
{
    public class UserDtoServices : IUserDto
    {
        readonly IUnitofWork unitofWork;

        public UserDtoServices(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        
        // insert user

        public string InsertUser(InsertUserDto userDto)
        {
            var user = new User()
            {
                Fullname = userDto.Fullname,
                Email = userDto.Email,
                Age = userDto.Age,
                IsMan = userDto.IsMan,
                Role = "Normal"
            };

            unitofWork.UserRepo.Insert(user);
            unitofWork.Save();
            return "User inserted successfully";
        }
        
        public List<User> GetAllUsers()
        {
           var users= unitofWork.UserRepo.GetAll();
            return users.ToList();
        }

        public User GetUserById(int id)
        {
           var user= unitofWork.UserRepo.FindById(id);

            if (user==null)
            {
                return null;
            }
            List<Seat> seats = unitofWork.SeatRepo.GetAll().Where(s => s.UserId == user.Id).ToList();
            user.Seats = seats;

            return user;
        }



        public string UpdateUser(UserDto userDto, int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            var user = unitofWork.UserRepo.GetAll().Where(u => u.Fullname == username).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            List<Seat> seats = unitofWork.SeatRepo.GetAll().Where(s => s.UserId == user.Id).ToList();
            user.Seats = seats;


            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = unitofWork.UserRepo.GetAll().Where(u => u.Email == email).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            List<Seat> seats = unitofWork.SeatRepo.GetAll().Where(s => s.UserId == user.Id).ToList();
            user.Seats = seats;

            return user;
        }

        public string DeleteUser(int id)
        {
            var user = unitofWork.UserRepo.FindById(id);
            if (user == null)
            {
                return "User not found";
            }
            unitofWork.UserRepo.Delete(id);
            unitofWork.Save();
            return "User deleted successfully";
        }
    }
}
