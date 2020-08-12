using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tenanpp.Models{
    public class LugarPost{

        [Required]
        [StringLength(500)]
        public string Direccion { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }


    }
}