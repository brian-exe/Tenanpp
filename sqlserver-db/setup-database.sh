echo 'Please wait while SQL Server 2017 warms up'
sleep 10s

echo 'Initializing database after 10 seconds of wait'
/opt/mssql-tools/bin/sqlcmd -S localhost -P Strong@Passw0rd -U sa -d master -i initialize-database.sql

echo 'Finished initializing the database'