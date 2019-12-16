
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Tenanpp.Models{

    public class OpinionInmobiliaria{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OpinionInmobiliariaId { get; set; }
        [ForeignKey("Inmobiliaria")]
        public long InmobiliariaId { get; set; }
        public Inmobiliaria Inmobiliaria { get; set; }
        public int Valoracion { get; set; }
        [StringLength(500)]
        public string Comentario { get; set; }
        public DateTime FechaOpinion { get; set; }
        public string IpOrigen { get; set; }
    }


}