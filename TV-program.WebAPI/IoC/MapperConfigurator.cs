using TV_program.BL.Mapper;
using BookShop.WebAPI.Mapper;
using TV_program.WebAPI.Mapper;

namespace TV_program.WebAPI.IoC
{
    public class MapperConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<AdminBLProfile>();
                config.AddProfile<UserBLProfile>();
                config.AddProfile<TVShowBLProfile>();
                config.AddProfile<AdminsServiceProfile>();
                config.AddProfile<UsersServiceProfile>();
                config.AddProfile<TVShowServiceProfile>();
            });
        }
    }
}
