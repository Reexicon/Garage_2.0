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
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Vehicle Type")]
        public Type VehicleType { get; set; }
        [StringLength(12, MinimumLength = 3)]
        public string Brand { get; set; }
        [RegularExpression(@"^[A-Za-z0-9'-']{3,10}")]
        [StringLength(10, MinimumLength = 3)]
        public string Color { get; set; }
        [Range(0,50)]
        public int Wheels { get; set; }
        [Display(Name = "When Parked")]
        public DateTime WhenParked { get; set; }
    }
}