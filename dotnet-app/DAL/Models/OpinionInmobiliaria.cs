
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Tenanpp.DAL.Models{

    public class OpinionInmobiliaria : BaseEntity{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Inmobiliaria")]
        public long InmobiliariaId { get; set; }
        public Inmobiliaria Inmobiliaria { get; set; }
        public int ValoracionAtencion { get; set; }
        public int ValoracionResponsabilidad { get; set; }
        public int ValoracionConductaEtica { get; set; }
        
        [StringLength(1200)]
        public string ComentarioPositivo { get; set; }

        [StringLength(1200)]
        public string ComentarioNegativo { get; set; }
        public bool AceptaPagoElectronico { get; set; }
        public DateTime FechaOpinion { get; set; }
        public string IpOrigen { get; set; }
    }


}