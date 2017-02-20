using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Member")]
        public string FullName { get { return (FirstName + " " + LastName).Trim(); } }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone No is required")]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }

        [Display(Name = "Mail")]
        public string Mail { get; set; }

        // Navigation property
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}