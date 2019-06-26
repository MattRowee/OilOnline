using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Models
{
    public class OilType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PricePerQuart { get; set; }
    }
}
