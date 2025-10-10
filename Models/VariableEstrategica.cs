using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    /// <summary>
    /// Modelo que representa una variable estratégica tal como lo devuelve y recibe la API
    /// Define las variables estratégicas del negocio para medición y control
    /// </summary>
    public class VariableEstrategica
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Titulo")]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; } = string.Empty;
    }
}