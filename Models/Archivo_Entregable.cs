using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Archivo_Entregable
    {
        [Required]
        [JsonPropertyName("IdArchivo")]
        public int IdArchivo { get; set; }

        [Required]
        [JsonPropertyName("IdEntregable")]
        public int IdEntregable { get; set; }

        [JsonPropertyName("FechaAsociacion")]
        [Required]
        public DateTime? FechaAsociacion { get; set; }

        // Navegación
        [ForeignKey("IdArchivo")]
        public Archivo? Archivo { get; set; }

        [ForeignKey("IdEntregable")]
        public Entregable? Entregable { get; set; }
    }
}