using System.ComponentModel.DataAnnotations;

namespace EventsApplication.Domain.DomainModels
{
    public class Event : BaseEntity
    {
        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public int Price { get; set; }
        public required string Location { get; set; }
        public virtual ICollection<Speaker>? Speakers { get; set; }
    }
}
