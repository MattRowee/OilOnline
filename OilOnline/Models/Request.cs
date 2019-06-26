﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int VehicleId { get; set; }
        public Vehicle vehicle { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType paymentType { get; set; }
        public int MechanicId { get; set; }
        public ApplicationUser Mechanic { get; set; }

    }
}