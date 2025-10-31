using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontendBlazorApi.Models
{
    /// <summary>
    /// Modelo que representa un objetivo estratégico tal como lo devuelve y recibe la API
    /// EXPLICACIÓN PARA APRENDICES:
    /// Este modelo incluye una CLAVE FORÁNEA (IdVariable) que relaciona cada objetivo
    /// con una Variable Estratégica. Los atributos JsonPropertyName mapean las propiedades
    /// de C# con los nombres que usa la API JSON.
    /// </summary>
    public class ObjetivoEstrategico
    {
        [JsonPropertyName("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonPropertyName("IdVariable")]
        [Required]
        public int IdVariable { get; set; }

        [JsonPropertyName("Titulo")]
        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; }

        // Propiedad de navegación - NO se serializa en JSON
        // Se usa para acceder a los datos relacionados de la Variable Estratégica
        [ForeignKey("IdVariable")]
        public VariableEstrategica? VariableEstrategica { get; set; }

        // Propiedad de navegación - NO se serializa en JSON
        // Se usa para acceder a las metas estratégicas relacionadas
        public ICollection<MetaEstrategica>? MetasEstrategicas { get; set; }
       
    }
}


