#!/bin/bash
docker start mssql-db 2> /dev/null
if [ $? -ne 0 ];then
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name mssql-db -v data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2017-latest
fi
