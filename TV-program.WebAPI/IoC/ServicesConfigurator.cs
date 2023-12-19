using TV_program.BL.Admins;
using TV_program.BL.Users;
using TV_program.BL.TVShow;
using TV_program.DataAccess;

namespace TV_program.WebAPI.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAdminsProvider, AdminsProvider>();
            services.AddScoped<IAdminsManager, AdminsManager>();
            services.AddScoped<IUsersProvider, UsersProvider>();
            services.AddScoped<IUsersManager, UsersManager>();
            services.AddScoped<ITVShowProvider, TVShowProvider>();
            services.AddScoped<ITVShowManager, TVShowManager>();
        }
    }
}
