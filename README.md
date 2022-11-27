# Learning ASP.NET Core (.NET 6) - REST API

This is a sample API implementation using .NET.

## Repository Contents

This repository contains the following sub-directories (with different API implementations):

- **[mvc](mvc)** the REST API created using MVC controllers,
- **[minimal](minimal)** the REST API created using minimal API endpoints,
- ~~[clean](clean) the REST API created using clean architecture approach and CQRS design pattern,~~
- ~~[graphql](graphql) the API created using GraphQL,~~
- ~~[grpc](grpc) the API created using GRPC,~~
- [clients](clients) clients to consume the APIs.

## Learning Resources

Based on these (free) courses/materials:

- APIs:
  - [REST](./docs/rest_apis.md),
  - [GraphQL](./docs/graphql_apis.md),
- [data access](./docs/data_access.md),
- [caching](./docs/caching.md),
- [logging](./docs/logging.md),
- [error handling](./docs/error_handling.md),
- [security](./docs/security.md),
- [deployment](./docs/deployment.md),
- [documenting](./docs/documenting.md),
- [clients](./docs/clients.md),
- [consume](./docs/consume.md),
- [clean architecture](./docs/clean_architecture.md),
- [other](./docs/other.md).

Also used these (paid) courses & books:

- **[ASP.NET Core 6 Web API Fundamentals](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-fundamentals/table-of-contents)** [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-fundamentals/exercise-files) [:file_folder:](https://github.com/KevinDockx/AspNetCore6WebAPIFundamentals) :+1:,
- [ASP.NET Core 6 Web API Deep Dive](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-deep-dive/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-deep-dive/exercise-files) [:file_folder:](https://github.com/KevinDockx/AspNetCore6WebAPIDeepDive) :arrow_forward:,
- **[Designing RESTful Web APIs](https://app.pluralsight.com/library/courses/designing-restful-web-apis/table-of-contents)** [:file_folder:](https://app.pluralsight.com/library/courses/designing-restful-web-apis/exercise-files) :+1:,
- ~~[Building a RESTful API with ASP.NET Core 3](https://app.pluralsight.com/library/courses/asp-dot-net-core-3-restful-api-building/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-3-restful-api-building/exercise-files),~~
- ~~[Implementing Advanced RESTful Concerns with ASP.NET Core 3](https://app.pluralsight.com/library/courses/asp-dot-net-core-3-advanced-restful-concerns/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-3-advanced-restful-concerns/exercise-files),~~
- ~~[Documenting an ASP.NET Core 2 API with OpenAPI / Swagger](https://app.pluralsight.com/library/courses/aspdotnet-core-api-openapi-swagger/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/aspdotnet-core-api-openapi-swagger/exercise-files),~~
- [Documenting an ASP.NET Core 6 Web API Using Swagger](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-documenting-swagger/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-documenting-swagger/exercise-files) ▶️,
- ~~[Building an Async API with ASP.NET Core 3](https://app.pluralsight.com/library/courses/building-async-api-aspdotnet-core/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/building-async-api-aspdotnet-core/exercise-files),~~
- ~~[Using OpenAPI/Swagger for Testing and Code Generation in ASP.NET Core 2](https://app.pluralsight.com/library/courses/asp-dot-net-openapi-swagger-testing-code-generation/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-openapi-swagger-testing-code-generation/exercise-files),~~
- [Unit Testing an ASP.NET Core 6 Web API](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-unit-testing/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-unit-testing/exercise-files) :arrow_forward:,
- ~~[Securing ASP.NET Core 3 with OAuth2 and OpenID Connect](https://app.pluralsight.com/library/courses/securing-aspnet-core-3-oauth2-openid-connect/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/securing-aspnet-core-3-oauth2-openid-connect/exercise-files),~~
- [ASP.NET Core Security](https://learning.oreilly.com/library/view/asp-net-core-security/9781633439986/) [:file_folder:](https://www.manning.com/downloads/2371) ▶️,
- [Securing ASP.NET Core 6 with OAuth2 and OpenID Connect](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-securing-oauth-2-openid-connect/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-securing-oauth-2-openid-connect/exercise-files) :arrow_forward:,
- **[ASP.NET Core 5 and React - Second Edition](https://learning.oreilly.com/library/view/asp-net-core-5/9781800206168/)** [:file_folder:](https://github.com/PacktPublishing/ASP.NET-Core-5-and-React-Second-Edition) :+1:,
- [Building a Consistent RESTful API with OData V4 in ASP.NET Core 5](https://app.pluralsight.com/library/courses/building-consistent-restful-api-odata-v4-asp-dot-net-core/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/building-consistent-restful-api-odata-v4-asp-dot-net-core/exercise-files),
- [ASP.NET Core 6 Web API: Best Practices](https://app.pluralsight.com/library/courses/aspdotnet-core-6-web-api-best-practices/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/aspdotnet-core-6-web-api-best-practices/exercise-files) :arrow_forward:,
- [Deploying ASP.NET Core 6 Web API to Azure API Management](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-deploying-web-api-azure-management/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-deploying-web-api-azure-management/exercise-files) :arrow_forward:,
- **[Building an End-to-end SPA Using ASP.NET Core 6 Web API and React](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-react-building-end-to-end-spa/table-of-contents)** [:file_folder:](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-react-building-end-to-end-spa/exercise-files) [:file_folder:](https://github.com/RolandGuijt/ps-globomantics-webapi-react) :+1:,
- **[Using HttpClient to Consume APIs in .NET 5](https://app.pluralsight.com/library/courses/using-httpclient-consume-apis-dot-net/table-of-contents)** [:file_folder:](https://app.pluralsight.com/library/courses/using-httpclient-consume-apis-dot-net/exercise-files) :+1:,
- [Building GraphQL APIs with ASP.NET Core 2](https://app.pluralsight.com/library/courses/building-graphql-apis-aspdotnet-core/table-of-contents) [:file_folder:](https://app.pluralsight.com/library/courses/building-graphql-apis-aspdotnet-core/exercise-files) :arrow_forward:.

This is (sort of) continuation of these projects:

- [MyHotels](https://github.com/sswietoniowski/work-codecool-csharp-webapi-MyHotels),
- [MyMovies](https://github.com/sswietoniowski/work-codecool-csharp-httpclient-MyMovies),
- [Learning ASP.NET Core - SOLID and Clean Architecture](https://github.com/sswietoniowski/learning-aspnetcore-solid-and-clean-architecture),
- [Learning ASP.NET Core - WebAPI (.NET 6) Fundamentals](https://github.com/sswietoniowski/learning-aspnetcore-webapi-6-fundamentals),
- [Learning EF Core 6 - (.NET 6) Fundamentals](https://github.com/sswietoniowski/learning-efcore-6-fundamentals),
- [Learning ASP.NET Core - WebAPI (.NET 6) - React - SPA](https://github.com/sswietoniowski/learning-aspnetcore-webapi-6-react-spa),
- [Learning - React - Summary and Core Feature Walkthrough](https://github.com/sswietoniowski/learning-react-summary-and-core-feature-walkthrough),
- [Learning ASP.NET Core and React - Frontend](https://github.com/sswietoniowski/learning-aspnetcore-react-frontend-react-app),
- [Learning ASP.NET Core and React - Backend](https://github.com/sswietoniowski/learning-aspnetcore-react-backend-web-api),
- [Learning ASP.NET Core - Security - CORS](https://github.com/sswietoniowski/learning-aspnetcore-security-cors).

## Useful Tools & Libraries

Some useful tools & libraries:

- [Postman](https://www.postman.com/),
- [Insomnia](https://insomnia.rest/),
- [Visual Studio Code - REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client),
- [Visual Studio Code - Rapid API](https://rapidapi.com/guides/replace-api-clients-with-vscode-using-the-rapidapi-extension),
- [West Wind WebSurge](https://websurge.west-wind.com/download),
- [JSON Editor Online](https://jsoneditoronline.org/),
- [AutoMapper](https://automapper.org/) [:file_folder:](https://github.com/AutoMapper/AutoMapper),
- [MediatR](https://github.com/jbogard/MediatR),
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/) [:file_folder:](https://github.com/FluentValidation/FluentValidation),
- [XUnit](https://xunit.net/) [:file_folder:](https://github.com/xunit/xunit),
- [Moq](https://github.com/moq/moq),
- [NSubstitute](https://nsubstitute.github.io/) [:file_folder:](https://github.com/nsubstitute/NSubstitute),
- [AutoFixture](https://github.com/AutoFixture/AutoFixture),
- [Faker](https://github.com/Kuree/Faker.Net),
- [Bogus](https://github.com/bchavez/Bogus),
- [SQLite and SQL Server Compact Toolbox](https://marketplace.visualstudio.com/items?itemName=ErikEJ.SQLServerCompactSQLiteToolbox),
- [Microsoft PowerToys](https://docs.microsoft.com/en-us/windows/powertoys/) [:file_folder:](https://docs.microsoft.com/en-us/windows/powertoys/install),
- [HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-6.0),
- [Refit](https://github.com/reactiveui/refit).
