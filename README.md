## SQL Explorer (Ver. 1.0)

### Introduction

This program is a basic SQL console coded in C# using the MySQL.Data package. Simply enter the server name, port number,
username, password, and database to initialize the SQL console into (if applicable).

When exiting the SQL Explorer program, type **quit** to close the SQL connection and exit the program.

### Connection Fields

**Server** - The SQL server to connect to.
**Port** - The port number to connect to the SQL server on.
**Username** - The SQL server username to login as.
**Password** - Password to login to the SQL server as the selected user.
**Database** - The database in the selected SQL server to use when the SQL console completes initialization.
			   This is equivalent to using the SQL command "USE DATABASE_NAME;" as the first command upon logging in to SQL Server.
			   If this field is left empty, then no database will be used when the SQL console completes initialization.
