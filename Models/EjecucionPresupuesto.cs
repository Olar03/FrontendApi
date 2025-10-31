using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class EjecucionPresupuesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("IdPresupuesto")]
        public int IdPresupuesto { get; set; }

        [Required]
        [JsonPropertyName("Anio")]
        public int Anio { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        [JsonPropertyName("MontoPlaneado")]
        public decimal? MontoPlaneado { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        [JsonPropertyName("MontoEjecutado")]
        public decimal? MontoEjecutado { get; set; }

        [JsonPropertyName("Observaciones")]
        public string? Observaciones { get; set; }

        // Navegación
        [ForeignKey("IdPresupuesto")]
        public Presupuesto? Presupuesto { get; set; }
    }
}