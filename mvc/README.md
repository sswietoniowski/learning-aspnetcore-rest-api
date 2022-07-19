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

To support Entity Framework I have to modify project file ("mvc.csproj") to include the following:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.*" Condition="'$(TargetFramework)' == 'net5.0'" />
```

or execute these commands:

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.* --framework net5.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.* --framework net5.0
dotnet tool install dotnet-ef --version 5.* --configfile nuget.config
```
