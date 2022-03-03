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

### Estructura del proyecto (clean architecture):
![App01](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/CleanArch01.png)
#### Capa de Applicación:
![App02](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/AppLayer.png)
#### Capa de Dominio:
![App03](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/DomainLayer.png)
#### Capa de Infraestructura (Customer):
![App04](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/InfrastructureLayer.png)
#### Capa de Infraestructura (Persistence):
![App05](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/PersistenceLayer.png)
#### Api:
![App06](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/Api01.png)
### Proyecto Test: 
![Pruebas de integración IMG](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/TestLayer.png)
#### Evidencias de pruebas de integración: 
![App07](https://raw.githubusercontent.com/erickgonzalezs/Digibox-assessment/main/Images/IntegrationTest.png)



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


### Soporte para Docker
#### QAS env:
##### En el archivo docker-compose se encuentra todo lo necesario para levantar el container de la api y la BD de SQL para las correspondientes pruebas.
1. Ejecutar:
    - `docker-compose -f docker-compose.qas.yml up --remove-orphans --build -d`

### Swagger Documentación
http://localhost:5010/swagger/index.html

Nota importante: Todos los endpoint deberán recibir la versión "1" como parámetro. 

### Datos del desarrollador a evaluar:
#### Nombre: Erick González Sánchez
#### Arquitecto de Desarrollo.
