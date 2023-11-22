using TV_program.DataAccess;
using TV_program.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace TV_program.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, TV_programSettings settings)
    {
        services.AddDbContextFactory<TV_programDbContext>(
            options => { options.UseSqlServer(settings.TV_programDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<TV_programDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}
