# 🧩 Kaits API — Backend (.NET 8, EF Core, SQL Server)

API REST para gestionar **Clientes, Productos, Pedidos y Detalles de Pedido**.  
Implementa arquitectura en capas, EF Core con configuraciones por entidad, DI con Autofac, logging con Serilog y documentación Swagger.

---

## 🏗️ Arquitectura del proyecto

```bash
kaits-api/
├── Kaits.Api/ # Capa de presentación (Web API)
│ ├── Controllers/ # Endpoints (Cliente, Producto, Pedido, DetallePedido)
│ ├── Exceptions/ # Excepciones de API
│ ├── Middlewares/ # Middlewares (manejo de errores, etc.)
│ ├── Program.cs # Punto de entrada: DI, CORS, Swagger, Serilog
│ ├── appsettings.json # Configuración (incluye ConnectionStrings)
│ └── appsettings.Development.json
├── Kaits.Application/ # Lógica de negocio, DTOs, servicios
│ ├── Cores/ # Infra común de aplicación
│ ├── Dtos/ # DTOs (Productos, Pedidos, etc.)
│ └── Services/ # Implementaciones de servicios
├── Kaits.Domain/ # Dominio (Entidades y Contratos)
│ ├── Cores/ # Clases genéricas
│ ├── Models/ # Entidades: Cliente, Producto, Pedido, DetallePedido
│ └── Repositories/ # Interfaces de repositorios
├── Kaits.Infrastructure/ # Acceso a datos (EF Core + Dapper)
│ ├── Configurations/ # Mapeos Fluent API por entidad
│ ├── Cores/ # DbContext y registro de infraestructura
│ └── Persistences/ # (si aplica: consultas Dapper, scripts, etc.)
└── Kaits.UnitTest/ # Pruebas unitarias
```
---

## 📦 Dependencias (NuGet) por proyecto

### `Kaits.Api`
- `Microsoft.AspNetCore.OpenApi` **7.0.13**
- `Microsoft.EntityFrameworkCore.Design` **7.0.14**
- `Newtonsoft.Json` **13.0.3**
- `Serilog.AspNetCore` **7.0.0**
- `Swashbuckle.AspNetCore` **6.4.0**

### `Kaits.Application`
- `Autofac.Extensions.DependencyInjection` **8.0.0**
- `AutoMapper` **12.0.1**
- `AutoMapper.Extensions.Microsoft.DependencyInjection` **12.0.1**
- `FluentValidation.AspNetCore` **11.3.0**

### `Kaits.Infrastructure`
- `Autofac.Extensions.DependencyInjection` **8.0.0**
- `Dapper` **2.1.21**
- `Microsoft.EntityFrameworkCore` **7.0.11**
- `Microsoft.EntityFrameworkCore.SqlServer` **7.0.11**

### `Kaits.UnitTest`
- `AutoFixture` **4.18.0**
- `coverlet.collector` **6.0.0**
- `Microsoft.NET.Test.Sdk` **17.8.0**
- `Moq` **4.20.69**
- `xunit` **2.5.3**
- `xunit.runner.visualstudio` **2.5.3**

> 💡 El proyecto usa **Autofac** para DI, **Serilog** para logging (a consola y a archivo) y **Swagger** para documentación.  
> En `Program.cs` se configura CORS abierto (AllowAnyOrigin/Method/Header) y el log a archivo `../logapikaits.log`.

---

## 🗄️ Base de datos

- Motor: **SQL Server**
- Acceso: **EF Core** (DbContext + Configurations por entidad)
- Mapeos: en `Kaits.Infrastructure/Configurations/*Configuration.cs`

### 📚 Estructura y datos iniciales

El proyecto incluye tres scripts SQL en la raíz o dentro de la carpeta `/scripts`:

```bash
Scripts/
├── Kaits.sql             # Script DDL: crea la base de datos y todas las tablas
├── seed_clientes.sql     # Script DML: inserta registros de clientes iniciales
└── seed_productos.sql    # Script DML: inserta productos de ejemplo
```


---

## ⚙️ Configuración de la cadena de conexión

1. Abre `Kaits.Api/appsettings.json`.
2. En la sección `ConnectionStrings`, define la cadena de conexión:

```json
{
  "ConnectionStrings": {
    "DbConnection": "Server=localhost;Database=Kaits;User Id=sa;Password=TuPasswordSegura123;TrustServerCertificate=true"
  }
}
```
---
## 🚀 Ejecución
Requisitos previos

- NET SDK 8.0+
- SQL Server (local o remoto)

---
## Levantar la API
Requisitos previos

1. Restaurar paquetes

```bash
dotnet restore
```

2. Ejecutar la API

```bash
dotnet run --project Kaits.Api
```
---
## ✅ Pruebas
```bash
dotnet test
```
Las pruebas unitarias están en Kaits.UnitTest/ e incluyen xUnit, Moq y AutoFixture.

---
## 📝 Estándares y buenas prácticas
- Arquitectura por capas (Api / Application / Domain / Infrastructure)
- DTOs + AutoMapper para separar dominio de transporte
- Logging centralizado con Serilog (consola + archivo ../logapikaits.log)
- CORS configurado en Program.cs (ajustar para producción)
- Documentación de endpoints con Swagger

---

## 👤 Autor
David Vera

Software Developer — .NET | SQL Server | React
