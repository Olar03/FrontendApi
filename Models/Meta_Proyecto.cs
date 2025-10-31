using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Meta_Proyecto
    {
        [Required]
        [JsonPropertyName("IdMeta")]
        public int IdMeta { get; set; }

        [Required]
        [JsonPropertyName("IdProyecto")]
        public int IdProyecto { get; set; }

        [JsonPropertyName("FechaAsociacion")]
        public DateTime? FechaAsociacion { get; set; }

        // Navegación
        [ForeignKey("IdMeta")]
        public MetaEstrategica? MetaEstrategica { get; set; }

        [ForeignKey("IdProyecto")]
        public Proyecto? Proyecto { get; set; }
    }
}