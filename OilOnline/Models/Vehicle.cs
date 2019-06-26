using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int OilTypeId { get; set; }
        public OilType Oil { get; set; }
        public int CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
