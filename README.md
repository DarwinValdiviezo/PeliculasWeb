# Sistema de Alquiler de Películas - ASP .NET Core

Este proyecto es un sistema web desarrollado en ASP .NET Core para la gestión de un servicio de alquiler de películas. Ofrece una interfaz completa para la administración de películas, clientes y transacciones de alquiler.

## Estructura del Proyecto

- **Pelicula.cs:** Modelo que representa una película con atributos como Nombre, Precio y Descripción.
- **Usuario.cs:** Modelo que representa un usuario/cliente del sistema con detalles como Nombre, Apellido, Fecha de Inicio, Fecha Final, Teléfono, Dirección y Película Alquilada.
- **PeliculasController.cs:** Controlador para la gestión de películas.
- **UsuariosController.cs:** Controlador para la gestión de usuarios/clientes.

## Ejecución del Proyecto

1. Asegúrate de tener el entorno de desarrollo configurado para ASP .NET Core.
2. Clona el repositorio o descarga los archivos del proyecto.
3. Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio, Visual Studio Code, etc.).
4. Ejecuta la aplicación ASP .NET Core desde tu entorno de desarrollo.

## Funcionalidades Principales

- **Gestión de Películas:** Agregar, editar o eliminar películas de la base de datos.
- **Gestión de Clientes:** Ver y administrar la información de los usuarios/clientes registrados.
- **Registro de Transacciones:** Verificar transacciones y registros de alquiler de películas.

## Creación de la Base de Datos

Utiliza SQL Server Management Studio y ejecuta el siguiente script para crear la base de datos y tablas:

```sql
CREATE DATABASE peliculas

USE peliculas

CREATE TABLE Peliculas (
    Id_Pelicula int primary key,
    Nombre_Pelicula varchar(100),
    Precio decimal(10, 2),
    Descripcion varchar(255)
);

CREATE TABLE Usuarios (
    Id_Usuario int identity(1,1) PRIMARY KEY,
    Nombre varchar(50),
    Apellido varchar(50),
    Fecha_Inicio date,
    Fecha_Final date,
    Telefono varchar(10),
    Direccion varchar(100),
    Id_Pelicula int, -- Agregar columna para la película elegida
    FOREIGN KEY (Id_Pelicula) REFERENCES Peliculas(Id_Pelicula) -- Clave foránea hacia Peliculas
);

CREATE TABLE Pelicula_Usuario (
    Id_Pelicula int,
    Id_Usuario int,
    FOREIGN KEY (Id_Pelicula) REFERENCES Peliculas(Id_Pelicula),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario),
    PRIMARY KEY (Id_Pelicula, Id_Usuario)
);

INSERT INTO Peliculas (Id_Pelicula, Nombre_Pelicula, Precio, Descripcion)
VALUES (1, 'El Padrino', 15.99, 'Clásico del cine de mafia'),
       (2, 'Titanic', 12.50, 'Romance trágico en alta mar'),
       (3, 'El Señor de los Anillos', 19.99, 'Épica aventura fantástica'),
       (4, 'La La Land', 9.75, 'Musical romántico ambientado en Los Ángeles'),
       (5, 'El Rey León', 14.25, 'Historia animada sobre el ciclo de la vida'),
       (6, 'Inception', 17.50, 'Thriller de ciencia ficción sobre los sueños'),
       (7, 'Forrest Gump', 11.80, 'Viaje a través de la vida de Forrest'),
       (8, 'Avengers: Endgame', 22.99, 'Épica batalla de superhéroes'),
       (9, 'Matrix', 13.45, 'Mundo virtual y realidad alternativa'),
       (10, 'Harry Potter y la Piedra Filosofal', 18.25, 'Aventuras mágicas en Hogwarts');
```

## Paquetes de Entity Framework

Añade los paquetes Microsoft.EntityFrameworkCore.SqlServer y Microsoft.EntityFrameworkCore.Tools para trabajar con Entity Framework Core.

## Generar Modelos desde la Base de Datos

Ejecuta el comando Scaffold-DbContext en la terminal de tu proyecto para generar modelos basados en tu base de datos existente:

Scaffold-DbContext "server=DESKTOP-PQVEJI8\SQLEXPRESS; database=peliculas; integrated security=true; TrustServerCertificate=Yes" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

**Asegúrate de configurar la cadena de conexión en appsettings.json y en Program.cs para la base de datos.**

Este proyecto representa un sistema web completo para la gestión de un servicio de alquiler de películas, ofreciendo una plataforma completa para la administración de películas, usuarios y transacciones de alquiler.
