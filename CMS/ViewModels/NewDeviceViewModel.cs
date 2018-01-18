using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class NewDeviceViewModel
    {
        public IEnumerable<Location> Locations { get; set; }

        public Device Device { get; set; }


    }
}