using TV_program.DataAccess;
using TV_program.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TV_program.Repository;

public class RepositoryTestsBaseClass
{
    public RepositoryTestsBaseClass()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
            .Build();

        Settings = TV_programSettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<TV_programDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<TV_programDbContext>(
            options => { options.UseSqlServer(Settings.TV_programDbContextConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }

    protected readonly TV_programSettings Settings;
    protected readonly IDbContextFactory<TV_programDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
}