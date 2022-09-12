using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.WebUI.Extensions;

public static class DbContextExtension
{
  public static WebApplicationBuilder RegisterDbContext(this WebApplicationBuilder builder)
  {
    builder.Services.AddDbContextFactory<TemplateContext>(opt =>
    {
        // For Linux dotenv
        // var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        //  var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        //  var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
        //  var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
        //  var dbName = Environment.GetEnvironmentVariable("DB_NAME");

        //PostgreSQL
        // var connectionString = $"Server={dbHost};port={dbPort};user id={dbUser};password={dbPassword};database={dbName};pooling=true";

        //MS SQL
        //var connectionString = $"Server={dbHost};Database={dbName};User={dbUser};Password={dbPassword};";

        //For appsettings.json
        //string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        string connectionString = builder.Configuration.GetConnectionString("TestDb");

        //For MS SQL
        //  opt.UseSqlServer(connectionString);
        //For PostgreSQL
        opt.UseNpgsql(connectionString);
    }, ServiceLifetime.Scoped);

    builder.Services.AddScoped<TemplateContext>(
    sp => sp.GetRequiredService<IDbContextFactory<TemplateContext>>()
    .CreateDbContext());

    return builder;
  }

  public static void ExecuteMigrations(this WebApplication app)
  {
    using var serviceScope = app.Services.CreateScope();
    serviceScope
      .ServiceProvider
      .GetRequiredService<IDbContextFactory<TemplateContext>>()
      .CreateDbContext()
      .Database
      .Migrate();
  }
}