
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenanpp.DAL.Models{
    public class EstadisticasInmobiliaria : BaseEntity{
        [Key]
        public long InmobiliariaId { get; set; }
        public double PromedioAtencion { get; set; }
        public double PromedioResponsabilidad { get; set; }
        public double PromedioConductaEtica { get; set; }
        public int VotosPagoElectronico { get; set; }
        public int VotosNoPagoElectronico { get; set; }
    }
}