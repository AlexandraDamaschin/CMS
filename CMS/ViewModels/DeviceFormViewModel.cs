using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class DeviceFormViewModel
    {
        public IEnumerable<Location> Locations { get; set; }

        public Device Device { get; set; }

        public string Title => Device.DeviceId != 0 ? "Edit Device" : "New Device";
    }
}