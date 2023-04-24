using AT.Framework.Helpers;
using AT.Framework.Models;

namespace AT.Framework.Logger
{
    public static class LoggerSettings
    {
        public static LoggerInfo LoggerInfo => ConfigurationHelper.GetBindConfiguration<LoggerInfo>(section: "LogConf") ?? new LoggerInfo();
    }
}
