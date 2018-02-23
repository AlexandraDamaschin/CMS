using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class EventFormViewModel
    {
        public int? EventId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Event Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Details { get; set; }

        [Required]
        [Range(1, 10)]
        public int Priority { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [ForeignKey("AssociatedOrganiser")]
        [Display(Name = "Organiser")]
        public int OrganiserId { get; set; }

        [ForeignKey("AssociatedEventCategory")]
        [Display(Name = "Event Category")]
        public int EventCategoryId { get; set; }

        [ForeignKey("AssociatedLocation")]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        public IEnumerable<Organiser> Organisers { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<EventCategory> EventCategories { get; set; }


        public string Title
        {
            get
            {
                return EventId != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public EventFormViewModel()
        {
            EventId = 0;
        }

        public EventFormViewModel(Event evnt)
        {
            EventId = evnt.EventId;
            Name = evnt.Name;
            Details = evnt.Details;
            Priority = evnt.Priority;
            StartTime = evnt.StartTime;
            EndTime = evnt.EndTime;
            OrganiserId = evnt.OrganiserId;
            LocationId = evnt.LocationId;
            EventCategoryId = evnt.EventCategoryId;
        }
    }
}