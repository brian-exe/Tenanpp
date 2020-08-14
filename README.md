#Tenanpp

#Pasos para levantar la aplicación

##Aplicacion compuesta por tres componentes:
Frontend - Hecho en VueJS
Backend - Api en .NET Core
DB - SQL Server corriendo en container

##Para levantar Base

Primero instalar docker
https://docs.docker.com/engine/install/ubuntu/
Parado en directorio /sqlserver-db ejecutar "./startdb.sh"
Esto va a descargar la imagen docker de SQL Server y la base quedará corriendo pero vacia.
Para poder tener datos utilizar el backup incluido tambien en directorio /sqlserver-db:

https://docs.microsoft.com/en-us/sql/linux/tutorial-restore-backup-in-sql-server-container?view=sql-server-ver15

##Para levantar Backend se necesita

###Instalar net core 3.0. Seguir los pasos en este link
https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu

###Instalar entity framework
https://docs.microsoft.com/en-us/ef/core/get-started/install/

###Una vez instalado, parado en el directorio dotnet-app ejecutar

#### dotnet restore

#### dotnet build

#### dotnet run

##Para levantar Frontend se necesita
NodeJs https://nodejs.org/es/download/
###Ejecutar

#### npm install

#### npm run serve

Si todos los puertos estan configurados ok, deberia quedar andando
