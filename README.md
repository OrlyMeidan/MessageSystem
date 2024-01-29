# MessageSystem


The project was written in NET CORE 6 implemented with SQL SQRVER CODE FIRES.
you need to change the connection string in appsettings.json of SQLSERVER AND REDIS
migration : the project use EF code first to migrat you need to run Update-database from Package Manager Console.

API's Return : all apise retun 200 -successfully 400 - BadRequest 500 -InternalServerError

ther is 3 services named ServiceA, ServiceB, and ServiceC.
● ServiceA saves a message with a random number to a MSSQL database.
● ServiceB retrieves messages from the database, processes the number, and stores the result in Redis.
● ServiceC retrieves the processed numbers from Redis and displays them in a terminal.
