# Sample Minimal REST API (.NET 6)

Sample REST API for a Minimal Web Application.

To see a newer and more complete example, please visit:

- [Learning ASP.NET Core - WebAPI (.NET 7) Building Minimal APIs](https://github.com/sswietoniowski/learning-aspnetcore-webapi-7-building-minimal-apis).

## Setup

This solution was created using these commands:

```cmd
cd minimal
dotnet new globaljson --sdk-version 6.0.0 --roll-forward latestMinor --output "." --force
dotnet new editorconfig --output "." --force
dotnet new webapi --framework net6.0 --language C# --no-https false --auth None --use-minimal-apis true --use-program-main false --output "." --force
dotnet new sln -o "." --force
dotnet sln "." add "."
dotnet new gitignore --output "." --force
dotnet new nugetconfig --output "." --force
dotnet new tool-manifest --output "." --force
```

The following file(-s) was(were) then created/modified:

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

Some helper commands used while developing this project.

### Entity Framework

To support Entity Framework you should execute these commands:

```cmd
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --framework net6.0
dotnet add package Microsoft.EntityFrameworkCore.Design --framework net6.0
dotnet tool install dotnet-ef --configfile nuget.config
```

To add a new migration use:

```cmd
dotnet ef migrations add <migrationname> --output-dir "DataAccess/Data/Migrations"
```

or from the Package Manager Console use:

```powershell
Add-Migration <migrationname> -OutputDir "DataAccess/Data/Migrations"
```

To apply the migrations to the database use:

```cmd
dotnet ef database update
```

or from the Package Manager Console use:

```powershell
Update-Database
```

To remove the last migration use:

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

### Other Commands

To trust developer certificates use:

```cmd
dotnet dev-certs https --trust
```

To add user secrets use:

```cmd
dotnet user-secrets init
dotnet user-secrets set <key> <value>
```

## Known Limitations

Minimal APIs have some well-known limitations:

- don't support model validation,
- don't support JSON Patch,
- don't support filters,
- don't support _custom_ model binding,
- don't support OData,
- don't support api versioning.

More info about that [here](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio).

[This video](https://youtu.be/4ORO-KOufeU) explains how to overcome some of the limitations of the minimal APIs.
