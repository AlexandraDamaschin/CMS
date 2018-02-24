using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class LocationFormViewModel
    {
        public Location Location { get; set; }

        public string Title => Location.LocationId != 0 ? "Edit Location" : "New Location";
    }
}