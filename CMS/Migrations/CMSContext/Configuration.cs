namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.CMSModel;
    using System.Reflection;
    using System.IO;
    using System.Text;
    using CsvHelper;

    internal sealed class Configuration : DbMigrationsConfiguration<CMS.Models.CMSModel.CmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CMSContext";
        }

        protected override void Seed(CMS.Models.CMSModel.CmsContext context)
        {
//            SeedLocations(context);
        }

        //  Seed locations from embedded IrishTowns.csv
        private void SeedLocations(CMS.Models.CMSModel.CmsContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "CMS.Migrations.CMSContext.IrishTowns.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = true;
                    var locationData = csvReader.GetRecords<LocationDataImport>().ToArray();

                    foreach (var locationItem in locationData)
                    {
                        context.Locations.AddOrUpdate(m =>
                                new { m.Name, m.Town, m.County, m.Lat, m.Lng },
                            new Location
                            {
                                Name = locationItem.Town,
                                Town = locationItem.Town,
                                County = locationItem.County,
                                Lat = locationItem.Latitude,
                                Lng = locationItem.Longitude,
                            });
                    }
                }
            }
        }
    }
}
