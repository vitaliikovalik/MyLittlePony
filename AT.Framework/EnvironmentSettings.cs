using AT.Framework.Helpers;
using AT.Framework.Models;

namespace AT.Framework
{
    public static class EnvironmentSettings
    {
        public static EnvironmentInfo EnvironmentInfo => ConfigurationHelper.GetBindConfiguration<EnvironmentInfo>(section: "EnvironmentConf") ?? new EnvironmentInfo();
    }
}
