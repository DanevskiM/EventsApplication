namespace EventsApplication.Domain.DomainModels
{
    public class Attendee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int TicketNumber { get; set; }
        public virtual ICollection<Registration>? Registrations { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
