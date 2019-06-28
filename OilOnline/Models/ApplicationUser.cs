using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Models
{
    public class ApplicationUser : IdentityUser 
    {
   
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string PhotoURL { get; set; }
        public string Description { get; set; }
        public bool IsMechanic { get; set; }

        public ICollection<PaymentType> PaymentTypes { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Request> Requests { get; set; }

    }
}
