using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Test_xUnit.TestFixtures;


public class DigitalBankWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // ServiceDescriptor? dbContextDescriptor = services.SingleOrDefault(
            //     d => d.ServiceType ==
            //          typeof(DbContextOptions<DigitalBankingDBContext>));
            //
            // if (dbContextDescriptor is { })
            //     services.Remove(dbContextDescriptor);
            //
            // ServiceDescriptor? dbConnectionDescriptor = services.SingleOrDefault(
            //     d => d.ServiceType ==
            //          typeof(DbConnection));
            //
            // if (dbConnectionDescriptor is { })
            //     services.Remove(dbConnectionDescriptor);
            //
            // // Create open SqliteConnection so EF won't automatically close it.
            // services.AddSingleton<DbConnection>(container =>
            // {
            //     var connection = new SqliteConnection("DataSource=:memory:");
            //     connection.Open();
            //
            //     return connection;
            // });
            //
            // services.AddDbContext<DigitalBankingDBContext>((container, options) =>
            // {
            //     var connection = container.GetRequiredService<DbConnection>();
            //     options.UseSqlite(connection);
            // });
        });

        // builder.Configure(app =>
        // {
            // using IServiceScope scope = app.ApplicationServices.CreateScope();
            // var dbContext = scope.ServiceProvider.GetService<DigitalBankingDBContext>();
            //
            // if (dbContext?.Database.EnsureDeleted() is true)
            // {
            //     dbContext.Database.EnsureCreated();
            // }
        // });
        

        builder.ConfigureAppConfiguration((hosting, config) =>
        {
            config
                .SetBasePath(Directory.GetCurrentDirectory());
            // .AddXmlFile($"ConnectionStrings.Testing.config", optional: false, reloadOnChange: true);
        });

        //builder.UseEnvironment("Production");
    }
}