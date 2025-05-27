using EventsApplication.Domain.DomainModels;

namespace EventsApplication.Service.Interface
{
    public interface IScheduleService
    {
        Schedule? GetScheduleDetails(Guid id);
    }
}
