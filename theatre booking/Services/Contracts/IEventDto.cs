using theatre_booking.DataAccess.models;
using theatre_booking.Services.Dto.eventt;

namespace theatre_booking.Services.Contracts
{
    public interface IEventDto
    {
        // get all events
        List<Event> GetAllEvents();

        // get event by id
        Event GetEventById(int id);

        // create event
        String CreateEvent(EventDto eventDto);

        // delete event
        String DeleteEvent(int id);

        // update event
        String UpdateEvent(EventDto eventDto, int id);

        // update event Image
        String UpdateEventImage(UpdateImageDto updateImageDto, int id);

        // get events Images and Ids
        List<EventImageDTO> GetEventsImagesAndIDs();



    }
}
