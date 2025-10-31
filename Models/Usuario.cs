using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    //Modelo que representa un usuario tal como lo devuelve y recibe la API
    public class Usuario
    {
        [JsonPropertyName("Id")]
        [Key] // Indica que esta propiedad es la clave primaria
        public int? Id { get; set; }

        [JsonPropertyName("Email")]
        [Required] // Indica que esta propiedad es obligatoria
        [EmailAddress] // Valida que el formato sea de correo electrónico
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Contrasena")]
        [Required] // Indica que esta propiedad es obligatoria
        public string Contrasena { get; set; } = string.Empty;

        [JsonPropertyName("TipoUsuario")]
        [Required] // Indica que esta propiedad es obligatoria
        public string TipoUsuario { get; set; } = string.Empty;

        [JsonPropertyName("RutaAvatar")]
        public string? RutaAvatar { get; set; } = string.Empty;

        [JsonPropertyName("Activo")]
        [Required] // Indica que esta propiedad es obligatoria
        public bool Activo { get; set; }

        //Navegación 
        public ICollection<Archivo>? Archivos { get; set; }

    }

    /// <summary>
    /// Represents a generic API response wrapper that encapsulates data returned from API calls.
    /// </summary>
    /// <typeparam name="T">The type of data being returned in the API response.</typeparam>
    /// <remarks>
    /// This class represents the standard response format from the API.
    /// The JSON property name mapping ensures proper deserialization from API responses.
    /// </remarks>
    public class RespuestaApi<T>
    {
        [JsonPropertyName("exito")]
        public bool Exito { get; set; }

        [JsonPropertyName("mensaje")]
        public string Mensaje { get; set; } = string.Empty;

        [JsonPropertyName("datos")]
        public T? Datos { get; set; }
    }
}
