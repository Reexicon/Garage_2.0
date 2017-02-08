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
        public VehiclesContext() : base("VehiclesContext")
        {
            
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}