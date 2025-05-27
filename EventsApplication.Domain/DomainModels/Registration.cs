using EventsApplication.Domain.IdentityModels;

namespace EventsApplication.Domain.DomainModels
{
    public class Registration : BaseEntity
    {
        public DateTime RegistrationDate { get; set; }
        public string PaymentStatus { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
        public string? OwnerId { get; set; }
        public EventsApplicationUser? Owner { get; set; }
    }
}
