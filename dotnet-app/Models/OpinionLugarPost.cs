using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tenanpp.Models{
    public class OpinionLugarPost{
        
        [Required]
        [StringLength(250)]
        public string Pros { get; set; }

        [Required]
        [StringLength(250)]
        public string Contras { get; set; }

        [Required]
        [DefaultValue(null)]
        public bool? RecomiendaLugar { get; set; }
    }
}