namespace EventsApplication.Domain.DomainModels
{
    public class EventInSchedule : BaseEntity
    {
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int Quantity { get; set; }
    }
}
