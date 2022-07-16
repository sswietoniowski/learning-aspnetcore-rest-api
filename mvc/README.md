# Sample MVC REST API

This solution was created using these commands:

```
cd mvc
dotnet new globaljson --sdk-version 6.0.100 --roll-forward latestMajor --output "." --force
dotnet new editorconfig --output "." --force
dotnet new webapi --framework net6.0 --language C# --no-https false --auth None --use-minimal-apis false --use-program-main true --output "." --force
dotnet new sln -o "." --force
dotnet sln "." add "."
dotnet new gitignore --output "." --force
```
