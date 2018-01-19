using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Dtos
{
    public class LocationDto
    {

        public int LocationId { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public string Name { get; set; }
    }
}