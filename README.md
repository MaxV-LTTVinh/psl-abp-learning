# tedu-ecommerce
TEDU Ecommerce solution using ABP Framework + Angular (TEDU-50)

## Docker Commands: (cd into folder contain file `docker-compose.yml`, `docker-compose.override.yml`)

- Up & running: 
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans --build
```
- Stop & Removing: 
```
docker-compose down
```
- Document migration: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli
Step start project:
- 1. start TeduEcommerce.DbMigrator to migration and seeding data and 
- 2. 