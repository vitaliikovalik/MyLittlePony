using MyLittlePony.AT.Framework.Configuration;
using MyLittlePony.AT.Framework.Configuration.Model;

namespace MyLittlePony.AT.Framework.Logger
{
    public static class LoggerSettings
    {
        public static LoggerInfo LoggerInfo => ConfigurationHelper.GetBindConfiguration<LoggerInfo>(section: "Logging") ?? new LoggerInfo();
    }
}
