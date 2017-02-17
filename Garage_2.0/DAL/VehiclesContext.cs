using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage_2._0.Models;

namespace Garage_2._0.DAL
{
    public class VehiclesContext : DbContext
    {
        public VehiclesContext() : base("VehiclesContext")  {   }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new VehicleContextInitializer());
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Member> Members { get; set; }

    }
}

//public class UniversityContext : DbContext
//{
//    public UniversityContext() : base("UniversityContext") { } //Name of Database

//    protected override void OnModelCreating(DbModelBuilder modelBuilder)
//    {
//        Database.SetInitializer(new UniversityContextInitializer());
//        base.OnModelCreating(modelBuilder);
//    }

//    public DbSet<Enrollment> Enrollments { get; set; }
//    public DbSet<Course> Courses { get; set; }
//    public DbSet<Student> Students { get; set; }

//}