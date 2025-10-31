# 🔌 Guía de Integración con API

Esta guía documenta los endpoints esperados por el frontend y el formato de respuestas requerido.

---

## 📋 Tabla de Contenidos

- [Formato de Respuestas](#formato-de-respuestas)
- [Endpoints por Módulo](#endpoints-por-módulo)
- [Ejemplos de Implementación](#ejemplos-de-implementación)
- [Códigos de Estado HTTP](#códigos-de-estado-http)
- [Manejo de Errores](#manejo-de-errores)
- [CORS](#configuración-cors)

---

## 📦 Formato de Respuestas

El frontend espera que **todos los endpoints** devuelvan respuestas en el siguiente formato:

### Formato Base

```json
{
  "exito": true,
  "mensaje": "Mensaje descriptivo de la operación",
  "datos": [...]
}
```

### Respuesta Exitosa

```json
{
  "exito": true,
  "mensaje": "Operación exitosa",
  "datos": {
    "id": 1,
    "email": "usuario@ejemplo.com",
    "activo": true
  }
}
```

### Respuesta con Lista

```json
{
  "exito": true,
  "mensaje": "Registros obtenidos",
  "datos": [
    { "id": 1, "titulo": "Proyecto A" },
    { "id": 2, "titulo": "Proyecto B" }
  ]
}
```

### Respuesta de Error

```json
{
  "exito": false,
  "mensaje": "Error: Usuario no encontrado",
  "datos": null
}
```

### Clase C# para Mapear Respuestas

```csharp
public class RespuestaApi<T>
{
    [JsonPropertyName("exito")]
    public bool Exito { get; set; }

    [JsonPropertyName("mensaje")]
    public string Mensaje { get; set; } = string.Empty;

    [JsonPropertyName("datos")]
    public T? Datos { get; set; }
}
```

---

## 🎯 Endpoints por Módulo

### 👤 Usuarios

#### Listar Todos

```http
GET /api/usuario
```

**Respuesta:**

```json
{
  "exito": true,
  "mensaje": "Usuarios obtenidos",
  "datos": [
    {
      "id": 1,
      "email": "admin@sistema.com",
      "contrasena": "hashed_password",
      "rutaAvatar": "/avatars/admin.jpg",
      "activo": true
    }
  ]
}
```

#### Obtener por ID

```http
GET /api/usuario/id/{id}
```

**Respuesta:**

```json
{
  "exito": true,
  "mensaje": "Usuario encontrado",
  "datos": {
    "id": 1,
    "email": "admin@sistema.com",
    "activo": true
  }
}
```

#### Crear

```http
POST /api/usuario
Content-Type: application/json

{
  "email": "nuevo@ejemplo.com",
  "contrasena": "password123",
  "rutaAvatar": null,
  "activo": true
}
```

**Respuesta:**

```json
{
  "exito": true,
  "mensaje": "Usuario creado exitosamente",
  "datos": {
    "id": 5,
    "email": "nuevo@ejemplo.com",
    "activo": true
  }
}
```

#### Actualizar

```http
PUT /api/usuario/{id}
Content-Type: application/json

{
  "id": 5,
  "email": "actualizado@ejemplo.com",
  "contrasena": "newpass123",
  "activo": true
}
```

**Respuesta:**

```json
{
  "exito": true,
  "mensaje": "Usuario actualizado exitosamente",
  "datos": {
    "id": 5,
    "email": "actualizado@ejemplo.com"
  }
}
```

#### Eliminar

```http
DELETE /api/usuario/id/{id}
```

**Respuesta:**

```json
{
  "exito": true,
  "mensaje": "Usuario eliminado exitosamente",
  "datos": null
}
```

---

### 📁 Proyectos

#### Listar Todos

```http
GET /api/proyecto
```

**Respuesta:**

```json
{
  "exito": true,
  "mensaje": "Proyectos obtenidos",
  "datos": [
    {
      "id": 1,
      "idProyectoPadre": null,
      "idResponsable": 1,
      "idTipoProyecto": 2,
      "codigo": "PROY-001",
      "titulo": "Proyecto Alpha",
      "descripcion": "Descripción del proyecto",
      "fechaInicio": "2025-01-01T00:00:00",
      "fechaFinPrevista": "2025-12-31T00:00:00",
      "fechaModificacion": null,
      "fechaFinalizacion": null,
      "rutaLogo": "/logos/proyecto1.png"
    }
  ]
}
```

#### Obtener por ID

```http
GET /api/proyecto/id/{id}
```

#### Crear

```http
POST /api/proyecto
Content-Type: application/json

{
  "idProyectoPadre": null,
  "idResponsable": 1,
  "idTipoProyecto": 2,
  "codigo": "PROY-002",
  "titulo": "Nuevo Proyecto",
  "descripcion": "Descripción",
  "fechaInicio": "2025-01-15T00:00:00",
  "fechaFinPrevista": "2025-06-30T00:00:00"
}
```

#### Actualizar

```http
PUT /api/proyecto/{id}
Content-Type: application/json
```

#### Eliminar

```http
DELETE /api/proyecto/id/{id}
```

---

### ✅ Actividades

#### Estructura de Datos

```json
{
  "id": 1,
  "idEntregable": 5,
  "titulo": "Diseñar mockups",
  "descripcion": "Crear diseños de interfaz",
  "fechaInicio": "2025-01-10T00:00:00",
  "fechaFinPrevista": "2025-01-20T00:00:00",
  "fechaModificacion": null,
  "fechaFinalizacion": null,
  "prioridad": 5,
  "porcentajeAvance": 75
}
```

**Campos Especiales:**

- `prioridad`: Entero de 1 a 5 (1 = baja, 5 = muy alta)
- `porcentajeAvance`: Entero de 0 a 100

#### Endpoints

```http
GET    /api/actividad           # Listar
GET    /api/actividad/id/{id}   # Obtener
POST   /api/actividad           # Crear
PUT    /api/actividad/{id}      # Actualizar
DELETE /api/actividad/id/{id}   # Eliminar
```

---

### 💰 Presupuestos

#### Estructura de Datos

```json
{
  "id": 1,
  "idProyecto": 3,
  "montoSolicitado": 50000.0,
  "estado": "Aprobado",
  "montoAprobado": 45000.0,
  "periodoAnio": 2025,
  "fechaSolicitud": "2024-12-01T00:00:00",
  "fechaAprobacion": "2024-12-15T00:00:00",
  "observaciones": "Presupuesto reducido en 10%"
}
```

**Estados Válidos:**

- `"Pendiente"`
- `"En Revisión"`
- `"Aprobado"`
- `"Rechazado"`

#### Endpoints

```http
GET    /api/presupuesto           # Listar
GET    /api/presupuesto/id/{id}   # Obtener
POST   /api/presupuesto           # Crear
PUT    /api/presupuesto/{id}      # Actualizar
DELETE /api/presupuesto/id/{id}   # Eliminar
```

---

### 👥 Responsables

#### Estructura de Datos

```json
{
  "id": 1,
  "idTipoResponsable": 2,
  "idUsuario": 5,
  "nombre": "Juan Pérez"
}
```

**Nota:** Incluye dos Foreign Keys (TipoResponsable y Usuario)

#### Endpoints

```http
GET    /api/responsable           # Listar
GET    /api/responsable/id/{id}   # Obtener
POST   /api/responsable           # Crear
PUT    /api/responsable/{id}      # Actualizar
DELETE /api/responsable/id/{id}   # Eliminar
```

---

### 📊 Variables, Objetivos y Metas Estratégicas

#### Variable Estratégica

```http
GET    /api/variableEstrategica
GET    /api/variableEstrategica/id/{id}
POST   /api/variableEstrategica
PUT    /api/variableEstrategica/{id}
DELETE /api/variableEstrategica/id/{id}
```

**Estructura:**

```json
{
  "id": 1,
  "nombre": "Crecimiento de Ventas",
  "descripcion": "Variable que mide el crecimiento"
}
```

#### Objetivo Estratégico

```http
GET    /api/objetivoEstrategico
GET    /api/objetivoEstrategico/id/{id}
POST   /api/objetivoEstrategico
PUT    /api/objetivoEstrategico/{id}
DELETE /api/objetivoEstrategico/id/{id}
```

**Estructura:**

```json
{
  "id": 1,
  "idVariable": 1,
  "titulo": "Aumentar ventas en 20%",
  "descripcion": "Objetivo del año 2025"
}
```

#### Meta Estratégica

```http
GET    /api/metaEstrategica
GET    /api/metaEstrategica/id/{id}
POST   /api/metaEstrategica
PUT    /api/metaEstrategica/{id}
DELETE /api/metaEstrategica/id/{id}
```

**Estructura:**

```json
{
  "id": 1,
  "idObjetivo": 1,
  "descripcion": "Meta Q1 2025",
  "valorMeta": "1000000"
}
```

---

### 📋 Catálogos

Los catálogos siguen el mismo patrón:

```http
# Tipos de Responsable
GET    /api/tipoResponsable
POST   /api/tipoResponsable
PUT    /api/tipoResponsable/{id}
DELETE /api/tipoResponsable/id/{id}

# Tipos de Proyecto
GET    /api/tipoProyecto
POST   /api/tipoProyecto
PUT    /api/tipoProyecto/{id}
DELETE /api/tipoProyecto/id/{id}

# Tipos de Producto
GET    /api/tipoProducto
POST   /api/tipoProducto
PUT    /api/tipoProducto/{id}
DELETE /api/tipoProducto/id/{id}

# Estados
GET    /api/estado
POST   /api/estado
PUT    /api/estado/{id}
DELETE /api/estado/id/{id}
```

**Estructura Típica de Catálogo:**

```json
{
  "id": 1,
  "nombre": "Nombre del Tipo",
  "descripcion": "Descripción opcional"
}
```

---

## 💻 Ejemplos de Implementación

### Node.js + Express

```javascript
const express = require("express");
const app = express();

app.use(express.json());

// Listar usuarios
app.get("/api/usuario", async (req, res) => {
  try {
    const usuarios = await db.query("SELECT * FROM Usuario");

    res.json({
      exito: true,
      mensaje: "Usuarios obtenidos",
      datos: usuarios,
    });
  } catch (error) {
    res.status(500).json({
      exito: false,
      mensaje: `Error: ${error.message}`,
      datos: null,
    });
  }
});

// Obtener por ID
app.get("/api/usuario/id/:id", async (req, res) => {
  try {
    const usuario = await db.query("SELECT * FROM Usuario WHERE Id = ?", [
      req.params.id,
    ]);

    if (!usuario) {
      return res.status(404).json({
        exito: false,
        mensaje: "Usuario no encontrado",
        datos: null,
      });
    }

    res.json({
      exito: true,
      mensaje: "Usuario encontrado",
      datos: usuario,
    });
  } catch (error) {
    res.status(500).json({
      exito: false,
      mensaje: `Error: ${error.message}`,
      datos: null,
    });
  }
});

// Crear
app.post("/api/usuario", async (req, res) => {
  try {
    const { email, contrasena, rutaAvatar, activo } = req.body;

    const resultado = await db.query(
      "INSERT INTO Usuario (Email, Contrasena, RutaAvatar, Activo) VALUES (?, ?, ?, ?)",
      [email, contrasena, rutaAvatar, activo]
    );

    res.status(201).json({
      exito: true,
      mensaje: "Usuario creado exitosamente",
      datos: { id: resultado.insertId, email },
    });
  } catch (error) {
    res.status(500).json({
      exito: false,
      mensaje: `Error: ${error.message}`,
      datos: null,
    });
  }
});

// Actualizar
app.put("/api/usuario/:id", async (req, res) => {
  try {
    const { email, contrasena, activo } = req.body;

    await db.query(
      "UPDATE Usuario SET Email = ?, Contrasena = ?, Activo = ? WHERE Id = ?",
      [email, contrasena, activo, req.params.id]
    );

    res.json({
      exito: true,
      mensaje: "Usuario actualizado exitosamente",
      datos: { id: req.params.id, email },
    });
  } catch (error) {
    res.status(500).json({
      exito: false,
      mensaje: `Error: ${error.message}`,
      datos: null,
    });
  }
});

// Eliminar
app.delete("/api/usuario/id/:id", async (req, res) => {
  try {
    await db.query("DELETE FROM Usuario WHERE Id = ?", [req.params.id]);

    res.json({
      exito: true,
      mensaje: "Usuario eliminado exitosamente",
      datos: null,
    });
  } catch (error) {
    res.status(500).json({
      exito: false,
      mensaje: `Error: ${error.message}`,
      datos: null,
    });
  }
});

app.listen(3000, () => {
  console.log("API corriendo en http://localhost:3000");
});
```

### Python + Flask

```python
from flask import Flask, jsonify, request
from flask_cors import CORS

app = Flask(__name__)
CORS(app)

@app.route('/api/usuario', methods=['GET'])
def listar_usuarios():
    try:
        usuarios = db.query('SELECT * FROM Usuario')

        return jsonify({
            'exito': True,
            'mensaje': 'Usuarios obtenidos',
            'datos': usuarios
        })
    except Exception as e:
        return jsonify({
            'exito': False,
            'mensaje': f'Error: {str(e)}',
            'datos': None
        }), 500

@app.route('/api/usuario/id/<int:id>', methods=['GET'])
def obtener_usuario(id):
    try:
        usuario = db.query('SELECT * FROM Usuario WHERE Id = ?', (id,))

        if not usuario:
            return jsonify({
                'exito': False,
                'mensaje': 'Usuario no encontrado',
                'datos': None
            }), 404

        return jsonify({
            'exito': True,
            'mensaje': 'Usuario encontrado',
            'datos': usuario
        })
    except Exception as e:
        return jsonify({
            'exito': False,
            'mensaje': f'Error: {str(e)}',
            'datos': None
        }), 500

@app.route('/api/usuario', methods=['POST'])
def crear_usuario():
    try:
        data = request.get_json()

        resultado = db.execute(
            'INSERT INTO Usuario (Email, Contrasena, RutaAvatar, Activo) VALUES (?, ?, ?, ?)',
            (data['email'], data['contrasena'], data.get('rutaAvatar'), data.get('activo', True))
        )

        return jsonify({
            'exito': True,
            'mensaje': 'Usuario creado exitosamente',
            'datos': {'id': resultado.lastrowid, 'email': data['email']}
        }), 201
    except Exception as e:
        return jsonify({
            'exito': False,
            'mensaje': f'Error: {str(e)}',
            'datos': None
        }), 500

if __name__ == '__main__':
    app.run(port=3000, debug=True)
```

### ASP.NET Core Web API

```csharp
[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/usuario
    [HttpGet]
    public async Task<ActionResult<RespuestaApi<List<Usuario>>>> GetUsuarios()
    {
        try
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return Ok(new RespuestaApi<List<Usuario>>
            {
                Exito = true,
                Mensaje = "Usuarios obtenidos",
                Datos = usuarios
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespuestaApi<List<Usuario>>
            {
                Exito = false,
                Mensaje = $"Error: {ex.Message}",
                Datos = null
            });
        }
    }

    // GET: api/usuario/id/{id}
    [HttpGet("id/{id}")]
    public async Task<ActionResult<RespuestaApi<Usuario>>> GetUsuario(int id)
    {
        try
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new RespuestaApi<Usuario>
                {
                    Exito = false,
                    Mensaje = "Usuario no encontrado",
                    Datos = null
                });
            }

            return Ok(new RespuestaApi<Usuario>
            {
                Exito = true,
                Mensaje = "Usuario encontrado",
                Datos = usuario
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespuestaApi<Usuario>
            {
                Exito = false,
                Mensaje = $"Error: {ex.Message}",
                Datos = null
            });
        }
    }

    // POST: api/usuario
    [HttpPost]
    public async Task<ActionResult<RespuestaApi<Usuario>>> CreateUsuario(Usuario usuario)
    {
        try
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id },
                new RespuestaApi<Usuario>
                {
                    Exito = true,
                    Mensaje = "Usuario creado exitosamente",
                    Datos = usuario
                });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespuestaApi<Usuario>
            {
                Exito = false,
                Mensaje = $"Error: {ex.Message}",
                Datos = null
            });
        }
    }

    // PUT: api/usuario/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<RespuestaApi<Usuario>>> UpdateUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest(new RespuestaApi<Usuario>
            {
                Exito = false,
                Mensaje = "ID no coincide",
                Datos = null
            });
        }

        try
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new RespuestaApi<Usuario>
            {
                Exito = true,
                Mensaje = "Usuario actualizado exitosamente",
                Datos = usuario
            });
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Usuarios.Any(u => u.Id == id))
            {
                return NotFound(new RespuestaApi<Usuario>
                {
                    Exito = false,
                    Mensaje = "Usuario no encontrado",
                    Datos = null
                });
            }
            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespuestaApi<Usuario>
            {
                Exito = false,
                Mensaje = $"Error: {ex.Message}",
                Datos = null
            });
        }
    }

    // DELETE: api/usuario/id/{id}
    [HttpDelete("id/{id}")]
    public async Task<ActionResult<RespuestaApi<object>>> DeleteUsuario(int id)
    {
        try
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new RespuestaApi<object>
                {
                    Exito = false,
                    Mensaje = "Usuario no encontrado",
                    Datos = null
                });
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok(new RespuestaApi<object>
            {
                Exito = true,
                Mensaje = "Usuario eliminado exitosamente",
                Datos = null
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespuestaApi<object>
            {
                Exito = false,
                Mensaje = $"Error: {ex.Message}",
                Datos = null
            });
        }
    }
}
```

---

## 📊 Códigos de Estado HTTP

### Códigos Esperados

| Código  | Significado           | Cuándo Usar                          |
| ------- | --------------------- | ------------------------------------ |
| **200** | OK                    | Operación exitosa (GET, PUT, DELETE) |
| **201** | Created               | Recurso creado exitosamente (POST)   |
| **400** | Bad Request           | Datos de entrada inválidos           |
| **404** | Not Found             | Recurso no encontrado                |
| **500** | Internal Server Error | Error del servidor                   |

### Ejemplos de Uso

```javascript
// 200 OK - Listar/Obtener/Actualizar/Eliminar exitoso
res.status(200).json({ exito: true, mensaje: "OK", datos: [...] });

// 201 Created - Crear exitoso
res.status(201).json({ exito: true, mensaje: "Creado", datos: {...} });

// 404 Not Found - No encontrado
res.status(404).json({ exito: false, mensaje: "No encontrado", datos: null });

// 500 Internal Server Error - Error del servidor
res.status(500).json({ exito: false, mensaje: "Error interno", datos: null });
```

---

## ⚠️ Manejo de Errores

### Errores Comunes y Respuestas

#### Error de Validación

```json
{
  "exito": false,
  "mensaje": "Error de validación: Email requerido",
  "datos": null
}
```

#### Error de Base de Datos

```json
{
  "exito": false,
  "mensaje": "Error de base de datos: Violación de llave foránea",
  "datos": null
}
```

#### Error de Conexión

```json
{
  "exito": false,
  "mensaje": "Error: No se pudo conectar a la base de datos",
  "datos": null
}
```

#### Error de Autenticación

```json
{
  "exito": false,
  "mensaje": "Error: Credenciales inválidas",
  "datos": null
}
```

---

## 🌐 Configuración CORS

El frontend necesita que la API tenga CORS habilitado.

### Node.js + Express

```javascript
const cors = require("cors");

app.use(
  cors({
    origin: "http://localhost:5000",
    methods: ["GET", "POST", "PUT", "DELETE"],
    allowedHeaders: ["Content-Type", "Authorization"],
  })
);
```

### ASP.NET Core

```csharp
// Program.cs o Startup.cs
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Middleware
app.UseCors();
```

### Python + Flask

```python
from flask_cors import CORS

app = Flask(__name__)
CORS(app, resources={
    r"/api/*": {
        "origins": "http://localhost:5000",
        "methods": ["GET", "POST", "PUT", "DELETE"],
        "allow_headers": ["Content-Type"]
    }
})
```

---

## 🧪 Probar la API

### Usando cURL

```bash
# Listar usuarios
curl http://localhost:3000/api/usuario

# Obtener usuario por ID
curl http://localhost:3000/api/usuario/id/1

# Crear usuario
curl -X POST http://localhost:3000/api/usuario \
  -H "Content-Type: application/json" \
  -d '{"email":"test@ejemplo.com","contrasena":"123456","activo":true}'

# Actualizar usuario
curl -X PUT http://localhost:3000/api/usuario/1 \
  -H "Content-Type: application/json" \
  -d '{"id":1,"email":"updated@ejemplo.com","contrasena":"123456","activo":true}'

# Eliminar usuario
curl -X DELETE http://localhost:3000/api/usuario/id/1
```

### Usando Postman

1. **Importar Collection:**

   - Crear colección "Gestión de Proyectos API"
   - Agregar endpoints según documentación

2. **Variables de Entorno:**

   ```json
   {
     "base_url": "http://localhost:3000",
     "token": ""
   }
   ```

3. **Requests de Ejemplo:**
   ```
   GET  {{base_url}}/api/usuario
   GET  {{base_url}}/api/usuario/id/1
   POST {{base_url}}/api/usuario
   PUT  {{base_url}}/api/usuario/1
   DELETE {{base_url}}/api/usuario/id/1
   ```

---

## 📚 Resumen de Endpoints

### Todos los Módulos Implementados

```
Usuarios:           /api/usuario
Responsables:       /api/responsable
Tipos Responsable:  /api/tipoResponsable
Proyectos:          /api/proyecto
Tipos Proyecto:     /api/tipoProyecto
Estados:            /api/estado
Productos:          /api/producto
Tipos Producto:     /api/tipoProducto
Entregables:        /api/entregable
Actividades:        /api/actividad
Archivos:           /api/archivo
Presupuestos:       /api/presupuesto
Variables Estrat:   /api/variableEstrategica
Objetivos Estrat:   /api/objetivoEstrategico
Metas Estrat:       /api/metaEstrategica
```

**Patrón Común:**

```
GET    /api/{modelo}           # Listar todos
GET    /api/{modelo}/id/{id}   # Obtener por ID
POST   /api/{modelo}           # Crear
PUT    /api/{modelo}/{id}      # Actualizar
DELETE /api/{modelo}/id/{id}   # Eliminar
```

---

<div align="center">

**🔌 API diseñada para ser simple y consistente**

[🏠 Volver al README](../README.md) | [🏗️ Arquitectura](ARCHITECTURE.md)

</div>
