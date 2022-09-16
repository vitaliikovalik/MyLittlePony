using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Linq;

namespace MyLittlePony.AT.Framework.Logger
{
    public static class Logger
    {
        [ThreadStatic]
        private static ILog _log;

        public static ILog GetLogger()
        {
            return _log;
        }

        public static void Debug(object message)
        {
            _log.Debug(message);
        }

        public static void NewLine(int value = 1)
        {
            var emptyLine = string.Empty;

            for (int i = 0; i < value; i++)
            {
                emptyLine += Environment.NewLine;
            }

            Info(emptyLine);
        }

        public static void Info(object message)
        {
            _log.Info(message);
        }

        public static void Error(object message)
        {
            _log.Error(message);
        }

        public static void Warn(object message)
        {
            _log.Warn(message);
        }

        #region Logger Extentions

        public static IWebElement LogDebug(this IWebElement element, object message)
        {
            _log.Debug(message);

            return element;
        }

        public static IWebElement LogInfo(this IWebElement element, object message)
        {
            _log.Info(message);

            return element;
        }
        #endregion

        #region Logger zones

        public static void ElementDiagnostic(string message)
        {
            if (LoggerSettings.LoggerInfo.ElementDiagnostic)
                Debug($"[ELEMENT_DIAGNOSTIC] {message}");
        }

        public static void TestStepLog(string message)
        {
            if (LoggerSettings.LoggerInfo.TestStepLog)
                Info($"[TEST_STEP_LOG] {message}");
        }
        #endregion

        public static void InitNewLogger(string fileName)
        {
            var di = Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/Logs/{fileName}");

            ILoggerRepository repository = LogManager.CreateRepository($"Log4net.{fileName}");

            SetLevel(repository.Name, LoggerSettings.LoggerInfo.LogLevel);
            AddAppender(repository.Name, CreateFileAppender($"{fileName}", $"{di.FullName}\\{fileName}_{DateTime.Now:MMDDHHmmss}.log"));
            AddAppender(repository.Name, CreateConsoleAppender($"{fileName}"));
        }

        private static void SetLevel(string repositoryName, string levelName, string name = default)
        {
            _log = LogManager.GetLogger(repositoryName, name ?? string.Empty);
            log4net.Repository.Hierarchy.Logger l = (log4net.Repository.Hierarchy.Logger)_log.Logger;

            l.Repository.Configured = true;
            l.Level = l.Hierarchy.LevelMap[levelName];
        }

        public static void AddAppender(string repositoryName, IAppender appender, string name = default)
        {
            _log = LogManager.GetLogger(repositoryName, name ?? string.Empty);

            log4net.Repository.Hierarchy.Logger l = (log4net.Repository.Hierarchy.Logger)_log.Logger;

            l.AddAppender(appender);
        }

        private static IAppender CreateFileAppender(string repositoryName, string filepath)
        {
            var layout = new PatternLayout()
            {
                ConversionPattern = LoggerSettings.LoggerInfo.FileConversionPattern
            };

            layout.ActivateOptions();

            var appender = new FileAppender()
            {
                Name = repositoryName,
                File = filepath,
                AppendToFile = true,
                Layout = layout
            };

            appender.ActivateOptions();

            return appender;
        }

        private static IAppender CreateConsoleAppender(string repositoryName)
        {
            var layout = new PatternLayout()
            {
                ConversionPattern = LoggerSettings.LoggerInfo.ConsoleConversionPattern
            };

            layout.ActivateOptions();

            var appender = new ConsoleAppender()
            {
                Name = repositoryName,
                Layout = layout
            };

            appender.ActivateOptions();

            return appender;
        }

        public static string GetLogFilePath(string repositoryName)
        {
            var rootAppender = _log.Logger.Repository
                .GetAppenders()
                .OfType<FileAppender>()
                .FirstOrDefault(fa => fa.Name == repositoryName);

            return rootAppender != null ? rootAppender.File : string.Empty;
        }
    }
}
