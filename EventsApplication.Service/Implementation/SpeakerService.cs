using CoursesApplication.Repository.Interface;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventsApplication.Service.Implementation
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository<Speaker> _speakerRepository;

        public SpeakerService(IRepository<Speaker> speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public List<Speaker> GetAll()
        {
            return _speakerRepository
                .GetAll(
                    selector: x => x,
                    include: x => x.Include(z => z.Event)
                ).ToList();
        }

        public Speaker? GetById(Guid id)
        {
            return _speakerRepository
                .Get(
                    selector: x => x,
                    predicate: x => x.Id.Equals(id),
                    include: x => x.Include(z => z.Event)
                );
        }

        public Speaker Insert(Speaker speaker)
        {
            speaker.Id = Guid.NewGuid();
            return _speakerRepository.Insert(speaker);
        }

        public Speaker Update(Speaker speaker)
        {
            return _speakerRepository.Update(speaker);
        }

        public Speaker DeleteById(Guid id)
        {
            var speaker = GetById(id);
            if (speaker == null)
            {
                throw new Exception("Speaker not found");
            }
            return _speakerRepository.Delete(speaker);
        }
    }
}
