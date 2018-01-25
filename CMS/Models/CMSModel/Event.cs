using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [ForeignKey("AssociatedEvent")]
        public int EventCatId { get; set; }

        [ForeignKey("AssociatedLocation")]
        public int LocationId { get; set; }

        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OrganiserId { get; set; }

        public int Priority { get; set; }
        public string Details { get; set; }
        public int Owner { get; set; }

        public virtual EventCategory AssociatedEvent { get; set; }

        public virtual Location AssociatedLocation { get; set; }
    }
}