### Run database

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<PASSWORD>" -p 1433:1433 -d -v sqlvolume:/var/opt/mssql --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

### Add Secrets

```bash
dotnet user-secret init
dotnet user-secrets set "JWTSettings:securityKey" "<JWT_SECRET>"
dotnet user-secrets set "ConnectionStrings:AutoDbContext" "Server=localhost; Database=AutoStore; User Id=sa; Password=<DB_PASSWORD>;TrustServerCertificate=True"
```

### Create migration and Run

```bash
dotnet ef migrations add <MIGRATION_NAME> --output-dir Data/Migrations
dotnet ef database update
```
