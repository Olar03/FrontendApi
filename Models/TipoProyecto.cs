using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    /// <summary>
    /// Modelo que representa un tipo de proyecto tal como lo devuelve y recibe la API
    /// Categoriza los diferentes tipos de proyectos en el sistema
    /// </summary>
    public class TipoProyecto
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("Descripcion")]
        public string Descripcion { get; set; } = string.Empty;
    }
}