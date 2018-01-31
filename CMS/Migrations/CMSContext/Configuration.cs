namespace CMS.Migrations.CMSContext
{
    using System.Data.Entity.Migrations;
    using Models.CMSModel;
    using System.Reflection;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CMSContext";
        }

        protected override void Seed(CmsContext context)
        {
            SeedLocations(context);
        }

        private static void SeedLocations(CmsContext context)
        {
            //using stream reader to read from file
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "CMS.Migrations.CMSContext.TestLocations.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new FileNotFoundException();

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    List<Location> locations = new List<Location>();
                    //iterate over each line creating an object for each row, add them to the list
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        var elems = currentLine.Split(',');
                        locations.Add(new Location() { Name = elems[0], Town = elems[0], County = elems[1], Lat = float.Parse(elems[2]), Lng = float.Parse(elems[3]) });
                    }
                    //persist list to the database
                    context.Locations.AddOrUpdate(c => c.LocationId, locations.ToArray());
                }
            }
            context.SaveChanges();
        }


    }
}
