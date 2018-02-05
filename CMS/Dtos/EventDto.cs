using System;

namespace CMS.Dtos
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Details { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int EventCategoryId { get; set; }

        public int LocationId { get; set; }

        public int OrganiserId { get; set; }

        public EventCategoryDto AssociatedEventCategory { get; set; }

        public LocationDto AssociatedLocation { get; set; }

        public OrganiserDto AssociatedOrganiser { get; set; }

        public TagDto AssociatedTags { get; set; }
    }
}