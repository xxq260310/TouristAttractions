namespace TouristAttractions.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Spatial;
    using System.Linq;
    using TouristAttractions.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TouristAttractions.Models.TourismContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TouristAttractions.Models.TourismContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.TouristAttractions.AddOrUpdate(
                p => p.Name,
                new TouristAttraction
                {
                    Name = "Space Needle, Seattle",
                    Location = DbGeography.FromText("POINT(-122.348670959473 47.619930267334)")
                }
                );
            context.TouristAttractions.AddOrUpdate(
               p => p.Name,
               new TouristAttraction
               {
                   Name = "Pike Place Market, Seattle",
                   Location = DbGeography.FromText("POINT(-122.341697692871 47.6094245910645)")
               }
               );
            context.TouristAttractions.AddOrUpdate(
               p => p.Name,
               new TouristAttraction
               {
                   Name = "Statue of Liberty, NY",
                   Location = DbGeography.FromText("POINT(-74.0439682006836 40.6886405944824)")
               }
               );
        }
    }
}
