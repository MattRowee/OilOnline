﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OilOnline.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "License Plate")]
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        [Display(Name = "Image")]
        public byte[] VehicleImage { get; set; }
        [NotMapped]
        public IFormFile ImageUpload { get; set; }
        [Display (Name ="Oil Type")]
        public int OilTypeId { get; set; }
        public OilType Oil { get; set; }
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
