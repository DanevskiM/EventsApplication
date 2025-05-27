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
        public Schedule? GetScheduleDetails(Guid id)
        {
            // TODO: implement method

            throw new NotImplementedException();
        }
    }
}
