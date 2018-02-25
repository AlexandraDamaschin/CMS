namespace CMS.ViewModels
{
    public class DashboardPanelsViewModel
    {
//        public int? DevicesCount { get; set; }
//        public int? EventsCount { get; set; }
//        public int? EventCategoriesCount { get; set; }
//        public int? LocationsCount { get; set; }
//        public int? OrganisersCount { get; set; }
//
        public DashboardPanelsViewModel(int devicesCount, int eventsCount, int eventsCategoriesCount, int locationsCount, int organisersCount)
        {
            DevicesCount = devicesCount;
            EventsCount = eventsCount;
            EventCategoriesCount = eventsCategoriesCount;
            LocationsCount = locationsCount;
            OrganisersCount = organisersCount;
        }

        private int? _devicesCount;
        public int DevicesCount
        {
            get { return _devicesCount.GetValueOrDefault(-1); }
            set { _devicesCount = value; }
        }

        private int? _eventsCount;
        public int EventsCount
        {
            get { return _eventsCount.GetValueOrDefault(-1); }
            set { _eventsCount = value; }
        }

        private int? _eventCategoriesCount;
        public int EventCategoriesCount
        {
            get { return _eventCategoriesCount.GetValueOrDefault(-1); }
            set { _eventCategoriesCount = value; }
        }

        private int? _locationsCount;
        public int LocationsCount
        {
            get { return _locationsCount.GetValueOrDefault(-1); }
            set { _locationsCount = value; }
        }

        private int? _organisersCount;
        public int OrganisersCount
        {
            get { return _organisersCount.GetValueOrDefault(-1); }
            set { _organisersCount = value; }
        }

    }
}