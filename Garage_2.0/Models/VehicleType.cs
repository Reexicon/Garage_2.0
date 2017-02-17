using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        [Display(Name = "Vehicle Type")]
        public string TypeName { get; set; }

        // Navigation property
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}