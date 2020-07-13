using System;

namespace Tenanpp.Models{
    public class OpinionInmobiliariaPost{
        public long InmobiliariaId { get; set; }
        public int ValoracionAtencion { get; set; }
        public int ValoracionResponsabilidad { get; set; }
        public int ValoracionConductaEtica { get; set; }
        public string ComentarioPositivo { get; set; }
        public string ComentarioNegativo { get; set; }
        public bool AceptaPagoElectronico { get; set; }
    }
}