using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    public class CmsContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public CmsContext()
            : base("DefaultConnection")
        {
        }

        public static CmsContext Create()
        {
            return new CmsContext();
        }
    }
}