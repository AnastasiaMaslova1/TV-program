namespace TV_program.WebAPI.Settings
{
    public class FitnessClubSettingsReader
    {
        public static FitnessClubSettings Read(IConfiguration configuration)
        {
            return new FitnessClubSettings();
        }
    }
}
