# 🚀 Guía de Inicio Rápido

Esta guía te ayudará a poner en marcha el proyecto en menos de 10 minutos.

---

## ⚡ Inicio Rápido (5 minutos)

### 1️⃣ Requisitos Previos

Verifica que tengas instalado:

```bash
# Verificar .NET SDK
dotnet --version
# Debe ser 9.0.x o superior

# Verificar Git
git --version
```

Si no tienes .NET 9.0, descárgalo desde: https://dotnet.microsoft.com/download/dotnet/9.0

### 2️⃣ Clonar y Configurar

```bash
# Clonar el repositorio
git clone https://github.com/Olar03/FrontendApi.git
cd FrontendBlazorApi

# Restaurar dependencias
dotnet restore

# Compilar el proyecto
dotnet build
```

### 3️⃣ Configurar la API

Edita `Program.cs` línea ~20:

```csharp
builder.Services.AddHttpClient("ApiProyecto", client =>
{
    // ⚠️ CAMBIA ESTA URL POR LA DE TU API
    client.BaseAddress = new Uri("http://localhost:3000/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
```

### 4️⃣ Ejecutar la Aplicación

```bash
# Iniciar el servidor
dotnet run

# O con hot reload (recomendado para desarrollo)
dotnet watch
```

La aplicación estará disponible en: **http://localhost:5000**

### 5️⃣ Iniciar Sesión

Abre tu navegador en `http://localhost:5000` y usa estas credenciales:

**Usuario Admin:**

- Email: `admin@sistema.com`
- Contraseña: `admin123`

**Usuario Normal:**

- Selecciona cualquier usuario de la lista
- Contraseña: `123456`

---

## 🎯 Primeros Pasos Después del Login

### Dashboard

Al iniciar sesión, llegarás al **Dashboard** (`/dashboard`):

- Visualiza información general
- Accede a las diferentes secciones desde el menú

### Explorar el Sistema

#### 1. **Administración**

```
- Usuarios (/usuarios)
  → Gestiona los usuarios del sistema

- Tipos Responsable (/tipos-responsable)
  → Define tipos de responsabilidad

- Responsables (/responsables)
  → Asigna responsables a usuarios

- Estados (/estados)
  → Configura estados de proyectos

- Archivos (/archivos)
  → Gestiona archivos del sistema
```

#### 2. **Proyectos**

```
- Proyectos (/proyectos)
  → Crea y gestiona proyectos
  → Soporta jerarquías (padre/hijo)

- Actividades (/actividades)
  → Seguimiento de tareas
  → Progreso visual con barras

- Presupuestos (/presupuestos)
  → Control financiero
  → Estados y montos
```

#### 3. **Catálogos**

```
- Tipos Producto (/tipos-producto)
- Tipos Proyecto (/tipos-proyecto)
- Entregables (/entregables)
- Productos (/productos)
```

#### 4. **Estrategia**

```
- Variables Estratégicas (/variables-estrategicas)
- Objetivos Estratégicos (/objetivos-estrategicos)
- Metas Estratégicas (/metas-estrategicas)
```

---

## 📝 Operaciones CRUD Básicas

Todas las páginas siguen el mismo patrón:

### Crear un Registro

1. Llena el formulario en la parte superior
2. Click en el botón **"Crear [Entidad]"** (color azul)
3. Verás un mensaje de confirmación
4. El registro aparecerá en la tabla inferior

### Buscar un Registro

1. Ingresa el **ID** en el campo de búsqueda
2. Click en **"Buscar"** (ícono de lupa)
3. Los datos se cargarán en el formulario
4. Podrás editarlo o eliminarlo

### Actualizar un Registro

1. Busca el registro por ID o haz click en **"Cargar"** desde la tabla
2. Modifica los campos que necesites
3. Click en **"Actualizar"** (color amarillo)
4. Confirma el mensaje de éxito

### Eliminar un Registro

1. Busca el registro o cárgalo desde la tabla
2. Click en **"Eliminar"** (color rojo)
3. **¡Cuidado!** La eliminación es inmediata
4. El registro desaparecerá de la tabla

### Limpiar el Formulario

- Click en **"Limpiar"** para vaciar todos los campos
- Útil para empezar un nuevo registro desde cero

---

## 🎨 Ejemplos Prácticos

### Ejemplo 1: Crear Tu Primer Proyecto

1. **Ir a Proyectos** (`/proyectos`)

2. **Llenar el formulario:**

   ```
   Responsable: [Selecciona uno]
   Tipo Proyecto: [Selecciona uno]
   Código: PROY-001
   Título: Mi Primer Proyecto
   Descripción: Proyecto de prueba para familiarizarme con el sistema
   Fecha Inicio: [Hoy]
   Fecha Fin Prevista: [1 mes después]
   ```

3. **Click en "Crear Proyecto"**

4. **Verifica** que aparezca en la tabla inferior

### Ejemplo 2: Crear una Actividad con Progreso

1. **Ir a Actividades** (`/actividades`)

2. **Llenar el formulario:**

   ```
   Entregable: [Selecciona uno]
   Título: Diseñar mockups de UI
   Descripción: Crear mockups de las pantallas principales
   Prioridad: 5 (⭐⭐⭐⭐⭐)
   Porcentaje Avance: 50%
   Fecha Inicio: [Hoy]
   Fecha Fin Prevista: [1 semana después]
   ```

