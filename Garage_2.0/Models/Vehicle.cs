using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{

    public enum Type {Car ,Airplane, Boat, Bike, Bus}

    public class Vehicle
    {
        

        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public Type VehicleType { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        public DateTime WhenParked { get; set; }
    }
}