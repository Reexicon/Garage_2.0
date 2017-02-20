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

        [RegularExpression(@"^[A-Z]{3}[0-9]{3}", ErrorMessage = "The Input should be CCCNNN <br> C = Char N = Number")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        //[Display(Name = "Vehicle Type")]
        //public Type VehicleType { get; set; }
        [StringLength(12, MinimumLength = 3, ErrorMessage ="Minimum 3 Char and Maximum 12 Char")]
        public string Brand { get; set; }
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Minimum 3 Char and Maximum 12 Char")]
        public string Model { get; set; }
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Minimum 3 Char and Maximum 12 Char")]
        public string Color { get; set; }
        [Range(0,50, ErrorMessage ="Number of Wheels could be 0 to 50")]
        public int Wheels { get; set; }
        [Display(Name = "When Parked")]
        [DisplayFormat(DataFormatString = "{0:HH:mm - yyyy MMMM dd}")]
        public DateTime WhenParked { get; set; }
        [Display(Name = "Member")]
        public int MemberId { get; set; }
        [Display(Name = "Vehicle Type")]
        public int VehicleTypeId { get; set; }


        //Navigation  property
        public virtual Member Member { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}