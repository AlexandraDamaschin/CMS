using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Dtos;
namespace CMS.Dtos
{
    public class DeviceDto
    {

        public int DeviceID { get; set; }

        public int LocationID { get; set; }

        public int Build { get; set; }


        public LocationDto associatedLocation { get; set; }
    }
}