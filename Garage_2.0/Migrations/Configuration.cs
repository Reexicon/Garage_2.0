namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage_2._0.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<Garage_2._0.DAL.VehiclesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage_2._0.DAL.VehiclesContext context)
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
            
            context.Vehicles.AddOrUpdate(
                m => m.RegistrationNumber,
                new Vehicle { RegistrationNumber = "AAA111", VehicleType = Models.Type.Car, Brand = "Volvo", Model = "740GL", Color = "White", Wheels = 4, WhenParked = new DateTime(2016, 01, 01, 01, 01, 0, 0) },
                new Vehicle { RegistrationNumber = "AAB112", VehicleType = Models.Type.Car, Brand = "Mercedes", Model = "740GL", Color = "Red", Wheels = 4, WhenParked = new DateTime(2016, 02, 02, 02, 02, 0, 0) },
                new Vehicle { RegistrationNumber = "AAC113", VehicleType = Models.Type.Airplane, Brand = "B-52", Model = "740GL", Color = "White", Wheels = 10, WhenParked = new DateTime(2016, 03, 03, 03, 03, 0, 0) },
                new Vehicle { RegistrationNumber = "AAD114", VehicleType = Models.Type.Airplane, Brand = "Mig-23", Model = "740GL", Color = "Black", Wheels = 6, WhenParked = new DateTime(2016, 04, 04, 04, 04, 0, 0) },
                new Vehicle { RegistrationNumber = "AAE115", VehicleType = Models.Type.Bike, Brand = "Kawasaki", Model = "740GL", Color = "Red", Wheels = 2, WhenParked = new DateTime(2016, 05, 05, 05, 05, 0, 0) },
                new Vehicle { RegistrationNumber = "AAF116", VehicleType = Models.Type.Bike, Brand = "Yamaha", Model = "740GL", Color = "Red", Wheels = 3, WhenParked = new DateTime(2016, 06, 06, 06, 06, 0, 0) },

                new Vehicle { RegistrationNumber = "AAG117", VehicleType = Models.Type.Boat, Brand = "Sunseeker", Model = "740GL", Color = "Blue", Wheels = 0, WhenParked = new DateTime(2016, 07, 07, 07, 07, 0, 0) },
                new Vehicle { RegistrationNumber = "AAH118", VehicleType = Models.Type.Boat, Brand = "Viking Yacht", Model = "740GL", Color = "Brown", Wheels = 0, WhenParked = new DateTime(2016, 08, 08, 08, 08, 0, 0) },
                new Vehicle { RegistrationNumber = "AAJ119", VehicleType = Models.Type.Bus, Brand = "Scania", Model = "740GL", Color = "Red", Wheels = 6, WhenParked = new DateTime(2016, 09, 09, 09, 09, 0, 0) },
                new Vehicle { RegistrationNumber = "AAK121", VehicleType = Models.Type.Bus, Brand = "Volvo", Model = "740GL", Color = "Blue", Wheels = 8, WhenParked = new DateTime(2016, 10, 10, 10, 10, 0, 0) },
                new Vehicle { RegistrationNumber = "AAL122", VehicleType = Models.Type.Car, Brand = "Volvo", Model = "740GL", Color = "White", Wheels = 4, WhenParked = new DateTime(2016, 11, 11, 11, 11, 0, 0) }
                );
            context.SaveChanges();
    
        }
    }
}
