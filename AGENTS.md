# AGENTS.md — DotCommerce

## Project Overview

.NET 10 / C# headless e-commerce backend. Two-project solution:
- **FuryTechs.DotCommerce.Core** — Reusable core library (entities, DB context, GraphQL, plugins)
- **FuryTechs.DotCommerce.WebAPI** — ASP.NET Core host (Program.cs, concrete DbContext, EF migrations)

Stack: ASP.NET Core, Entity Framework Core 10, HotChocolate GraphQL 14, PostgreSQL 17, ASP.NET Core Identity, Argon2 password hashing.

## Build Commands

```bash
dotnet restore                    # Restore NuGet packages
dotnet build                      # Build the entire solution
dotnet run --project src/FuryTechs.DotCommerce.WebAPI  # Run API at http://localhost:5001
dotnet publish src/FuryTechs.DotCommerce.WebAPI -c Release -o /app/publish  # Release build
```

Docker (from `example/` directory):
```bash
docker compose up --build         # Full environment: PostgreSQL 17 + API on port 8080
```

## Testing

Two unit test projects have been created in the `test` folder:
- **FuryTechs.DotCommerce.Core.Tests** — Unit tests for core library types
- **FuryTechs.DotCommerce.WebAPI.Tests** — Integration tests and API endpoint verification
When running tests, use standard .NET commands:

```bash
dotnet test                                          # Run all tests
dotnet test path/to/Project.Tests.csproj             # Run a single test project
dotnet test --filter "FullyQualifiedName~MyTest"     # Run a single test by name
dotnet test --filter "ClassName~MyClass"             # Run tests in a specific class
dotnet test --verbosity detailed                     # Verbose output
```

## Linting / Static Analysis

- **SonarAnalyzer.CSharp** (v9.0.0.68202) — Applied to all projects via `Default.Build.props`
- **StyleCop rules** — Configured in `.editorconfig` (many rules suppressed)
- No separate lint command; analysis runs as part of `dotnet build`
- Warnings surface during build output — fix them before committing

## Code Style Guidelines

### Language Settings

- **C# latest** (`<LangVersion>latest</LangVersion>`)
- **Nullable reference types enabled** (`<Nullable>enable</Nullable>`)
- **Implicit usings enabled** (`<ImplicitUsings>enable</ImplicitUsings>`)
- Prefer `var` everywhere (enforced via `.editorconfig`)

### Naming Conventions

| Element | Convention | Examples |
|---------|-----------|----------|
| Projects | Company-qualified dot-notation | `FuryTechs.DotCommerce.Core` |
| Namespaces | Match folder path, file-scoped (`namespace X;`) | `FuryTechs.DotCommerce.Core.Database.Entities.Base` |
| Classes | PascalCase, no prefix | `BaseDbContext`, `SnakeCaseNamingConvention` |
| Interfaces | PascalCase with `I` prefix | `IEntity<TKey>`, `ILogTimestamps`, `IDotCommercePlugin` |
| Records | PascalCase | `LoginWithPassword`, `LoginFailed` |
| Properties | PascalCase | `CreatedAt`, `FirstName`, `CountryCode` |
| Methods | PascalCase verb phrases | `ConfigureServices`, `AddDatabaseContext` |
| Local variables | camelCase | `connectionString`, `tableName` |
| Generic params | Descriptive PascalCase with `T` prefix | `TKey`, `TDbContext`, `TEntity` |
| Files | PascalCase matching primary type | `Bootstrap.cs`, `BaseDbContext.cs` |
| DB tables/columns | snake_case (via `SnakeCaseNamingConvention`) | `identity_user`, `created_at` |

### Suffixes

- Entity type configs: `*TypeConfig` (e.g., `UserTypeConfig`, `ChannelTypeConfig`)
- Extension classes: `*Extensions` (e.g., `ServiceCollectionExtensions`)
- Entity classes: plain domain name (e.g., `User`, `Customer`, `Channel`)

### Imports (using directives)

- `using` directives can appear inside or outside the namespace (SA1200 is disabled)
- System namespaces first, then framework, then internal, then third-party
- Relative `using` is allowed (e.g., `using Extensions;` within parent namespace)
- ImplicitUsings covers common `System.*` and `Microsoft.*` namespaces

