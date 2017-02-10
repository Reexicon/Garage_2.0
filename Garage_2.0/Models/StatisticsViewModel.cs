using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class StatisticsViewModel
    {
            public Type VehicleType { get; set; }
            [Display(Name = "Quantity by Type")]
            public int QuantityByType { get; set; }

    }
}