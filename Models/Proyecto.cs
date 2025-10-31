using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("IdProyectoPadre")]
        public int? IdProyectoPadre { get; set; }

        [Required]
        [JsonPropertyName("IdResponsable")]
        public int IdResponsable { get; set; }

        [Required]
        [JsonPropertyName("IdTipoProyecto")]
        public int IdTipoProyecto { get; set; }

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

        [JsonPropertyName("RutaLogo")]
        public string? RutaLogo { get; set; }

        // Navegación
        [ForeignKey("IdProyectoPadre")]
        public Proyecto? ProyectoPadre { get; set; }

        [ForeignKey("IdResponsable")]
        public Responsable? Responsable { get; set; }

        [ForeignKey("IdTipoProyecto")]
        public TipoProyecto? TipoProyecto { get; set; }

        public ICollection<Proyecto>? ProyectosHijos { get; set; }
        public Estado_Proyecto? EstadoProyecto { get; set; }
        public ICollection<Proyecto_Producto>? ProyectoProductos { get; set; }
        public ICollection<Presupuesto>? Presupuestos { get; set; }
        public ICollection<DistribucionPresupuesto>? DistribucionesPresupuesto { get; set; }
        public ICollection<Meta_Proyecto>? MetaProyectos { get; set; }
    }
}