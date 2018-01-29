using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Dtos
{
    public class EventCategoryDto
    {
        public int EventCatId { get; set; }

        public string Name { get; set; }

        public bool Outdoor { get; set; }

        public bool Family { get; set; }

        public bool Free { get; set; }

        public string Icon { get; set; }
    }
}