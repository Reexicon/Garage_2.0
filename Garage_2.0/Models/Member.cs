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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Member")]
        public string FullName { get { return (FirstName + " " + LastName).Trim(); } }

        // Navigation property
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}