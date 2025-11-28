using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    /// <summary>
    /// Modelo que representa un entregable tal como lo devuelve y recibe la API
    /// Define los entregables de proyectos con sus fechas y estado de progreso
    /// </summary>
    public class Entregable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("Codigo")]
        public string? Codigo { get; set; }

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

        // Navegación
        public ICollection<Producto_Entregable>? ProductoEntregables { get; set; }
        public ICollection<Responsable_Entregable>? ResponsableEntregables { get; set; }
        public ICollection<Archivo_Entregable>? ArchivoEntregables { get; set; }
        public ICollection<Actividad>? Actividades { get; set; }
    }
}