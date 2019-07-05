using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Display(Name = "Date & Time")]

        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        [Display(Name = "Select Vehicle by Plate Number")]
        public int VehicleId { get; set; }
        public Vehicle vehicle { get; set; }
        [Display(Name = "Select Payment Method")]
        public int PaymentTypeId { get; set; }
        public PaymentType paymentType { get; set; }
        public string MechanicId { get; set; }
        public ApplicationUser Mechanic { get; set; }

    }
}
