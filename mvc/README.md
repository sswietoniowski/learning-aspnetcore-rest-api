# Sample MVC REST API (.NET 5)

This solution was created using these commands:

```
cd mvc
dotnet new globaljson --sdk-version 5.0.0 --output "." --force
dotnet new webapi --framework net5.0 --language C# --no-https false --auth None --output "." --force
dotnet new sln -o "." --force
dotnet sln "." add "."
dotnet new gitignore --output "." --force
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
