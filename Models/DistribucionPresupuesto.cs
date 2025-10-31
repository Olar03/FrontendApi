using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class DistribucionPresupuesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("IdPresupuestoPadre")]
        public int IdPresupuestoPadre { get; set; }

        [Required]
        [JsonPropertyName("IdProyectoHijo")]
        public int IdProyectoHijo { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        [JsonPropertyName("MontoAsignado")]
        public decimal MontoAsignado { get; set; }

        // Navegación
        [ForeignKey("IdPresupuestoPadre")]
        public Presupuesto? PresupuestoPadre { get; set; }

        [ForeignKey("IdProyectoHijo")]
        public Proyecto? ProyectoHijo { get; set; }
    }
}