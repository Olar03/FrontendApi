using Microsoft.JSInterop;
using System.Net.Http.Json;
using FrontendBlazorApi.Models;

namespace FrontendBlazorApi.Services
{
    public class AuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IJSRuntime jsRuntime, IHttpClientFactory httpClientFactory)
        {
            _jsRuntime = jsRuntime;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> EstáAutenticado() // Verificar si el usuario está autenticado
        {
            try
            {
                var usuario = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "usuario_logueado"); // Obtener el nombre del usuario desde el almacenamiento local
                return !string.IsNullOrEmpty(usuario);
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> ObtenerUsuarioActual()
        {
            try
            {
                return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "usuario_logueado") ?? "Invitado";
            }
            catch
            {
                return "Invitado";
            }
        }

        public async Task<string> ObtenerTipoUsuario()
        {
            try
            {
                // Primero intentar obtener desde localStorage
                var tipoUsuario = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "tipo_usuario");
                if (!string.IsNullOrEmpty(tipoUsuario))
                    return tipoUsuario;

                // Si no está en localStorage, buscar en la API
                var emailUsuario = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "usuario_logueado");
                if (string.IsNullOrEmpty(emailUsuario))
                    return "User";

                using var httpClient = _httpClientFactory.CreateClient("ApiProyecto");
                var respuesta = await httpClient.GetFromJsonAsync<RespuestaApi<List<Usuario>>>("api/usuario");
                var usuarios = respuesta?.Datos ?? new List<Usuario>();

                var usuario = usuarios.FirstOrDefault(u =>
                    u.Email.Equals(emailUsuario, StringComparison.OrdinalIgnoreCase));

                var tipo = usuario?.TipoUsuario ?? "User";

                // Guardar en localStorage para próximas consultas
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "tipo_usuario", tipo);

                return tipo;
            }
            catch
            {
                return "User";
            }
        }

        public async Task<bool> EsAdministrador()
        {
            try
            {
                var tipoUsuario = await ObtenerTipoUsuario();
                return tipoUsuario.Equals("Admin", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EsTecnico()
        {
            try
            {
                var tipoUsuario = await ObtenerTipoUsuario();
                return tipoUsuario.Equals("Tecnico", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EsUsuarioRegular()
        {
            try
            {
                var tipoUsuario = await ObtenerTipoUsuario();
                return tipoUsuario.Equals("User", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return true; // Por defecto es usuario regular
            }
        }

        public async Task CerrarSesion()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "usuario_logueado");
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "usuario_id");
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "es_admin");
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "tipo_usuario");
            }
            catch
            {
                // Si falla, no es crítico
            }
        }
    }
}