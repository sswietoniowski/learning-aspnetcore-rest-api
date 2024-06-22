# Sample MVC REST API (~~.NET 5~~.NET 6)

Sample REST API for an MVC Web Application.

This project was originally created using .NET 5 and later upgraded to .NET 6.

To see a newer and more complete example, please visit:

- [Learning ASP.NET Core - WebAPI (.NET 7) Fundamentals](https://github.com/sswietoniowski/learning-aspnetcore-webapi-7-fundamentals),
- [Learning ASP.NET Core - WebAPI (.NET 7) Documenting Using Swagger](https://github.com/sswietoniowski/learning-aspnetcore-webapi-7-documenting-using-swagger),
- [Learning ASP.NET Core - WebAPI (.NET 7) Unit Testing](https://github.com/sswietoniowski/learning-aspnetcore-webapi-7-unit-testing).

## Setup (.NET 5)

This solution was (originally) created using these commands:

```cmd
cd mvc
dotnet new globaljson --sdk-version 5.0.0 --output "." --force
dotnet new webapi --framework net5.0 --language C# --no-https false --auth None --output "." --force
dotnet new sln -o "." --force
dotnet sln "." add "."
dotnet new gitignore --output "." --force
dotnet new nugetconfig --output "." --force
dotnet new tool-manifest --output "." --force
```

The following file(-s) was(were) then created/modified:

- global.json,

```json
{
  "sdk": {
    "rollForward": "latestMinor",
    "version": "5.0.0"
  }
}
```

- .gitattributes - created based on [this article](https://rehansaeed.com/gitattributes-best-practices/).

Also [generated](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs) a self-signed certificate to enable HTTPS use in development:

```cmd
dotnet dev-certs https --trust
```

Then added support for user secrets:

```cmd
dotnet user-secrets init
```

## Helper Commands

Some helper commands were used while developing this project.

They were meant to create a .NET 5 project, and I kept them intact here as a reference guide. If you need to learn the syntax for .NET 6, please look into the "minimal" project.

### Entity Framework

To support Entity Framework project file ("mvc.csproj") was modified to include the following:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
```

The same can be achieved by using these commands:

```cmd
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.* --framework net5.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.* --framework net5.0
dotnet tool install dotnet-ef --version 5.* --configfile nuget.config
```

To add a new migration use:

```cmd
dotnet ef migrations add <migrationname> --output-dir "DataAccess/Data/Migrations"
```

or from the Package Manager Console use:

```powershell
Add-Migration <migrationname> -OutputDir "DataAccess/Data/Migrations"
```

To apply the migrations to the database, use:

```cmd
dotnet ef database update
```

or from the Package Manager Console use:

```powershell
Update-Database
```

To remove the last migration, use:

```cmd
dotnet ef migrations remove
```

or from the Package Manager Console use:

```powershell
Remove-Migration
```

To revert the last database migration use:

```cmd
dotnet ef database update <lastgoodmigration>
```

or from the Package Manager Console use:

```powershell
Update-Database -Migration <lastgoodmigration>
```

To drop the database use:

```cmd
dotnet ef database drop
```

or from the Package Manager Console use:

```powershell
Drop-Database
```

More info about how to manage migrations can be found [here](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli).
