using EventsApplication.Domain.DomainModels;

namespace EventsApplication.Service.Interface
{
    public interface IEventService
    {
        List<Event> GetAll();
        Event? GetById(Guid id);
        Event Insert(Event _event);
        Event Update(Event _event);
        Event DeleteById(Guid id);
    }
}
