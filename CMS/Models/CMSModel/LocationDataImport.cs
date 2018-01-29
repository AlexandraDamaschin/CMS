using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    public class LocationDataImport
    {
        public string Town { get; set; }
        public string County { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Elevation { get; set; }
        public int Population { get; set; }
    }
}