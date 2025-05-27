using EventsApplication.Domain.DomainModels;

namespace EventsApplication.Service.Interface
{
    public interface ISpeakerService
    {
        List<Speaker> GetAll();
        Speaker? GetById(Guid id);
        Speaker Insert(Speaker speaker);
        Speaker Update(Speaker speaker);
        Speaker DeleteById(Guid id);
    }
}
