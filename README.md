# DotCommerce

A headless e-commerce backend platform built with .NET 10, exposing dual GraphQL APIs (Admin and Shop) powered by HotChocolate.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download) (see `global.json`)
- [PostgreSQL 17+](https://www.postgresql.org/)
- [Docker](https://www.docker.com/) (optional, for containerized setup)

## Getting Started

### Running with Docker (recommended)

The easiest way to get started is using the provided Docker Compose setup:

```bash
cd example
docker compose up --build
```

This starts:
- **PostgreSQL 17** on port `5432`
- **DotCommerce API** on port `8080`

The API will automatically run database migrations on startup.

### Running locally

1. Ensure PostgreSQL is running and create a database:

```sql
CREATE USER dot_commerce WITH PASSWORD 'dot_commerce';
CREATE DATABASE "dot-commerce" OWNER dot_commerce;
```

2. Update the connection string in `src/FuryTechs.DotCommerce.WebAPI/appsettings.json` if needed:

```json
{
  "ConnectionStrings": {
    "Default": "Host=localhost:5432;Database=dot-commerce;Username=dot_commerce;Password=dot_commerce"
  }
}
```

3. Restore, build, and run:

```bash
dotnet restore
dotnet run --project src/FuryTechs.DotCommerce.WebAPI
```

The API starts on `http://localhost:5001` by default.

## GraphQL Endpoints

| Endpoint | URL | Purpose |
|---|---|---|
| Shop API | `/graphql/shop-api` | Customer-facing storefront operations |
| Admin API | `/graphql/admin-api` | Back-office administration |

Both endpoints expose a GraphQL Playground UI for interactive exploration when running in `Development` mode.

### Available Operations

**Queries:**
- `me` - Returns the currently authenticated user (requires authentication)

**Mutations:**
- `login(input: LoginWithPassword!, totp: String)` - Password-based sign-in with optional TOTP 2FA
- `logout` - Signs out the current user
- `registerIdentityAccount(input: CustomerRegistrationModel!)` - Creates a new user account

## Project Structure

```
dot-commerce/
├── Directory.Packages.props          # Central Package Management (CPM)
├── Default.Build.props               # Shared build properties (analyzers)
├── global.json                       # .NET SDK version constraint
├── Dockerfile                        # Multi-stage Docker build
├── example/
│   └── docker-compose.yaml           # Ready-to-run environment
└── src/
    ├── FuryTechs.DotCommerce.Core/   # Core library
    │   ├── Database/
    │   │   ├── Entities/             # Domain entities (Customer, Identity, System)
    │   │   └── TypeConfigurations/   # EF Core fluent configurations
    │   ├── Extensions/               # DI and GraphQL extensions
    │   ├── GraphQL/                  # GraphQL schemas (Admin, Shop, Identity)
    │   └── Plugins/                  # Plugin system interface and loader
    └── FuryTechs.DotCommerce.WebAPI/ # Web API host
        └── Migrations/              # EF Core migrations (PostgreSQL)
```

## Architecture

- **Dual GraphQL API** - Separate Admin and Shop schemas for different access patterns
- **Generic primary keys** - The entity layer is generic over `TKey`, concretized to `Guid` in the WebAPI project
- **Multi-language support** - Built-in translation framework with `Language`, `EntityTranslation`, and `MultilLingualObject` base classes
- **Multi-channel** - Channel entity supporting multiple languages per channel
- **Plugin system** - Interface and assembly-loading infrastructure for extensibility via `IDotCommercePlugin`
- **Logical deletes** - Soft-delete support via `ILogicalDelete` interface
- **Automatic timestamps** - All entities track `CreatedAt` / `UpdatedAt` automatically

## Database Migrations

Migrations run automatically on startup. To manage migrations manually:

```bash
# Create a new migration
MIGRATION_NAME=MyMigration make mc

# Remove the last migration
make rm

# Apply pending migrations
make up
```

## Configuration

Configuration is loaded from `appsettings.json` and can be overridden with environment variables:

| Setting | Env Variable | Description |
|---|---|---|
| `ConnectionStrings:Default` | `ConnectionStrings__Default` | PostgreSQL connection string |
| `ASPNETCORE_ENVIRONMENT` | `ASPNETCORE_ENVIRONMENT` | Runtime environment (`Development`, `Production`) |

## Tech Stack

- **.NET 10** / ASP.NET Core
- **HotChocolate 14** - GraphQL server
- **Entity Framework Core 10** - ORM
- **PostgreSQL** via Npgsql
- **ASP.NET Core Identity** - Authentication and authorization
- **Argon2** - Password hashing
- **SonarAnalyzer** - Static code analysis

## License

[MIT](LICENSE) - Copyright (c) 2023 Balazs Gallay
