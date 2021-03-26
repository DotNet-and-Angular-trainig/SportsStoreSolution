# SportsStore App

#### Packages for the ASPNetCore WebAPI

- Using PackageManagerConsole
  - Install-Package Swashbuckle.ASPNetCore -Version 6.1.1
  - Install-Package Microsoft.EntityFrameworkCore -Version 5.0.4
  - Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.4
  - Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.4


- Using Dotnet package
  - dotnet add package Swashbuckle.ASPNetCore -Version 6.1.1
  - dotnet add package Microsoft.EntityFrameworkCore -Version 5.0.4
  - dotnet add package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.4
  - dotnet add package Microsoft.EntityFrameworkCore.Design -Version 5.0.4

#### dotnet ef tools for the app

- dotnet tool update --global dotnet-ef (optional --version 5.0.4)
- dotnet ef commands
  - dotnet ef database update (will create the database if it does not exists, if it exists it will update it with the latest changes)
  - dotnet ef migrations add InitialDb -o Models\Migrations (will create class for the database with the tables and the constraints)
  - dotnet ef migrations remove (will remove the migrations)


#### Git Branches

- 01ModelEntites
- 02DbContext
- 03DotNetEFTool
- 04SportsStoreSeedData
- 05CreateRepository
- 06API
- 07Swagger