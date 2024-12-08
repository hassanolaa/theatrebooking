using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.User;

namespace theatre_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserDto _userDtoService;

        public UserController(IUserDto userDtoService)
        {
            this._userDtoService = userDtoService;
        }


        [HttpPost]
        public IActionResult InsertUser(InsertUserDto userDto)
        {
            try
            {
                var result = _userDtoService.InsertUser(userDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = _userDtoService.GetAllUsers();
                if (users == null)
                {
                    return NotFound("No users found");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        
       [HttpGet("username/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                var user = _userDtoService.GetUserByUsername(username);
                if (user == null)
                {
                    return NotFound("No user found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                var user = _userDtoService.GetUserByEmail(email);
                if (user == null)
                {
                    return NotFound("No user found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _userDtoService.GetUserById(id);
                if (user == null)
                {
                    return NotFound("No user found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) {
            try
            {
                var result = _userDtoService.DeleteUser(id);

                if (result== "User not found")
                {
                    return BadRequest("User not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
