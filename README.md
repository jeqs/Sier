# Prueba SIER

# Introducción
Este es un proyecto para presentar pruebas técnicas para la empresa Sier.

# Instalación
Puede abrir la solucion Sier.sln con Visual Studio 2017 y restaurar los paquetes con Nuget, el proyecto esta desarrollado en .Net Core 5.0.

# Web Front
Se desarrollo el Front en con Angular, favor ejecutar >npm install dentro de la carpeta SierFrontEnd.

# Base de Datos
Crear una base de datos en SQL Server llamada Sier, restaurar la base de datos con el archivo Sier.bak que se encuentra en la carpet ..\SierBackEnd\Sier.Databases\

# Ejecución
En la carpeta SierBackEnd\Sier.API, se encuentra un archivo llamado appsettings.json. Cambiar la cadena de conexión SierDB hacia el motor de la base de datos donde se restauro el Backup.
En la carpeta SierFrontEnd\src\environments, se encuentra dos archivos llamados environment.ts, cambiar la variable backend por la url donde se ejecuta el API y ejecutar por comando "ng serve" para inicia el aplicativo web.

# Arquitectura Limpia
Se basa en la idea de que la capa de dominio no dependa de ninguna capa exterior. La de aplicación sólo depende de la de dominio y el resto (normalmente presentación y acceso a datos) depende exclusivamente de la capa de aplicación.

# Donate/Support
If you like my work, feel free to support it. Donations to the project are always welcomed :)

Buy Me A Coffee
https://www.buymeacoffee.com/jeqs
