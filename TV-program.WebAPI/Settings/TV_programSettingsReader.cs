namespace TV_program.Service.Settings
{
    public class TV_programSettingsReader
    {
        public static TV_programSettings Read(IConfiguration configuration)
        {
            return new TV_programSettings()
            {
                TV_programDbContextConnectionString = configuration.GetValue<string>("TV_programDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret")
            };
        }
    }
}