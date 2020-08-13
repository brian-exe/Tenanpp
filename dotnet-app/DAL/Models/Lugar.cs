
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace Tenanpp.DAL.Models{
    public class Lugar : BaseEntity{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Direccion { get; set; }

        [JsonIgnore]
        [Column(TypeName = "geometry")]  
        public Point Location { get; set; } 
    }

}