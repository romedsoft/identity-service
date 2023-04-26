# identity-service
identity service for the angular-ionic-training https://github.com/romedsoft/angular-ionic-training


for running ef migrations

dotnet tool install --global dotnet-ef


dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb

dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb

dotnet ef database update -c PersistedGrantDbContext


dotnet ef database update -c ConfigurationDbContext