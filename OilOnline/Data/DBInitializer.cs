using OilOnline.Data;
using OilOnline.Models;
using System;
using System.Linq;

namespace OilOnline.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OilOnlineContext context)
        {
            context.Database.EnsureCreated();

            // Look for any paymentTypes. Basically, if there is data, dont reseed
            if (context.PaymentTypes.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new ApplicationUser[]
            {
            new ApplicationUser{FirstName="Carson"},
            new ApplicationUser{FirstName="Meredith",LastName="Alonso",Description="Lifelong mechanic, reliable and quick!",IsMechanic=true},
            
            };
            foreach (ApplicationUser c in customers)
            {
                context.Users.Add(c);
            }
            context.SaveChanges();

            var oilTypes = new OilType[]
            {
            new OilType{Name="Conventional",PricePerQuart=22.00},
            new OilType{Name="Full Synthetic",PricePerQuart=23.00},
            new OilType{Name="Synthetic Blend",PricePerQuart=18.00},
            new OilType{Name="High Mileage",PricePerQuart=18.00},


            };
            foreach (OilType o in oilTypes)
            {
                context.OilTypes.Add(o);
            }
            context.SaveChanges();

            var paymentTypes = new PaymentType[]
            {
            new PaymentType{CardHolder="Carson Carmichael",CardNumber=1234,SecurityNumber=123,ExpirationDate="12/24",CustomerId=1},
           
            };
            foreach (PaymentType p in paymentTypes)
            {
                context.PaymentTypes.Add(p);
            }
            context.SaveChanges();

            var requests = new Request[]
            {
            new Request{DateAndTime=DateTime.Now, Location="414 Billacutty Rd, parked on the street",VehicleId=1,PaymentTypeId=1,MechanicId=2},

            };
            foreach (Request r in requests)
            {
                context.Requests.Add(r);
            }
            context.SaveChanges();
            var vehicles = new Vehicle[]
           {
            new Vehicle{PlateNumber="GOATS", Make="Jeep",Model="Cherokee",Year=1999,OilTypeId=4,CustomerId=1},

           };
            foreach (Vehicle v in vehicles)
            {
                context.Vehicles.Add(v);
            }
            context.SaveChanges();
        }
    }
}