3. **Click en "Crear Actividad"**

4. **Observa** la barra de progreso en la tabla (50% verde)

### Ejemplo 3: Gestionar un Presupuesto

1. **Ir a Presupuestos** (`/presupuestos`)

2. **Llenar el formulario:**

   ```
   Proyecto: [Selecciona uno]
   Monto Solicitado: 50000.00
   Estado: Pendiente
   Periodo Año: 2025
   Fecha Solicitud: [Hoy]
   Observaciones: Presupuesto inicial del proyecto
   ```

3. **Click en "Crear Presupuesto"**

4. **Verifica** los indicadores en las tarjetas superiores

---

## 🔧 Configuración Avanzada (Opcional)

### Cambiar el Puerto

Edita `Properties/launchSettings.json`:

```json
{
  "profiles": {
    "http": {
      "applicationUrl": "http://localhost:8080"
    }
  }
}
```

### Habilitar HTTPS

1. Generar certificado de desarrollo:

   ```bash
   dotnet dev-certs https --trust
   ```

2. Agregar perfil HTTPS en `launchSettings.json`:
   ```json
   "https": {
     "applicationUrl": "https://localhost:5001;http://localhost:5000"
   }
   ```

### Cambiar Nivel de Logs

Edita `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug", // Information, Debug, Trace
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

---

## ❓ Problemas Comunes y Soluciones

### ❌ Error: "No se puede conectar a la API"

**Problema:** La aplicación no puede comunicarse con el backend.

**Soluciones:**

1. Verifica que la API esté corriendo
2. Verifica la URL en `Program.cs`
3. Verifica que no haya problemas de CORS
4. Revisa los logs de la API

```bash
# Ver logs detallados de la aplicación
dotnet run --verbosity detailed
```

### ❌ Error: "Compilación fallida"

**Problema:** El proyecto no compila.

**Solución:**

```bash
# Limpiar y reconstruir
dotnet clean
dotnet restore
dotnet build
```

### ❌ Error: "Puerto en uso"

**Problema:** El puerto 5000 ya está siendo usado.

**Solución:**

```bash
# Windows - Encontrar proceso
netstat -ano | findstr :5000

# Matar proceso (reemplaza <PID>)
taskkill /PID <PID> /F

# O cambiar el puerto en launchSettings.json
```

### ❌ No aparecen datos en las tablas

**Problema:** Las tablas están vacías.

**Soluciones:**

1. Verifica que la API tenga datos
2. Abre DevTools (F12) → Network → Verifica las peticiones
3. Verifica el formato de respuesta de la API
4. Debe coincidir con `RespuestaApi<T>`:
   ```json
   {
     "exito": true,
     "mensaje": "OK",
     "datos": [...]
   }
   ```

### ❌ Sesión se pierde al recargar

**Problema:** Se cierra sesión al refrescar la página.

**Soluciones:**

1. Verifica que JavaScript esté habilitado
2. Verifica que LocalStorage esté habilitado
3. Limpia el caché del navegador
4. Prueba en modo incógnito

---

## 🧪 Verificar Instalación

Ejecuta estos comandos para verificar que todo funciona:

```bash
# 1. Restaurar y compilar
dotnet restore
dotnet build

# 2. Ejecutar
dotnet run

# 3. Abrir en navegador
# http://localhost:5000

# 4. Verificar login
# Email: admin@sistema.com
# Password: admin123

# 5. Navegar a Dashboard
# Deberías ver: /dashboard

# 6. Probar una página CRUD
# Ir a /usuarios
# Intentar crear un usuario de prueba
```

Si todos estos pasos funcionan, **¡estás listo para empezar a desarrollar!** 🎉

---

## 📚 Próximos Pasos

Una vez que tengas el sistema funcionando:

1. **Lee la documentación completa:** [README.md](../README.md)
2. **Explora el código:** Empieza por `Program.cs` y `Components/Pages/`
3. **Revisa los modelos:** `Models/` para entender la estructura de datos
4. **Personaliza:** Cambia colores, logos, textos según tus necesidades
5. **Contribuye:** Lee [CONTRIBUTING.md](../CONTRIBUTING.md) para contribuir

---

## 🆘 Obtener Ayuda

Si tienes problemas:

1. **Revisa la documentación:** [README.md](../README.md)
2. **Busca en Issues:** [GitHub Issues](https://github.com/Olar03/FrontendApi/issues)
3. **Crea un Issue:** Si no encuentras solución
4. **Contacta al autor:** [@Olar03](https://github.com/Olar03)

---

## 🎯 Checklist de Verificación

Antes de comenzar a desarrollar, verifica:

- [ ] .NET 9.0 SDK instalado
- [ ] Proyecto clonado y restaurado
- [ ] URL de API configurada en `Program.cs`
- [ ] Aplicación compila sin errores
- [ ] Aplicación ejecuta correctamente
- [ ] Login funciona con credenciales de prueba
- [ ] Dashboard se muestra después del login
- [ ] Al menos una página CRUD probada
- [ ] Datos se cargan desde la API
- [ ] Operaciones CRUD funcionan correctamente

---

<div align="center">

**🚀 ¡Listo para empezar! Disfruta desarrollando con Blazor**

[🏠 Volver al README](../README.md) | [🤝 Contribuir](../CONTRIBUTING.md) | [📋 Changelog](../CHANGELOG.md)

</div>
