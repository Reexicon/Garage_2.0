using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{

    public enum Type { Airplane, Bike, Boat, Bus,Car }

    public class Vehicle
    {
        

        public int Id { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Vehicle Type")]
        public Type VehicleType { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        [Display(Name = "When Parked")]
        public DateTime WhenParked { get; set; }
    }
}