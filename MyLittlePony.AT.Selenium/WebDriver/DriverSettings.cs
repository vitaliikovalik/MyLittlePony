using MyLittlePony.AT.Framework.Helpers;
using MyLittlePony.AT.Selenium.WebDriver.ConfModel;

namespace MyLittlePony.AT.Selenium.WebDriver
{
    public static class DriverSettings
    {
        public static DriverInfo DriverInfo => ConfigurationHelper.GetBindConfiguration<DriverInfo>(configName: "selsettings.json", section: "DriverConfiguration") ?? new DriverInfo();
    }
}
