using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Dtos
{
    public class EventDto
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        public int Priority { get; set; }

        [Required]
        [StringLength(255)]
        public string Details { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int EventCategoryId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int OrganiserId { get; set; }

        public EventCategoryDto AssociatedEventCategory { get; set; }

        public LocationDto AssociatedLocation { get; set; }

        public OrganiserDto AssociatedOrganiser { get; set; }
    }
}