
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenanpp.DAL.Models{
    public class ValoracionInmobiliaria {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Inmobiliaria")]
        public long InmobiliariaId { get; set; }
        public Inmobiliaria Inmobiliaria { get; set; }
        public float ValoracionResponsabilidad { get; set; }
        public float ValoracionAtencion { get; set; }
        public float ValoracionConductaEtica { get; set; }
        public float VotosAceptaPagoElectronico { get; set; }
        public float VotosNoAceptaPagoElectronico { get; set; }
    }

}