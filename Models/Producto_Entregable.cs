using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Producto_Entregable
    {
        [Required]
        [JsonPropertyName("IdProducto")]
        public int IdProducto { get; set; }

        [Required]
        [JsonPropertyName("IdEntregable")]
        public int IdEntregable { get; set; }

        [JsonPropertyName("FechaAsociacion")]
        public DateTime? FechaAsociacion { get; set; }

        // Navegación
        [ForeignKey("IdProducto")]
        public Producto? Producto { get; set; }

        [ForeignKey("IdEntregable")]
        public Entregable? Entregable { get; set; }
    }
}