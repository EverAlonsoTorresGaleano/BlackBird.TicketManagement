# Projecto BlackBird.TicketManagement

## Pasos para ejecución del Projecto BlackBird.TicketManagement

### Instalación de herramientas necesarias
	. Instalar .NET 8.0 SDK
   - Descargar e instalar desde: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
	
	. Instalar SQL Server 2019 o superior
- Descargar e instalar desde: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- Asegurarse de instalar SQL Server Management Studio (SSMS) para facilitar la gestión de bases de datos.
- Configurar una instancia de SQL Server y crear una base de datos para el proyecto.
- Configurar la autenticación SQL Server (modo mixto) y crear un usuario con permisos adecuados para la base de datos del proyecto.
- Anotar el nombre del servidor, el nombre de la base de datos, el usuario y la contraseña para su uso en la cadena de conexión.
- Asegurarse de que el servicio de SQL Server esté en ejecución.
- Configurar el firewall para permitir conexiones al puerto de SQL Server (por defecto, 1433) si es necesario.

### Clonar el repositorio
	. Clonar el repositorio del proyecto desde GitHub u otra plataforma de control de versiones.
   	- Usar el comando: git clone <URL_DEL_REPOSITORIO>


### Configurar la cadena de conexión	
	. Abrir el archivo appsettings.json en el proyecto.	
	. Localizar la sección "ConnectionStrings".
	. Modificar la cadena de conexión "AzureSQLServer" con los detalles de la base de datos configurada anteriormente.
		- Ejemplo:
		```json
		"ConnectionStrings": {
			"AzureSQLServer": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
		}
		```

### Restaurar paquetes NuGet
	. Abrir una terminal o línea de comandos en el directorio del proyecto.
	. Ejecutar el comando: dotnet restore

### Construir el proyecto
	. En la terminal, ejecutar el comando: dotnet build

### Base de Datos Opcion 1: Ejecutar migraciones de la base de datos
	. En la terminal, ejecutar el comando: dotnet ef database update
- Asegurarse de tener instalado el paquete de herramientas de Entity Framework Core.
- Si no está instalado, ejecutar: dotnet tool install --global dotnet-ef

### Base de Datos Opcion 2: Ejecutar script SQL
	. Abrir SQL Server Management Studio (SSMS) y conectarse a la instancia de SQL Server.
	. Crear una nueva consulta y copiar el contenido del archivo ScriptDB.sql ubicado en el directorio Database del proyecto.
	. Ejecutar el script para crear las tablas y datos iniciales en la base de datos.

### Ejecutar la aplicación
	. En la terminal, ejecutar el comando: dotnet run
	. La aplicación debería iniciarse y estar accesible en el navegador web en la URL especificada 
(por defecto, http://localhost:7148).
