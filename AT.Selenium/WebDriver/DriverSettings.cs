using AT.Framework.Helpers;
using AT.Selenium.WebDriver.ConfModel;

namespace AT.Selenium.WebDriver
{
    public static class DriverSettings
    {
        public static DriverInfo DriverInfo => ConfigurationHelper.GetBindConfiguration<DriverInfo>(configName: "selsettings.json", section: "DriverConfiguration") ?? new DriverInfo();
    }
}
