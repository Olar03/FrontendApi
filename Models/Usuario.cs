using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    //Modelo que representa un usuario tal como lo devuelve y recibe la API
    public class Usuario
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Contrasena")]
        public string Contrasena { get; set; } = string.Empty;

        [JsonPropertyName("RutaAvatar")]
        public string? RutaAvatar { get; set; } = string.Empty;

        [JsonPropertyName("Activo")]
        public bool Activo { get; set; }
    }

    // Clase genérica para mapear la respuesta de la API
    public class RespuestaApi<T>
    {
        [JsonPropertyName("datos")]   // La API devuelve todo dentro de "datos"
        public T? Datos { get; set; }
    }
}
