using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Estado_Proyecto
    {
        [Key]
        [JsonPropertyName("IdProyecto")]
        public int IdProyecto { get; set; }

        [Required]
        [JsonPropertyName("IdEstado")]
        public int IdEstado { get; set; }

        [JsonPropertyName("FechaAsociacion")]
        public DateTime? FechaAsociacion { get; set; }

        // Navegación
        [ForeignKey("IdProyecto")]
        public Proyecto? Proyecto { get; set; }

        [ForeignKey("IdEstado")]
        public Estado? Estado { get; set; }
    }
}