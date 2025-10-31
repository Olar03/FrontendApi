using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontendBlazorApi.Models
{
    /// <summary>
    /// Modelo que representa una variable estratégica tal como lo devuelve y recibe la API
    /// Define las variables estratégicas del negocio para medición y control
    /// </summary>
    public class VariableEstrategica
    {
        [JsonPropertyName("Id")]
        [Key] // Indica que esta propiedad es la clave primaria 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que el valor se genera automáticamente por la base de datos
        public int? Id { get; set; }

        [JsonPropertyName("Titulo")]
        [Required] // Indica que esta propiedad es obligatoria
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; } = string.Empty;

        // Navegación
        public ICollection<ObjetivoEstrategico>? ObjetivosEstrategicos { get; set; }
    }
}