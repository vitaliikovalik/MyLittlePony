using MyLittlePony.AT.Framework.Helpers;
using MyLittlePony.AT.Framework.Models;

namespace MyLittlePony.AT.Framework.Logger
{
    public static class LoggerSettings
    {
        public static LoggerInfo LoggerInfo => ConfigurationHelper.GetBindConfiguration<LoggerInfo>(section: "LogConf") ?? new LoggerInfo();
    }
}
