using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tenanpp.Models{
    public class OpinionInmobiliariaGet{
        public int Id { get; set; }
        public int InmobiliariaId { get; set; }
        public int ValoracionAtencion { get; set; }
        public int ValoracionResponsabilidad { get; set; }
        public int ValoracionConductaEtica { get; set; }
        public string ComentarioPositivo { get; set; }
        public string ComentarioNegativo { get; set; }
        public bool AceptaPagoElectronico { get; set; }
    }
}