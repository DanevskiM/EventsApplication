using CoursesApplication.Repository.Interface;
using EventsApplication.Domain.DomainModels;
using EventsApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventsApplication.Service.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _scheduleRepository;

        public ScheduleService(IRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public Schedule GetScheduleDetails(Guid id)
        {
            var schedule = _scheduleRepository.Get(
            selector: x => x,
            predicate: x => x.Id == id,
            include: x => x
            .Include(s => s.EventInSchedules)
            .ThenInclude(eis => eis.Event)
            );
            if (schedule == null)
            {
                throw new Exception("Schedule not found");
            }
            return schedule;
        }
    }
}
