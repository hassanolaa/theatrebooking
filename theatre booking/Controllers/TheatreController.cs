using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.theatre;
using theatre_booking.Services.ServicesRepos;

namespace theatre_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        readonly ITheatreDto _theatreService;
        public TheatreController(ITheatreDto theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertTheatre(InsertTheatreDto insertTheatreDto)
        {
            if (insertTheatreDto==null)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                try
                {
                    _theatreService.InsertTheatre(insertTheatreDto);
                    return Ok("Theatre created successfully.");
                }
                catch (Exception ex)
                {

                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        // get theatre by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTheatre(int id)
        {
            try 
            {
                var theatre = _theatreService.GetTheatre(id);
                if (theatre == null)
                {
                    return NotFound($"Theatre with ID {id} not found");
                }
                return Ok(theatre);
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
