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
```

The following file(-s) was(were) then created/modified:

- .gitattributes - created based on [this article](https://rehansaeed.com/gitattributes-best-practices/).
