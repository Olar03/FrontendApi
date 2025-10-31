using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    public class Responsable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("IdTipoResponsable")]
        public int IdTipoResponsable { get; set; }

        [Required]
        [JsonPropertyName("IdUsuario")]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        [ForeignKey("IdTipoResponsable")]
        public TipoResponsable? TipoResponsable { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        public ICollection<Proyecto>? Proyectos { get; set; }
        public ICollection<Responsable_Entregable>? ResponsableEntregables { get; set; }
    }
}