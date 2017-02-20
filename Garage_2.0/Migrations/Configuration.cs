namespace Garage_2._0.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage_2._0.DAL.VehiclesContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
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
            var vehicleTypes = new VehicleType[]  //Can be anonymous
            {
                new VehicleType { TypeName = "Airplane" },
                new VehicleType { TypeName = "Bike" },
                new VehicleType { TypeName = "Boat" },
                new VehicleType { TypeName = "Bus" },
                new VehicleType { TypeName = "Car" },
            };

            context.VehicleTypes.AddRange(vehicleTypes);
            context.SaveChanges();


            var members = new Member[]
            {
                new Member { FirstName = "David", LastName = "Duke" },
                new Member { FirstName = "Leif", LastName = "Clown" },
                new Member { FirstName = "Lena", LastName = "Late" },
                new Member { FirstName = "John", LastName = "King" },
                new Member { FirstName = "Dimitris", LastName = "Hulk" }
            };

            context.Members.AddRange(members);
            context.SaveChanges();

            var vehicles = new Vehicle[]
            {
                new Vehicle { RegistrationNumber = "AAA111", VehicleTypeId= vehicleTypes[0].Id,MemberId= members[0].Id, Brand = "Volvo", Model = "740GL", Color = "White", Wheels = 4, WhenParked = new DateTime(2016, 01, 01, 01, 01, 0, 0) },
                new Vehicle { RegistrationNumber = "AAB112", VehicleTypeId= vehicleTypes[1].Id,MemberId= members[1].Id, Brand = "Mercedes", Model = "740GL", Color = "Red", Wheels = 4, WhenParked = new DateTime(2016, 02, 02, 02, 02, 0, 0) },
                new Vehicle { RegistrationNumber = "AAC113", VehicleTypeId= vehicleTypes[2].Id,MemberId= members[2].Id, Brand = "B-52", Model = "740GL", Color = "White", Wheels = 10, WhenParked = new DateTime(2016, 03, 03, 03, 03, 0, 0) },
                new Vehicle { RegistrationNumber = "AAD114", VehicleTypeId= vehicleTypes[3].Id,MemberId= members[0].Id, Brand = "Mig-23", Model = "740GL", Color = "Black", Wheels = 6, WhenParked = new DateTime(2016, 04, 04, 04, 04, 0, 0) },
                new Vehicle { RegistrationNumber = "AAE115", VehicleTypeId= vehicleTypes[4].Id,MemberId= members[1].Id, Brand = "Kawasaki", Model = "740GL", Color = "Red", Wheels = 2, WhenParked = new DateTime(2016, 05, 05, 05, 05, 0, 0) },
                new Vehicle { RegistrationNumber = "AAF116", VehicleTypeId= vehicleTypes[0].Id,MemberId= members[2].Id, Brand = "Yamaha", Model = "740GL", Color = "Red", Wheels = 3, WhenParked = new DateTime(2016, 06, 06, 06, 06, 0, 0) },
                new Vehicle { RegistrationNumber = "AAG117", VehicleTypeId= vehicleTypes[1].Id,MemberId= members[0].Id, Brand = "Sunseeker", Model = "740GL", Color = "Blue", Wheels = 0, WhenParked = new DateTime(2016, 07, 07, 07, 07, 0, 0) },
                new Vehicle { RegistrationNumber = "AAH118", VehicleTypeId= vehicleTypes[2].Id,MemberId= members[0].Id, Brand = "Viking Yacht", Model = "740GL", Color = "Brown", Wheels = 0, WhenParked = new DateTime(2016, 08, 08, 08, 08, 0, 0) },
                new Vehicle { RegistrationNumber = "AAJ119", VehicleTypeId= vehicleTypes[0].Id,MemberId= members[0].Id, Brand = "Scania", Model = "740GL", Color = "Red", Wheels = 6, WhenParked = new DateTime(2016, 09, 09, 09, 09, 0, 0) },
                new Vehicle { RegistrationNumber = "AAK121", VehicleTypeId= vehicleTypes[0].Id,MemberId= members[0].Id, Brand = "Volvo", Model = "740GL", Color = "Blue", Wheels = 8, WhenParked = new DateTime(2016, 10, 10, 10, 10, 0, 0) },
                new Vehicle { RegistrationNumber = "AAL122", VehicleTypeId= vehicleTypes[1].Id,MemberId= members[1].Id, Brand = "Volvo", Model = "740GL", Color = "White", Wheels = 4, WhenParked = new DateTime(2016, 11, 11, 11, 11, 0, 0) },
                new Vehicle { RegistrationNumber = "SUP122", VehicleTypeId= vehicleTypes[1].Id,MemberId= members[3].Id, Brand = "Harley David", Model = "1200cc", Color = "Gold", Wheels = 3, WhenParked = new DateTime(2017, 01, 14, 08, 20, 0, 0) },
                new Vehicle { RegistrationNumber = "JAS039", VehicleTypeId= vehicleTypes[0].Id,MemberId= members[4].Id, Brand = "JAS-39", Model = "Gripen", Color = "Silver", Wheels = 6, WhenParked = new DateTime(2017, 02, 13, 15, 23, 0, 0) }
            };

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
        }
    }
}
