using CoursesApplication.Repository.Interface;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;

namespace EventsApplication.Service.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IRepository<Attendee> _attendeeRepository;

        public AttendeeService(IRepository<Attendee> attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public List<Attendee> GetAll()
        {
            return _attendeeRepository.GetAll(selector: x => x).ToList();
        }

        public Attendee? GetById(Guid id)
        {
            return _attendeeRepository.Get(selector: x => x, predicate: x => x.Id.Equals(id));
        }

        public Attendee Insert(Attendee attendee)
        {
            attendee.Id = Guid.NewGuid();
            return _attendeeRepository.Insert(attendee);
        }

        public Attendee Update(Attendee attendee)
        {
            return _attendeeRepository.Update(attendee);
        }

        public Attendee DeleteById(Guid id)
        {
            var attendee = GetById(id);
            if (attendee == null)
            {
                throw new Exception("Attendee not found");
            }
            return _attendeeRepository.Delete(attendee);
        }
    }
}
