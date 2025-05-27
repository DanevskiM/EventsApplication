using EventsApplication.Domain.DomainModels;

namespace EventsApplication.Service.Interface
{
    public interface IAttendeeService
    {
        List<Attendee> GetAll();
        Attendee? GetById(Guid id);
        Attendee Insert(Attendee attendee);
        Attendee Update(Attendee attendee);
        Attendee DeleteById(Guid id);
    }
}
