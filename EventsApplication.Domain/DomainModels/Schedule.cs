using EventsApplication.Domain.IdentityModels;

namespace EventsApplication.Domain.DomainModels
{
    public class Schedule : BaseEntity
    {
        public string UserId { get; set; }
        public virtual EventsApplicationUser User { get; set; }
        public virtual ICollection<EventInSchedule> EventInSchedules { get; set; } = new List<EventInSchedule>();
    }
}
