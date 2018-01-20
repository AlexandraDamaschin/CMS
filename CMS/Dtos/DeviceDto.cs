using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Dtos;
namespace CMS.Dtos
{
    public class DeviceDto
    {

        public int DeviceId { get; set; }

        public int LocationId { get; set; }

        public int Build { get; set; }

        public string Name { get; set; }

        public bool HasError { get; set; }

        public LocationDto AssociatedLocation { get; set; }
    }
}