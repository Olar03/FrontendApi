# 🏗️ Arquitectura del Sistema

Esta documentación describe la arquitectura técnica del **Sistema de Gestión de Proyectos** desarrollado con Blazor Server.

---

## 📋 Tabla de Contenidos

- [Visión General](#visión-general)
- [Arquitectura de Capas](#arquitectura-de-capas)
- [Patrones de Diseño](#patrones-de-diseño)
- [Componentes Principales](#componentes-principales)
- [Flujo de Datos](#flujo-de-datos)
- [Gestión de Estado](#gestión-de-estado)
- [Comunicación con API](#comunicación-con-api)
- [Renderizado](#renderizado)
- [Seguridad](#seguridad)

---

## 🎯 Visión General

### Tipo de Aplicación

**Blazor Server** - Aplicación web con renderizado en el servidor y comunicación en tiempo real mediante SignalR.

### Características Arquitectónicas

```
┌─────────────────────────────────────────────────────────┐
│                    NAVEGADOR (Cliente)                   │
│  ┌───────────────────────────────────────────────────┐  │
│  │            HTML + CSS + JavaScript                │  │
│  │      (Interfaz de Usuario Renderizada)            │  │
│  └───────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────┘
                         ↕ SignalR
┌─────────────────────────────────────────────────────────┐
│              SERVIDOR BLAZOR (.NET 9.0)                  │
│  ┌───────────────────────────────────────────────────┐  │
│  │           Blazor Server Runtime                   │  │
│  │  ┌─────────────────────────────────────────────┐ │  │
│  │  │   Components (Razor)                        │ │  │
│  │  │   - Pages (Login, Dashboard, CRUD)          │ │  │
│  │  │   - Layouts (MainLayout, EmptyLayout)       │ │  │
│  │  └─────────────────────────────────────────────┘ │  │
│  │  ┌─────────────────────────────────────────────┐ │  │
│  │  │   Services                                   │ │  │
│  │  │   - AuthService (Autenticación)             │ │  │
│  │  │   - HttpClientFactory (API)                 │ │  │
│  │  └─────────────────────────────────────────────┘ │  │
│  │  ┌─────────────────────────────────────────────┐ │  │
│  │  │   Models                                     │ │  │
│  │  │   - Entidades de dominio                    │ │  │
│  │  │   - DTOs (RespuestaApi<T>)                  │ │  │
│  │  └─────────────────────────────────────────────┘ │  │
│  └───────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────┘
                         ↕ HTTP/HTTPS
┌─────────────────────────────────────────────────────────┐
│                    API REST BACKEND                      │
│                  (Base de Datos)                         │
└─────────────────────────────────────────────────────────┘
```

---

## 🏛️ Arquitectura de Capas

### 1. **Capa de Presentación** (Components/)

#### Pages (Razor Pages)

Páginas interactivas que representan vistas completas.

```
Components/Pages/
├── Login.razor              # Autenticación (Layout: Empty)
├── Home.razor               # Dashboard (Layout: Main)
├── Usuarios.razor           # CRUD de usuarios
├── Proyectos.razor          # CRUD de proyectos
├── Actividades.razor        # CRUD de actividades
└── [17 páginas CRUD más]
```

**Responsabilidades:**

- Renderizar UI
- Capturar eventos de usuario
- Invocar servicios
- Mostrar feedback visual

#### Layouts

Estructuras reutilizables que envuelven las páginas.

```
Components/Layout/
├── MainLayout.razor         # Layout con navegación
├── EmptyLayout.razor        # Layout sin navegación
└── NavMenu.razor            # Menú de navegación
```

**Características:**

- `MainLayout`: Header + NavMenu + Body + Footer
- `EmptyLayout`: Solo Body (usado en Login)
- `NavMenu`: Menú desplegable organizado por categorías

### 2. **Capa de Lógica de Negocio** (Services/)

#### AuthService

Gestión de autenticación y sesión.

```csharp
Services/AuthService.cs
├── IniciarSesion(email, password)
├── CerrarSesion()
├── EstáAutenticado()
├── ObtenerUsuarioActual()
└── EsAdministrador()
```

**Responsabilidades:**

- Validar credenciales con API
- Guardar/recuperar sesión en LocalStorage
- Verificar estado de autenticación
- Gestionar roles de usuario

#### HttpClientFactory

Cliente HTTP configurado para comunicación con API.

```csharp
Program.cs
builder.Services.AddHttpClient("ApiProyecto", client => {
    client.BaseAddress = new Uri("https://api.backend.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
```

**Características:**

- Cliente nombrado reutilizable
- Configuración centralizada
- Timeout configurable
- Headers por defecto

### 3. **Capa de Datos** (Models/)

#### Modelos de Dominio

Representan entidades del negocio.

```
Models/
├── Usuario.cs
├── Proyecto.cs
├── Actividad.cs
├── Presupuesto.cs
└── [21 modelos más]
```

**Características:**

- Propiedades con Data Annotations
- Atributos JsonPropertyName
- Validaciones integradas
- Foreign Keys explícitas

#### DTOs (Data Transfer Objects)

```csharp
Models/RespuestaApi.cs
public class RespuestaApi<T>
{
    public bool Exito { get; set; }
    public string Mensaje { get; set; }
    public T? Datos { get; set; }
}
```

**Uso:**

- Envolver respuestas de API
- Tipado fuerte
- Manejo consistente de errores

---

## 🎨 Patrones de Diseño

### 1. **Component Pattern**

Blazor usa componentes reutilizables.

```razor
@* Componente Page *@
@page "/usuarios"
@rendermode InteractiveServer

<div class="container">
    <Formulario />
    <Tabla />
</div>

@code {
    // Lógica del componente
}
```

### 2. **Service Locator Pattern**

Inyección de dependencias con `@inject`.

```razor
@inject HttpClient Http
@inject AuthService Auth
@inject NavigationManager Nav
@inject IJSRuntime JS
```

### 3. **Repository Pattern** (API Side)

Acceso a datos abstracto mediante API REST.

```csharp
// Patrón usado en las páginas
private async Task<List<Usuario>> ObtenerUsuarios()
{
    var response = await httpClient.GetFromJsonAsync<RespuestaApi<List<Usuario>>>(
        "api/usuario"
    );
    return response?.Datos ?? new List<Usuario>();
}
```

### 4. **DTO Pattern**

Transferencia de datos con objetos específicos.

```csharp
// Request
var usuario = new Usuario { Email = "...", Contrasena = "..." };

// Response
RespuestaApi<Usuario> response = await Post(...);
if (response.Exito) { ... }
```

### 5. **MVVM Simplificado**

Separación de vista y lógica.

```razor
@* Vista (HTML) *@
<button @onclick="Crear">Crear</button>

@code {
    // ViewModel (Lógica)
    private Usuario usuario = new();

    private async Task Crear()
    {
        // Lógica de negocio
    }
}
```

---

## 🔧 Componentes Principales

### 1. **Program.cs** (Punto de Entrada)

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("ApiProyecto", ...);
builder.Services.AddScoped<AuthService>();

// Construir aplicación
var app = builder.Build();

// Configurar pipeline HTTP
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

**Responsabilidades:**

- Configurar servicios (DI Container)
- Configurar middleware pipeline
- Configurar rutas
- Iniciar aplicación

### 2. **App.razor** (Componente Raíz)

```razor
<Router AppAssembly="typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)" />
    </Found>
    <NotFound>
        <PageTitle>404 - No Encontrado</PageTitle>
        <p>Página no encontrada.</p>
    </NotFound>
</Router>
```

**Responsabilidades:**

- Enrutamiento de la aplicación
- Aplicar layouts por defecto
- Manejo de rutas no encontradas

### 3. **Routes.razor** (Configuración de Rutas)

```razor
<Router AppAssembly="typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="routeData" />
        <FocusOnNavigate RouteData="routeData" Selector="h1" />
    </Found>
</Router>
```

### 4. **\_Imports.razor** (Importaciones Globales)

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.JSInterop
@using FrontendBlazorApi
@using FrontendBlazorApi.Components
@using FrontendBlazorApi.Models
```

**Beneficio:** Imports disponibles en todos los componentes.

---

## 📊 Flujo de Datos

### Flujo Completo: Login → API → Dashboard

```
┌──────────────┐
│   Usuario    │ 1. Ingresa credenciales
└──────┬───────┘
       ↓
┌──────────────────┐
│   Login.razor    │ 2. Captura evento @onclick
└──────┬───────────┘
       ↓
┌──────────────────┐
│   AuthService    │ 3. Valida con API
└──────┬───────────┘
       ↓
┌──────────────────┐
│   HttpClient     │ 4. POST /api/usuario/login
└──────┬───────────┘
       ↓
┌──────────────────┐
│   API Backend    │ 5. Valida y responde
└──────┬───────────┘
       ↓
┌──────────────────┐
│  RespuestaApi<T> │ 6. Deserializa respuesta
└──────┬───────────┘
       ↓
┌──────────────────┐
│   AuthService    │ 7. Guarda en LocalStorage
└──────┬───────────┘
       ↓
┌──────────────────┐
│ NavigationManager│ 8. Navega a /dashboard
└──────┬───────────┘
       ↓
┌──────────────────┐
│   Home.razor     │ 9. Renderiza dashboard
└──────────────────┘
```

### Flujo CRUD: Crear Proyecto

```
┌─────────────────┐
│ Proyectos.razor │ 1. Formulario lleno
└────────┬────────┘
         ↓
    @onclick="Crear"
         ↓
┌─────────────────────────────────────┐
│ async Task Crear()                  │
│ {                                   │
│   var response = await httpClient   │
│     .PostAsJsonAsync(               │
│       "api/proyecto",               │
│       proyecto                      │
│     );                              │
│                                     │
│   if (response.IsSuccessStatusCode) │
│   {                                 │
│     mensaje = "Éxito";              │
│     await CargarProyectos();        │
│     LimpiarFormulario();            │
│   }                                 │
│ }                                   │
└─────────────────────────────────────┘
         ↓
┌─────────────────┐
│   API Backend   │ POST /api/proyecto
└────────┬────────┘
         ↓
    Respuesta JSON
         ↓
┌─────────────────┐
│ RespuestaApi<T> │ Deserialización
└────────┬────────┘
         ↓
┌─────────────────┐
│ StateHasChanged │ Re-renderizado
└─────────────────┘
```

---

## 🔄 Gestión de Estado

### Estado Local de Componente

```csharp
@code {
    // Estado local del componente
    private Usuario usuario = new();
    private List<Usuario> usuarios = new();
    private string mensaje = "";
    private bool esExito = false;

    // El estado se mantiene mientras el componente existe
    // Se pierde al navegar a otra página
}
```

### Estado de Sesión (LocalStorage)

```csharp
// AuthService
public async Task IniciarSesion(string email, string password)
{
    // Validar con API...

    // Guardar en LocalStorage (persiste entre recargas)
    await jsRuntime.InvokeVoidAsync("localStorage.setItem",
        "usuario_logueado", nombreUsuario);
    await jsRuntime.InvokeVoidAsync("localStorage.setItem",
        "usuario_id", usuarioId);
}

public async Task<bool> EstáAutenticado()
{
    // Leer de LocalStorage
    var usuario = await jsRuntime.InvokeAsync<string>(
        "localStorage.getItem", "usuario_logueado");

    return !string.IsNullOrEmpty(usuario);
}
```

### Ciclo de Vida de Estado

```
Navegación entre páginas:
  Estado local → ❌ Se pierde
  LocalStorage → ✅ Persiste

Recarga de página (F5):
  Estado local → ❌ Se pierde
  LocalStorage → ✅ Persiste

Cerrar navegador:
  Estado local → ❌ Se pierde
  LocalStorage → ✅ Persiste (hasta limpieza manual)
```

---

## 🌐 Comunicación con API

### Configuración Base

```csharp
// Program.cs
builder.Services.AddHttpClient("ApiProyecto", client =>
{
    client.BaseAddress = new Uri("https://api.backend.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.Timeout = TimeSpan.FromSeconds(30);
});
```

### Operaciones HTTP

#### GET - Listar

```csharp
private async Task CargarUsuarios()
{
    var response = await httpClient.GetFromJsonAsync<RespuestaApi<List<Usuario>>>(
        "api/usuario"
    );

    if (response?.Exito == true && response.Datos != null)
    {
        usuarios = response.Datos;
    }
}
```

#### GET - Por ID

```csharp
private async Task Buscar()
{
    var response = await httpClient.GetFromJsonAsync<RespuestaApi<Usuario>>(
        $"api/usuario/id/{usuario.Id}"
    );

    if (response?.Exito == true && response.Datos != null)
    {
        usuario = response.Datos;
    }
}
```

#### POST - Crear

```csharp
private async Task Crear()
{
    var response = await httpClient.PostAsJsonAsync("api/usuario", usuario);

    if (response.IsSuccessStatusCode)
    {
        var resultado = await response.Content.ReadFromJsonAsync<RespuestaApi<Usuario>>();

        if (resultado?.Exito == true)
        {
            mensaje = "Usuario creado exitosamente";
            await CargarUsuarios();
        }
    }
}
```

#### PUT - Actualizar

```csharp
private async Task Actualizar()
{
    var response = await httpClient.PutAsJsonAsync(
        $"api/usuario/{usuario.Id}",
        usuario
    );

    if (response.IsSuccessStatusCode)
    {
        mensaje = "Usuario actualizado exitosamente";
        await CargarUsuarios();
    }
}
```

#### DELETE - Eliminar

```csharp
private async Task Eliminar()
{
    var response = await httpClient.DeleteAsync($"api/usuario/id/{usuario.Id}");

    if (response.IsSuccessStatusCode)
    {
        mensaje = "Usuario eliminado exitosamente";
        await CargarUsuarios();
        LimpiarFormulario();
    }
}
```

### Manejo de Errores

```csharp
try
{
    var response = await httpClient.PostAsJsonAsync("api/usuario", usuario);

    if (response.IsSuccessStatusCode)
    {
        // Éxito
    }
    else
    {
        mensaje = $"Error: {response.StatusCode}";
        esExito = false;
    }
}
catch (HttpRequestException ex)
{
    mensaje = $"Error de conexión: {ex.Message}";
    esExito = false;
}
catch (Exception ex)
{
    mensaje = $"Error inesperado: {ex.Message}";
    esExito = false;
}
```

---

## 🎭 Renderizado

### Modos de Renderizado

#### Interactive Server (Usado en el Proyecto)

```razor
@rendermode InteractiveServer
```

**Características:**

- ✅ Renderizado en servidor
- ✅ Actualizaciones en tiempo real (SignalR)
- ✅ Estado mantenido en servidor
- ✅ Menor tamaño de descarga inicial
- ❌ Requiere conexión constante
- ❌ Latencia en interacciones

### Ciclo de Vida de Componente

```csharp
@code {
    // 1. Constructor
    public Proyectos() { }

    // 2. SetParametersAsync
    // Parámetros establecidos

    // 3. OnInitialized / OnInitializedAsync
    protected override async Task OnInitializedAsync()
    {
        await CargarProyectos();
    }

    // 4. OnParametersSet / OnParametersSetAsync
    // Después de establecer parámetros

    // 5. OnAfterRender / OnAfterRenderAsync
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Inicializar JS
            await jsRuntime.InvokeVoidAsync("initializeComponents");
        }
    }

    // 6. Dispose (si implementa IDisposable)
    public void Dispose()
    {
        // Limpiar recursos
    }
}
```

### StateHasChanged

```csharp
// Forzar re-renderizado manual
private async Task ActualizarDatos()
{
    await CargarProyectos();
    StateHasChanged(); // Re-renderiza el componente
}
```

---

## 🔒 Seguridad

### Autenticación

```csharp
// AuthService.cs
public async Task<bool> IniciarSesion(string email, string password)
{
    // 1. Validar formato de email
    if (!EsEmailValido(email))
        return false;

    // 2. Llamar a API para validar
    var response = await httpClient.PostAsJsonAsync("api/usuario/login", new {
        Email = email,
        Contrasena = password
    });

    // 3. Guardar sesión si válido
    if (response.IsSuccessStatusCode)
    {
        await GuardarSesion(email, userId);
        return true;
    }

    return false;
}
```

### Protección de Rutas (Futuro)

```razor
@* Patrón sugerido para futuro *@
@if (await Auth.EstáAutenticado())
{
    <Dashboard />
}
else
{
    <RedirectToLogin />
}
```

### Validación de Entrada

```csharp
[Required(ErrorMessage = "El email es requerido")]
[EmailAddress(ErrorMessage = "Email inválido")]
public string Email { get; set; }

[Required]
[StringLength(255, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 255 caracteres")]
public string Contrasena { get; set; }
```

### CORS (Configuración en API)

```csharp
// API Backend debe tener configurado CORS
app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:5000")
          .AllowAnyHeader()
          .AllowAnyMethod();
});
```

---

## 📈 Escalabilidad y Rendimiento

### Optimizaciones Implementadas

1. **HttpClientFactory**: Reutilización de conexiones HTTP
2. **Lazy Loading**: Datos se cargan solo cuando se necesitan
3. **Tipado Fuerte**: Menor margen de error, mejor rendimiento
4. **Estado Local**: Minimiza llamadas a API innecesarias

### Consideraciones para Producción

```csharp
// 1. Habilitar compresión de respuesta
app.UseResponseCompression();

// 2. Cacheo de recursos estáticos
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
            "Cache-Control", "public,max-age=31536000"
        );
    }
});

// 3. Configurar SignalR
builder.Services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize = 102400; // 100 KB
});
```

---

## 📚 Referencias

- [Blazor Architecture](https://docs.microsoft.com/aspnet/core/blazor/hosting-models)
- [ASP.NET Core Fundamentals](https://docs.microsoft.com/aspnet/core/fundamentals/)
- [Dependency Injection](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)
- [HttpClientFactory](https://docs.microsoft.com/aspnet/core/fundamentals/http-requests)

---

<div align="center">

**🏗️ Arquitectura diseñada para ser escalable y mantenible**

[🏠 Volver al README](../README.md) | [🚀 Inicio Rápido](GETTING_STARTED.md)

</div>
