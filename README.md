# Install Template
dotnet new -i .

# Uninstall Template
dotnet new --uninstall .

# Create Project with Template
dotnet new mvcclean --db Product -n Product

# Install EF
dotnet tool install --global dotnet-ef


# Create DbContext with EF & PostgreSQL
create .env for test


DB_NAME=template-cs-staging

DB_HOST=localhost

DB_PORT=5432

DATABASE_USER=user-template

DATABASE_PASSWORD=t3mpl4t3

