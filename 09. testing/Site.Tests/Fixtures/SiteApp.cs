namespace Site.Tests.Fixtures;

public class SiteApp : WebApplicationFactory<Program>
{
    private readonly string _environment;

    public SiteApp(string environment = "Development")
    {
        _environment = environment;
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_environment);

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
