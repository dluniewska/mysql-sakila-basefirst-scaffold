# mysql-sakila-basefirst-scaffold

> Test project created using context scafolding with MySql built-in sakila database

#### New challenges

1. Had to install and configure MySql and MySQL Workbench. Checked options to download test databases, world and sakila
2. Chosen scafolding using console command. Already had dotnet, but had to install new tool with:
```
dotnet tool install --global dotnet-ef
```
3.  Created scaffolded files with:
```
dotnet ef dbcontext scaffold "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;" MySql.EntityFrameworkCore -o sakila -f
```
I installed package _MySql.EntityFrameworkCore_ with version 7.0.10, which was the latest, but still needed to instal newest .NET runtime, 8.0.0 for command to work. Console by it self specifficaly told me to do so and given me needed link.


Scafolding was fast and easy. Only changed configuration of database connection string to Program.cs because i like it that way. All files was created in one folder named "sakila", so I think it needs a little architecture upgrade.
