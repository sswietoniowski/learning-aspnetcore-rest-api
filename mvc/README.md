# Sample MVC REST API (.NET 5)

This solution was created using these commands:

```
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

To support Entity Framework project file ("mvc.csproj") was modified, to include the following:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
```

The same can be achieved by using these commands:

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.* --framework net5.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.* --framework net5.0
dotnet tool install dotnet-ef --version 5.* --configfile nuget.config
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
dotnet ef migrations remove
```

or from the Package Manager Console use:

```powershell
Remove-Migration
```
