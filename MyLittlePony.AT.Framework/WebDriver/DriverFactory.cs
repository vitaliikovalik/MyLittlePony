using System;
using MyLittlePony.AT.Framework.WebDriver.Enum;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MyLittlePony.AT.Framework.WebDriver
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver(DriverType type)
        {
            return type switch
            {
                DriverType.Chrome => CreateChromeDriver(headless: false),
                DriverType.ChromeHeadless => CreateChromeDriver(headless: true),
                DriverType.Firefox => CreateFirefoxDriver(headless: false),
                DriverType.FirefoxHeadless => CreateFirefoxDriver(headless: true),
                DriverType.Edge => CreateEdgeDriver(headless: false),
                DriverType.EdgeHeadless => CreateEdgeDriver(headless: true),
                DriverType.InternetExplorer => throw new NotImplementedException($"'{type}' is not implemented yet!"),
                _ => throw new NotImplementedException($"'{type}' is not implemented yet!")
            };
        }

        #region MyRegion
        
        private IWebDriver CreateChromeDriver(bool headless)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            options.AddUserProfilePreference("download.prompt_for_download", false);

            if (headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }
            
            return new ChromeDriver(options);
        }

        private IWebDriver CreateEdgeDriver(bool headless)
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            options.AddUserProfilePreference("download.prompt_for_download", false);

            if (headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }

            return new EdgeDriver(options);
        }

        private IWebDriver CreateFirefoxDriver(bool headless)
        {
            var options = new FirefoxOptions();
            options.AddArgument("-start-maximized");
            options.AddArgument("-disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            //options.AddUserProfilePreference("download.prompt_for_download", false);

            if (headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }

            var driverService = FirefoxDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            return new FirefoxDriver(driverService, options);
        }
        #endregion
    }
}
