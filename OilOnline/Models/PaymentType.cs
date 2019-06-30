using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string CardHolder { get; set; }
        public int CardNumber { get; set; }
        public int SecurityNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }

    }
}
