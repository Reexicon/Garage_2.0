﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class ReceiptModel
    {
        [Display(Name = "Total")]
        public string Cost { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}