using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.seat;
using theatre_booking.Services.ServicesRepos;

namespace theatre_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        readonly ISeatDto _seatDtoService;

        public SeatController(ISeatDto seatDtoService)
        {
            this._seatDtoService = seatDtoService;
        }


        [HttpPost("Book")]
        public IActionResult BookSeats(BookSeats bookSeats)
        {
            try
            {
                var message = _seatDtoService.BookSeats(bookSeats);
                if (message == "Seat already booked")
                {
                    return BadRequest("Seat already booked");
                }
                if (message == "User not found")
                {
                    return BadRequest("User not found");
                }


                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("Search")]
        public IActionResult GetSeatsByTheatreIdAndSeatNumber([FromBody] GetSeatsByTheatreIdAndSeatsNumber request)
        {
            try
            {
                var seats = _seatDtoService.GetSeatsByTheatreIdAndSeatNumber(request);
                if (seats == null)
                {
                    return NotFound("No seats found");
                }
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("Seats")]
        public async Task<IActionResult> GetSeats()
        {
            try
            {
                var seats = _seatDtoService.GetAllSeats();
                if (seats == null)
                {
                    return NotFound("No events found");
                }
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

       
       
        [HttpGet("Theatre/{id}")]
        public IActionResult GetSeatsByTheatreId(int id)
        {
            try
            {
                var seats = _seatDtoService.GetSeatsByTheatreId(id);
                if (seats == null)
                {
                    return NotFound("No seats found");
                }
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("TheatreWithUserData/{id}")]
        public IActionResult GetSeatsByTheatreIdWithUserData(int id)
        {
            try
            {
                var seats = _seatDtoService.GetSeatsByTheatreIdWithUserData(id);
                if (seats == null)
                {
                    return NotFound("No seats found");
                }
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSeat(int id)
        {
            try
            {
                var seat = _seatDtoService.GetSeatById(id);
                if (seat == null)
                {
                    return NotFound("No seat found");
                }
                return Ok(seat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSeat(SeatDto seatDto, int id)
        {
            try
            {
                var message = _seatDtoService.UpdateSeat(seatDto, id);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeat(int id)
        {
            try
            {
                var message = _seatDtoService.DeleteSeat(id);

                if (message== "Seat not found")
                {
                    return BadRequest("Seat not found");
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

       
    }
}