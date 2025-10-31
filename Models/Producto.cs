using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Producto
    {
        [JsonPropertyName("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonPropertyName("IdTipoProducto")]
        [Required]
        public int IdTipoProducto { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("Codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("Titulo")]
        [Required]
        [MaxLength(255)]
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

        [JsonPropertyName("RutaLogo")]
        public string? RutaLogo { get; set; }

        // Navegación
        [ForeignKey("IdTipoProducto")]
        public TipoProducto? TipoProducto { get; set; }

        public ICollection<Proyecto_Producto>? ProyectoProductos { get; set; }
        public ICollection<Producto_Entregable>? ProductoEntregables { get; set; }
    }
}




    
