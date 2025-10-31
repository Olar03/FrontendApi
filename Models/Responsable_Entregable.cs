using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Responsable_Entregable
    {
        [Required]
        [JsonPropertyName("IdResponsable")]
        public int IdResponsable { get; set; }

        [Required]
        [JsonPropertyName("IdEntregable")]
        public int IdEntregable { get; set; }

        [JsonPropertyName("FechaAsociacion")]
        public DateTime? FechaAsociacion { get; set; }

        // Navegación
        [ForeignKey("IdResponsable")]
        public Responsable? Responsable { get; set; }

        [ForeignKey("IdEntregable")]
        public Entregable? Entregable { get; set; }
    }
}