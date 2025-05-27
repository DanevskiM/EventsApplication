namespace EventsApplication.Domain.DomainModels
{
    public class Speaker : BaseEntity
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public Event? Event { get; set; }
        public Guid EventId { get; set; }
    }
}
