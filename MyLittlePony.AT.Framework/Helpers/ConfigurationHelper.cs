using System.IO;
using Microsoft.Extensions.Configuration;

namespace MyLittlePony.AT.Framework.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration(string configName = "appsettings.json")
        {
            var basePath = Directory.GetCurrentDirectory();

            return new ConfigurationBuilder().SetBasePath(basePath)
                .AddJsonFile(configName, optional: true, reloadOnChange: true).Build();
        }

        public static T GetBindConfiguration<T>(string section, string configName = "appsettings.json")
        {
            return GetConfiguration(configName)
                .GetSection(section)
                .Get<T>(x => x.BindNonPublicProperties = true);
        }
    }
}
