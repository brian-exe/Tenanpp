
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenanpp.Repository.Models{
    public class Inmobiliaria {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InmobiliariaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Localidad { get; set; }
        public string Cuit { get; set; }
        public string Url { get; set; }
    }

}