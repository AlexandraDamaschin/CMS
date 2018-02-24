using System.Collections.Generic;

namespace CMS.Models
{
    public static class RoleHelper
    {
        public const string Admin = "SuperAdmin";
        public const string User = "User";

        public const string CanManageEvents = "CanManageEvents";
        public const string CanManageEventCategories = "CanManageEventCategories";
        public const string CanManageLocations = "CanManageLocations";
        public const string CanManageOrganisers = "CanManageOrganisers";
        public const string CanManageDevices = "CanManageDevices";
    }
}