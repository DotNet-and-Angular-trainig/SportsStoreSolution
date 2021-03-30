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

#### Add Angular to the Project

- Goto SportsStoreApp Folder and add a new folder "ClientApp"
- Goto "ClientApp" folder and run the ng command
  - ng new --name SportsStoreNG --directory . --skip-install --skip-tests --skip-git --routing false --style css
- Configure Angular with ASPNetCore
  - add wwwroot folder at project root level
  - add the package 'Microsoft.AspNetCore.SpaService.Extensions'
  - dotnet add package Microsoft.AspNetCore.SpaService.Extensions --version 5.0.4
- update the Startup class with the SpaService integration
  - In ConfigureServices method
  - In Configure method
- Update the package.json in ClientApp folder with Bootstrap and Bootstrap-Icons and Prettier
- Use cmd, run the command npm install from the clientapp folder

#### Git Branches

- 01ModelEntites
- 02DbContext
- 03DotNetEFTool
- 04SportsStoreSeedData
- 05CreateRepository
- 06API
- 07Swagger

#### Git Branches For Angular

- 08SportsStoreAPI
- 09NGSportsStore
- 10NGConfiguration
- 11NGNavbarComponent
- 12NGNavbarModule
- 13NgStoresComponent
- 14NGStoresModule
- 15NGModelsProduct
- 16NGEvents
- 17NGPaging
- 18NGDirectivePaging
- 19NGCart
- 20NGRouting