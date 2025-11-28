using Microsoft.JSInterop;

namespace FrontendBlazorApi.Servicios;

/// <summary>
/// Servicio simplificado de autenticación compatible con código legacy.
/// Wrapper sobre sessionStorage para mantener compatibilidad.
/// </summary>
public class AuthService
{
    private readonly IJSRuntime _js;

    public AuthService(IJSRuntime js)
    {
        _js = js;
    }

    /// <summary>
    /// Verifica si el usuario está autenticado.
    /// </summary>
    public async Task<bool> EstáAutenticado()
    {
        try
        {
            var email = await _js.InvokeAsync<string>("sessionStorage.getItem", "email");
            return !string.IsNullOrWhiteSpace(email);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Obtiene el nombre del usuario actual.
    /// </summary>
    public async Task<string> ObtenerUsuarioActual()
    {
        try
        {
            var email = await _js.InvokeAsync<string>("sessionStorage.getItem", "email");
            return email ?? "Invitado";
        }
        catch
        {
            return "Invitado";
        }
    }

    /// <summary>
    /// Obtiene el tipo de usuario.
    /// </summary>
    public async Task<string> ObtenerTipoUsuario()
    {
        try
        {
            var tipo = await _js.InvokeAsync<string>("sessionStorage.getItem", "tipo_usuario");
            return tipo ?? "User";
        }
        catch
        {
            return "User";
        }
    }

    /// <summary>
    /// Verifica si el usuario es administrador.
    /// </summary>
    public async Task<bool> EsAdministrador()
    {
        try
        {
            var esAdmin = await _js.InvokeAsync<string>("sessionStorage.getItem", "es_admin");
            return esAdmin?.ToLower() == "true";
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica si el usuario es técnico.
    /// </summary>
    public async Task<bool> EsTecnico()
    {
        try
        {
            var tipo = await ObtenerTipoUsuario();
            return tipo.Equals("Tecnico", StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica si el usuario es regular.
    /// </summary>
    public async Task<bool> EsUsuarioRegular()
    {
        try
        {
            var tipo = await ObtenerTipoUsuario();
            return tipo.Equals("User", StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Cierra la sesión del usuario.
    /// </summary>
    public async Task CerrarSesion()
    {
        try
        {
            await _js.InvokeVoidAsync("sessionStorage.clear");
        }
        catch
        {
            // Ignorar errores al cerrar sesión
        }
    }
}
