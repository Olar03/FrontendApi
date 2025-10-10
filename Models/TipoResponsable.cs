using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    /// <summary>
    /// Modelo que representa un tipo de responsable tal como lo devuelve y recibe la API
    /// Define los diferentes tipos de responsabilidades en el sistema
    /// </summary>
    public class TipoResponsable
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Titulo")]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("Descripcion")]
        public string Descripcion { get; set; } = string.Empty;
    }
}