using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.Service.Settings;

namespace TV_program.WebAPI.UnitTests.Helpers
{
    public static class TestSettingsHelper
    {
        public static TV_programSettings GetSettings()
        {
            return TV_programSettingsReader.Read(ConfigurationHelper.GetConfiguration());
        }
    }
}
