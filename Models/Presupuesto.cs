using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Presupuesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("IdProyecto")]
        public int IdProyecto { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        [JsonPropertyName("MontoSolicitado")]
        public decimal MontoSolicitado { get; set; }

        [Required]
        [MaxLength(20)]
        [JsonPropertyName("Estado")]
        public string Estado { get; set; } = "Pendiente";

        [Column(TypeName = "decimal(15,2)")]
        [JsonPropertyName("MontoAprobado")]
        public decimal? MontoAprobado { get; set; }

        [JsonPropertyName("PeriodoAnio")]
        public int? PeriodoAnio { get; set; }

        [JsonPropertyName("FechaSolicitud")]
        public DateTime? FechaSolicitud { get; set; }

        [JsonPropertyName("FechaAprobacion")]
        public DateTime? FechaAprobacion { get; set; }

        [JsonPropertyName("Observaciones")]
        public string? Observaciones { get; set; }

        // Navegación
        [ForeignKey("IdProyecto")]
        public Proyecto? Proyecto { get; set; }

        public ICollection<DistribucionPresupuesto>? DistribucionesPresupuesto { get; set; }
        public ICollection<EjecucionPresupuesto>? EjecucionesPresupuesto { get; set; }
    }
}