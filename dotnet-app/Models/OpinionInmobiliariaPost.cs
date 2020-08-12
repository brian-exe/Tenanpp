using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tenanpp.Models{
    public class OpinionInmobiliariaPost{

        [Required]
        [Range(1,5)]
        public int ValoracionAtencion { get; set; }

        [Required]
        [Range(1,5)]
        public int ValoracionResponsabilidad { get; set; }

        [Required]
        [Range(1,5)]
        public int ValoracionConductaEtica { get; set; }

        [Required]
        [StringLength(500)]
        public string ComentarioPositivo { get; set; }
        
        [Required]
        [StringLength(500)]
        public string ComentarioNegativo { get; set; }
        
        [Required]
        [DefaultValue(null)]
        public bool? AceptaPagoElectronico { get; set; }
        public string IpOrigen { get; set; } ="";
    }
}