using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.eventt;

namespace theatre_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IEventDto _eventDtoService;

        public EventController(IEventDto eventDtoService)
        {
            this._eventDtoService = eventDtoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent( EventDto eventDto)
        {
            if (eventDto == null)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                try
                {
                    var response= _eventDtoService.CreateEvent(eventDto);
                    
                    if (response == "The threatre does not exist")
                    {
                        return NotFound("The threatre does not exist");
                    }
                   
                    return Ok("Event created successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var events = _eventDtoService.GetAllEvents();
                if (events == null)
                {
                    return NotFound("No events found");
                }
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            try
            {
                var eventt = _eventDtoService.GetEventById(id);
                if (eventt == null)
                {
                    return NotFound($"Event with ID {id} not found");
                }
                return Ok(eventt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    
        [HttpGet("GetEventsImagesAndIds")]
        public async Task<IActionResult> GetEventsImagesAndIds()
        {
            try
            {
                var images = _eventDtoService.GetEventsImagesAndIDs();
                if (images == null)
                {
                    return NotFound("No images found");
                }
                return Ok(images);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateEventImage/{id}")]
        public async Task<IActionResult> UpdateEventImage(UpdateImageDto updateImageDto, int id)
        {
            try
            {
                var response = _eventDtoService.UpdateEventImage(updateImageDto, id);
                if (response == "Event does not exist")
                {
                    return NotFound($"Event with ID {id} not found");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(EventDto eventDto, int id)
        {
            if (eventDto == null)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                try
                {
                    var response = _eventDtoService.UpdateEvent(eventDto, id);
                    if (response == "Event does not exist")
                    {
                        return NotFound($"Event with ID {id} not found");
                    }
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var response = _eventDtoService.DeleteEvent(id);
                if (response == "Event does not exist")
                {
                    return NotFound($"Event with ID {id} not found");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
