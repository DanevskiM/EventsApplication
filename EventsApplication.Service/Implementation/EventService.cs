using CoursesApplication.Repository.Interface;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;

namespace EventsApplication.Service.Implementation
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public List<Event> GetAll()
        {
            return _eventRepository.GetAll(selector: x => x).ToList();
        }

        public Event? GetById(Guid id)
        {
            return _eventRepository.Get(selector: x => x, predicate: x => x.Id.Equals(id));
        }

        public Event Insert(Event _event)
        {
            _event.Id = Guid.NewGuid();
            return _eventRepository.Insert(_event);
        }

        public Event Update(Event _event)
        {
            return _eventRepository.Update(_event);
        }

        public Event DeleteById(Guid id)
        {
            var _event = GetById(id);
            if (_event == null)
            {
                throw new Exception("Event not found");
            }
            return _eventRepository.Delete(_event);
        }
    }
}
