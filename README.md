#DIGIBOX - Practical Assesstment
## Acerca de:
Esta solución está desarrollada con Arquitectura limpia basada en Onion Architecture.
Esta desarrollada con .net 5 y cumple los estándares de WebApi Rest

## Características implementadas en el ejercicio:
- [x] Onion Architecture
- [x] CQRS y MediatR Library
- [x] Entity Framework Core - Code First
- [x] Repository Pattern - Generic
- [x] MediatR Pipeline Logging & Validation
- [x] Automapper
- [x] Serilog
- [x] Swagger UI
- [x] Response Wrappers
- [x] Custom Exception Handling Middlewares
- [x] In-Memory Database
- [x] Persistence SQL server Database
- [x] Database Seeding
- [x] Pagination
- [x] API Versioning
- [x] Fluent Validation

## Release
Pasos para utilizar el proyecto.
1. Clonar el repositorio de la siguiente liga: https://github.com/erickgonzalezs/Digibox-assessment.
2. Cambiar la cadena de conexión para CustomersDbContext in the Digibox.Api/appsettings.{env}.json
3. Ejecutar los siguientes comandos para restaurar el proyecto:
- dotnet restore
- dotnet run (o) abrir la solución en Vistual Studio.

### Migraciones y semillas para tablas y bases de datos.
El proyecto está configurado para usar MSSSQL y puede usar base de datos en memoria en caso de requerirse
Asegurarse de tener instalado "dotnet-ef" o ejecutar dotnet tool install --global dotnet-ef
1. Posicionarse en el folder: Infrastructure.Persistence y correr:
    - `dotnet ef migrations add Initial --startup-project ../Digibox.Api -c "CustomersDbContext"`
    - `dotnet ef database update --startup-project ../Digibox.Api -c "CustomersDbContext"`
2. Correr Digibox.Api en ambiente de desarrollo.


## Soporte para Docker
#### Dev Env.:
1. Ejecutar:
    - `docker-compose -f docker-compose.yml -f docker-compose.qas.override.yml up --remove-orphans --build -d`
#### Production Env.:
1. In the root folder run:
    - `docker-compose -f docker-compose.yml -f docker-compose.prd.override.yml up --remove-orphans --build -d`

## Swagger Documentación
#### Dev Env.:
http://localhost:5008/swagger/index.html


## Datos del desarrollador:
Erick González Sánchez

