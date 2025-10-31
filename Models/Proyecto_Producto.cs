using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Proyecto_Producto
    {
        [Required]
        [JsonPropertyName("IdProyecto")]
        public int IdProyecto { get; set; }

        [Required]
        [JsonPropertyName("IdProducto")]
        public int IdProducto { get; set; }

        [JsonPropertyName("FechaAsociacion")]
        public DateTime? FechaAsociacion { get; set; }

        // Navegación
        [ForeignKey("IdProyecto")]
        public Proyecto? Proyecto { get; set; }

        [ForeignKey("IdProducto")]
        public Producto? Producto { get; set; }
    }
}