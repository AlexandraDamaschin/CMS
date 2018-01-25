﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    [Table("EventCategory")]
    public class EventCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventCatId { get; set; }
        public string Name { get; set; }
        public Boolean Outdoor { get; set; }
        public Boolean Family { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}