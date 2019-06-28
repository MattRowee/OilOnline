using Microsoft.EntityFrameworkCore;
using OilOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Data
{
    public class OilOnlineContext : DbContext 
    {
        public OilOnlineContext(DbContextOptions<OilOnlineContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<OilType> OilTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<OilType>().ToTable("Oil Type");
            modelBuilder.Entity<PaymentType>().ToTable("Payment Type");
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");

        }
    }
}
