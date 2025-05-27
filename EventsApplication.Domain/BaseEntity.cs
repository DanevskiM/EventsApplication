using System.ComponentModel.DataAnnotations;

namespace EventsApplication.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
