using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Dtos
{
    public class LocationDto
    {

        public int LocationID { get; set; }
        public float LAT { get; set; }
        public float LONG { get; set; }
        public string Name { get; set; }
    }
}