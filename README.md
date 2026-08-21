# WooCommerce · React + TypeScript + .NET Core

A full-stack project pairing an **ASP.NET Core Web API** with two TypeScript frontends — a React storefront and a Next.js admin dashboard — over SQL Server, with JWT authentication and role-based access.

<p align="left">
  <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=flat-square&logo=dotnet&logoColor=white" alt="ASP.NET Core" />
  <img src="https://img.shields.io/badge/TypeScript-3178C6?style=flat-square&logo=typescript&logoColor=white" alt="TypeScript" />
  <img src="https://img.shields.io/badge/React-61DAFB?style=flat-square&logo=react&logoColor=black" alt="React" />
  <img src="https://img.shields.io/badge/Next.js-000000?style=flat-square&logo=next.js&logoColor=white" alt="Next.js" />
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white" alt="SQL Server" />
</p>

---

## Layout

```
WocommereceReactTypeScript.NetCore/   ASP.NET Core Web API — controllers, DI, middleware
IService/                             Service interfaces
Repository/                           Data access
DbConnection/                         ApplicationDbContext and entity configuration
Dashboard/
  React Website/                      Customer-facing storefront (React + TypeScript)
  nextjs-admin-dashboard-main/        Admin dashboard (Next.js)
database/
  database backup                     SQL Server backup for restoring the schema and data
```

Interfaces live in their own `IService` project rather than beside the implementations, so a consumer can reference the contract without pulling in the concrete service.

---

## API

**Authentication** — JWT bearer tokens with all four validations enabled (issuer, audience, lifetime, signing key). Three role policies are registered: **Admin**, **Employee** and **Hr**.

The middleware order is deliberate: `UseAuthentication()` runs before `UseAuthorization()`, since the first is what reads the bearer token and builds `User`. Reversed, the role policies would evaluate against an identity that has not been populated yet and always fail.

**Filtering and paging** — the API uses [Sieve](https://github.com/Biarity/Sieve), so list endpoints accept sorting, filtering and pagination from the query string instead of each controller hand-rolling its own parameters.

**Swagger** — configured with a bearer security definition, so protected endpoints can be called from the UI after clicking **Authorize** and pasting `Bearer <token>`.

**CORS** — a named `AllowReactApp` policy allows `http://localhost:3000`, which is where the React dev server runs.

---

## Getting started

**Prerequisites:** .NET 8 SDK, Node.js, and SQL Server.

### Database

Restore `database/database backup` in SQL Server Management Studio, or point the connection string at a fresh database.

### API

Set the connection string and JWT settings in `WocommereceReactTypeScript.NetCore/appsettings.json` — the connection string key is `Connection`:

```json
{
  "ConnectionStrings": {
    "Connection": "Server=.;Database=Woocommerce;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "a-long-random-secret",
    "Issuer": "Woocommerce",
    "Audience": "WoocommerceUsers"
  }
}
```

```bash
dotnet restore
dotnet run --project WocommereceReactTypeScript.NetCore
```

Swagger comes up at `/swagger` in Development.

### Frontends

```bash
cd "Dashboard/React Website"
npm install
npm start
```

```bash
cd Dashboard/nextjs-admin-dashboard-main
npm install
npm run dev
```

The React app expects the API's base URL; the CORS policy is already set up for port 3000.

---

## Notes

- `WeatherForecastController.cs` and `WeatherForecast.cs` are leftovers from the ASP.NET Core Web API template and are not part of the application.
- Swagger is only mapped in the Development environment, so a published build will not expose it.
- `Jwt:Key` is read straight from configuration — in a real deployment that belongs in user secrets or an environment variable rather than `appsettings.json`.

---

## Author

**Syed Abdul Munim Ali Shah** — [GitHub](https://github.com/syedmunimshah) · [Portfolio](https://abdulmunim.netlify.app/) · [LinkedIn](https://www.linkedin.com/in/syedabdulmunimalishah/)
