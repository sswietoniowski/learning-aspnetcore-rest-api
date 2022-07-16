# Sample Minimal REST API

This solution was created using these commands:

```
cd minimal
dotnet new globaljson --sdk-version 6.0.100 --roll-forward latestMajor --output "." --force
dotnet new editorconfig --output "." --force
dotnet new webapi --framework net6.0 --language C# --no-https false --auth None --use-minimal-apis true --use-program-main false --output "." --force
dotnet new sln -o "." --force
dotnet sln "." add "."
dotnet new gitignore --output "." --force
```
