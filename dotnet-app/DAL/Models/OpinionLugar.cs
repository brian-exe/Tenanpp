
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tenanpp.DAL.Models{
    public class OpinionLugar : BaseEntity{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Lugar")]
        public long LugarId { get; set; }
        
        [JsonIgnore] 
        public Lugar Lugar { get; set; }

        public bool RecomiendaLugar { get; set; }
        public string Pros { get; set; }
        public string Contras { get; set; }
        
    }

}