### Types and Generics

- **Interfaces** for behavioral contracts (`IEntity<TKey>`, `ILogTimestamps`, `ILogicalDelete`)
- **Abstract classes** for shared implementation (`DotCommerceEntity<TKey>`, `BaseDbContext<TKey>`)
- **Records** for immutable DTOs and GraphQL inputs (`LoginWithPassword`, `CustomerRegistrationModel`)
- **Generic `TKey`** pattern: entire entity hierarchy parameterized by `TKey : IEquatable<TKey>`, concretized to `Guid` in WebAPI
- Use `required` modifier for properties that must be set at initialization
- Use `default!` for non-nullable properties populated by EF Core

### Error Handling

- Throw exceptions directly (`throw new InvalidOperationException(...)`, `throw new UnauthorizedAccessException()`)
- GraphQL union types for domain-level results (`ILoginResult` -> `CurrentUser` | `LoginFailed`)
- No try/catch or Result monad patterns in the codebase
- S112 (exception type restriction) is disabled in `.editorconfig`

### File Organization

```
src/
├── FuryTechs.DotCommerce.Core/
│   ├── Bootstrap.cs                          # App bootstrapping
│   ├── Database/
│   │   ├── BaseDbContext.cs                  # Abstract base DbContext
│   │   ├── SnakeCaseNamingConvention.cs      # DB naming convention
│   │   ├── Entities/{Domain}/                # Domain entity classes
│   │   └── TypeConfigurations/{Domain}/      # EF Core entity configs
│   ├── Extensions/                           # Extension method classes
│   ├── GraphQL/
│   │   ├── AdminAPI/                         # Admin schema (Queries.cs, Mutations.cs)
│   │   ├── ShopAPI/                          # Shop schema (Queries.cs, Mutations.cs)
│   │   └── Identity/                         # Cross-cutting identity resolvers
│   │       ├── Inputs/                       # GraphQL input types
│   │       └── Types/                        # GraphQL output/union types
│   └── Plugins/                              # Plugin system interfaces
└── FuryTechs.DotCommerce.WebAPI/
    ├── Program.cs                            # Minimal top-level entry point
    ├── WebDbContext.cs                        # Concrete DbContext (Guid keys)
    ├── DesignTimeDbContextFactory.cs          # EF tooling factory
    └── Migrations/                           # Auto-generated EF migrations
```

### Key Architecture Patterns

- **Domain-driven folder grouping**: Entities and TypeConfigurations mirror the same subdirectories (Base, Customer, Identity, System)
- **Dual GraphQL schemas**: Admin API (`/graphql/admin-api`) and Shop API (`/graphql/shop-api`) via HotChocolate
- **Type extensions** add resolvers to root Query/Mutation types (`[ExtendObjectType("Queries")]`)
- **DI via `[Service]` attribute** on GraphQL resolver method parameters
- **Auto-discovery** of entity type configurations via reflection in `BaseDbContext.OnModelCreating`
- **Auto-migration on startup** in `ServiceCollectionExtensions.AddPostgres()`
- **Central Package Management** — all NuGet versions in `Directory.Packages.props`; `.csproj` files reference packages without versions

### Formatting Notes

- `this.` prefix is optional (SA1101 disabled)
- File headers/copyright comments are optional (SA1633 disabled)
- Multiple types per file allowed (SA1402 disabled)
- File name need not match first type (SA1649 disabled)
- Member ordering is relaxed (SA1201, SA1202, SA1203, SA1204 disabled)
- XML doc comments are optional (SA1600, SA0001 disabled)
- `sealed` is used sparingly; `partial` used with `[GeneratedRegex]`

### Environment Requirements

- **.NET SDK 10.0** (see `global.json`)
- **PostgreSQL 17** — required for running the app (auto-migrates on startup)
- Default connection: `Host=localhost:5432;Database=dot-commerce;Username=cf_test;Password=cf_test`
- Set `ASPNETCORE_ENVIRONMENT=Development` for dev mode
- No `.env` files — configuration via `appsettings.json` or environment variables
