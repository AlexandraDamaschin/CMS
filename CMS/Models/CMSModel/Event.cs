using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.CMSModel
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Event Name")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Details { get; set; }

        public int Priority { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [ForeignKey("AssociatedOrganiser")]
        public int OrganiserId { get; set; }

        [ForeignKey("AssociatedEventCategory")]
        public int EventCategoryId { get; set; }

        [ForeignKey("AssociatedLocation")]
        public int LocationId { get; set; }

        public virtual Organiser AssociatedOrganiser { get; set; }

        public virtual EventCategory AssociatedEventCategory { get; set; }

        public virtual Location AssociatedLocation { get; set; }

    }
}