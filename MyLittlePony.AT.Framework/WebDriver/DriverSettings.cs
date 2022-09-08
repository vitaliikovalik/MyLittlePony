using MyLittlePony.AT.Framework.Configuration;
using MyLittlePony.AT.Framework.Configuration.Model;

namespace MyLittlePony.AT.Framework.WebDriver
{
    public static class DriverSettings
    {
        public static DriverInfo DriverInfo => ConfigurationHelper.GetBindConfiguration<DriverInfo>(configName: "selsettings.json", section: "DriverConfiguration") ?? new DriverInfo();
    }
}
