using EventsApplication.Domain.DomainModels;

namespace EventsApplication.Service.Interface
{
    public interface IRegisrationService
    {
        List<Registration> GetAll();
        List<Registration> GetAllByCurrentUser(string userId);
        Registration? GetById(Guid id);
        Registration DeleteById(Guid id);
        Registration RegisterAttendeeOnEvent(string userId, Guid attendeeId, Guid eventId, string paymentStatus);
        Schedule CreateSchedule(string userId);
    }
}
