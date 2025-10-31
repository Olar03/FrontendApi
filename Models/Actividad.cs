using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Actividad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("IdEntregable")]
        public int IdEntregable { get; set; }

        [Required]
        [MaxLength(255)]
        [JsonPropertyName("Titulo")]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("FechaInicio")]
        public DateTime? FechaInicio { get; set; }

        [JsonPropertyName("FechaFinPrevista")]
        public DateTime? FechaFinPrevista { get; set; }

        [JsonPropertyName("FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [JsonPropertyName("FechaFinalizacion")]
        public DateTime? FechaFinalizacion { get; set; }

        [JsonPropertyName("Prioridad")]
        public int? Prioridad { get; set; }

        [Range(0, 100)]
        [JsonPropertyName("PorcentajeAvance")]
        public int? PorcentajeAvance { get; set; }

        // Navegación
        [ForeignKey("IdEntregable")]
        public Entregable? Entregable { get; set; }
    }
}