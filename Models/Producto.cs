using System.Text.Json.Serialization;

namespace FrontendBlazorApi.Models
{
    // Modelo que representa un producto tal como lo devuelve y recibe la API
    public class Producto
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; } = string.Empty;

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("stock")]
        public int Stock { get; set; }

        [JsonPropertyName("valorunitario")]   // Ojo: coincide con el JSON de la API
        public double ValorUnitario { get; set; }
    }

}


    // Clase genérica para mapear la respuesta de la API
    
