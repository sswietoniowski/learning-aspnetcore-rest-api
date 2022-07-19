# Sample Minimal REST API (.NET 6)

This solution was created using these commands:

```
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

To support Entity Framework you should execute these commands:

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --framework net6.0
dotnet add package Microsoft.EntityFrameworkCore.Design --framework net6.0
dotnet tool install dotnet-ef --configfile nuget.config
```

To add a new migration use:

```
dotnet ef migrations add <migrationname>
```

or from the Package Manager Console use:

```powershell
Add-Migration <migrationname>
```

To apply the migrations to the database use:

```
dotnet ef database update
```

or from the Package Manager Console use:

```powershell
Update-Database
```

To remove the last migration use:

```
dotnet ef remove <migrationname>
```

or from the Package Manager Console use:

```powershell
Remove-Migration
```
