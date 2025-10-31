using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    /// <summary>
    /// Modelo que representa un archivo tal como lo devuelve y recibe la API
    /// Define la estructura y propiedades de un archivo en el sistema
    /// </summary>

    public class Archivo
    {
        [JsonPropertyName("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [JsonPropertyName("IdUsuario")]
        [Required]
        public int IdUsuario { get; set; }

        [JsonPropertyName("Ruta")]
        [Required]
        public string Ruta { get; set; } = string.Empty;

        [JsonPropertyName("Nombre")]
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("Tipo")]
        [MaxLength(50)]
        public string? Tipo { get; set; }

        [JsonPropertyName("Fecha")]
        public DateTime? Fecha { get; set; }

        // Navegación
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        

        /*
        TODO: Descomentar cuando se implemente la relación con Archivo_Entregable
        public ICollection<Archivo_Entregable>? ArchivoEntregables { get; set; }*/
    }
}
