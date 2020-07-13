
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenanpp.DAL.Models{
    public class FotoPerfil : BaseEntity{
        public long Id { get; set; }
        [ForeignKey("Inmobiliaria")]
        public long InmobiliariaId { get; set; }
        public string Titulo { get; set; }
        public byte[] Data { get; set; }
    }
}