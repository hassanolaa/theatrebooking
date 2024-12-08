using theatre_booking.DataAccess.models;
using theatre_booking.DataAccess.Repos;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.Dto.eventt;

namespace theatre_booking.Services.ServicesRepos
{
    public class EventDtoServices : IEventDto
    {

        readonly UnitOfWorkRepo _unitOfWork;
        public EventDtoServices(UnitOfWorkRepo unitOfWork) {
        
            _unitOfWork = unitOfWork;
        }


        public String CreateEvent(EventDto eventDto)
        {
           var threatre = _unitOfWork.TheatreRepo.FindById(eventDto.ThreatreId);
            if (threatre == null)
            {
                return "The threatre does not exist";
            }
            var newEvent = new Event
            {
                EventName = eventDto.EventName,
                Date = eventDto.Date,
                Image = eventDto.Image,
                Description = eventDto.Description,
                LatLocation = eventDto.LatLocation,
                LongLocation = eventDto.LongLocation,
                TheatreId = eventDto.ThreatreId,
                EventType = eventDto.EventType
            };
            _unitOfWork.EventRepo.Insert(newEvent);
            _unitOfWork.Save();
            return "Event created successfully";
        }

        public string DeleteEvent(int id)
        {
            var Eventobj= _unitOfWork.EventRepo.FindById(id);
            if (Eventobj == null)
            {
                return "Event does not exist";
            }
            _unitOfWork.EventRepo.Delete(id);
            _unitOfWork.Save();
            return "Event deleted successfully";
        }

        public List<Event> GetAllEvents()
        {
            var events = _unitOfWork.EventRepo.GetAll();
            return events.ToList();
        }

        public Event GetEventById(int id)
        {
            var eventt = _unitOfWork.EventRepo.FindById(id);
           
            var theatre = _unitOfWork.TheatreRepo.FindById(eventt.TheatreId);
          
            Theatre theatre1 = new Theatre()
            {
                TheatreName = theatre.TheatreName,
                Capacity = theatre.Capacity,
                Id = theatre.Id
            };
            
                var eventobj=new Event() {

                    Id = eventt.Id,
                    EventName=eventt.EventName,
                    Date = eventt.Date,
                    Description = eventt.Description,
                    LatLocation = eventt.LatLocation,
                    LongLocation = eventt.LongLocation,
                    TheatreId = eventt.TheatreId,
                    Theatre = theatre,
                    EventType=eventt.EventType,
                   
                };




            return eventobj;

            
         
        }

        public List<EventImageDTO> GetEventsImagesAndIDs()
        {
            Lazy<List<EventImageDTO>> imagesAndIds = new Lazy<List<EventImageDTO>>(() =>
            _unitOfWork.EventRepo.GetAll()
          .Select(e => new EventImageDTO { EventId = e.Id, Image = e.Image })
          .ToList()
          );

            // Return the value after lazy initialization
            return imagesAndIds.Value;
        }

        public string UpdateEvent(EventDto eventDto,int id)
        {
            var eventt = _unitOfWork.EventRepo.FindById(id);
            if (eventt == null)
            {
                return "Event does not exist";
            }
            var threatre = _unitOfWork.TheatreRepo.FindById(eventDto.ThreatreId);
            if (threatre == null)
            {
                return "The threatre does not exist";
            }
            eventt.EventName = eventDto.EventName;
            eventt.Date = eventDto.Date;
            eventt.Image = eventDto.Image;
            eventt.Description = eventDto.Description;
            eventt.LatLocation = eventDto.LatLocation;
            eventt.LongLocation = eventDto.LongLocation;
            eventt.TheatreId = eventDto.ThreatreId;
            _unitOfWork.EventRepo.Update(eventt);
            _unitOfWork.Save();
            return "Event updated successfully";

        }

        public string UpdateEventImage(UpdateImageDto updateImageDto, int id)
        {
            var eventt = _unitOfWork.EventRepo.FindById(id);
            if (eventt == null)
            {
                return "Event does not exist";
            }
            eventt.Image = updateImageDto.Image;
            _unitOfWork.EventRepo.Update(eventt);
            _unitOfWork.Save();
            return "Event image updated successfully";
        }
    }
}
