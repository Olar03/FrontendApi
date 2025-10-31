
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontendBlazorApi.Models
{
    public class MetaEstrategica
    { 
       
        [JsonPropertyName("Id")]
        [Key] // Indica que esta propiedad es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que el valor se genera automáticamente por la base de datos
        public int Id { get; set; }

        
        [JsonPropertyName("IdObjetivo")]
        [Required] 
        public int IdObjetivo { get; set; }


        [JsonPropertyName("Titulo")]
        [Required]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; }

        // Navegación
        [ForeignKey("IdObjetivo")]
        public ObjetivoEstrategico? ObjetivoEstrategico { get; set; }

        
        /*        
        public ICollection<Meta_Proyecto>? MetaProyectos { get; set; }4
        */
    }
}
