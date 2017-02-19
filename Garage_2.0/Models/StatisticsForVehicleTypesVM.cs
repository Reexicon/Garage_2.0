using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class StatisticsForVehicleTypesVM
    {
        public string VehicleType { get; set; }
        [Display(Name = "Quantity by Type")]
        public int QuantityByType { get; set; }
    }
}