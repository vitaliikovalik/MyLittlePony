using MyLittlePony.AT.Framework.Helpers;
using MyLittlePony.AT.Framework.Models;

namespace MyLittlePony.AT.Framework
{
    public static class EnvironmentSettings
    {
        public static EnvironmentInfo EnvironmentInfo => ConfigurationHelper.GetBindConfiguration<EnvironmentInfo>(section: "EnvironmentConf") ?? new EnvironmentInfo();
    }
}
