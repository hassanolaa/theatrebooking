using theatre_booking.DataAccess.models;
using theatre_booking.Services.Dto.User;

namespace theatre_booking.Services.Contracts
{
    public interface IUserDto
    {
        // get all users
        List<User> GetAllUsers();

        // get user by id
        User GetUserById(int id);

        // get user by username
        User GetUserByUsername(string username);

        // get user by email
        User GetUserByEmail(string email);

        // update user
        String UpdateUser(UserDto userDto, int id);

        // insert user
        String InsertUser(InsertUserDto userDto);

        // delete user
        String DeleteUser(int id);
    }
}
