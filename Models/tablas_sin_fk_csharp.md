# Tablas sin claves foráneas y sus atributos (Tipo de dato C#)

---

## **Usuario**
| Atributo    | Tipo de Dato C#          |
|-------------|--------------------------|
| Id          | int                      |
| Email       | string                   |
| Contrasena  | string                   |
| RutaAvatar  | string?                  |
| Activo      | bool                     |

---

## **TipoResponsable**
| Atributo    | Tipo de Dato C#          |
|-------------|--------------------------|
| Id          | int                      |
| Titulo      | string                   |
| Descripcion | string                   |

---

## **TipoProyecto**
| Atributo    | Tipo de Dato C#          |
|-------------|--------------------------|
| Id          | int                      |
| Nombre      | string                   |
| Descripcion | string                   |

---

## **Estado**
| Atributo    | Tipo de Dato C#          |
|-------------|--------------------------|
| Id          | int                      |
| Nombre      | string                   |
| Descripcion | string                   |

---

## **TipoProducto**
| Atributo    | Tipo de Dato C#          |
|-------------|--------------------------|
| Id          | int                      |
| Nombre      | string                   |
| Descripcion | string                   |

---

## **Entregable**
| Atributo         | Tipo de Dato C#      |
|------------------|---------------------|
| Id               | int                 |
| Codigo           | string?             |
| Titulo           | string              |
| Descripcion      | string?             |
| FechaInicio      | DateTime?           |
| FechaFinPrevista | DateTime?           |
| FechaModificacion| DateTime?           |
| FechaFinalizacion| DateTime?           |

---

## **VariableEstrategica**
| Atributo    | Tipo de Dato C#          |
|-------------|--------------------------|
| Id          | int                      |
| Titulo      | string                   |
| Descripcion | string?                  |
