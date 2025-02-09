namespace Site.Tests.Fixtures;

public class SiteApp(string environment = "Development") : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(environment);

        builder.ConfigureServices(services =>
        {
            // Add mock/test services to the builder here

            /*
            var oldDb = services.FirstOrDefault(s => s.ServiceType == typeof(MyDbContext));
            if (oldDb != null)
            {
                services.Remove(oldDb);
            }

            services.AddDbContext<MyDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "MyDb"));
            */

        });

        return base.CreateHost(builder);
    }
}
