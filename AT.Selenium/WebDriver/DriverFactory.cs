using System;
using System.Collections.Generic;
using AT.Selenium.WebDriver.ConfModel;
using AT.Selenium.WebDriver.Enum;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AT.Selenium.WebDriver
{
    public class DriverFactory
    {
        private readonly DriverInfo _config;

        public DriverFactory(DriverInfo info)
        {
            _config = info;
        }

        public IWebDriver CreateDriver()
        {
            return _config.DriverType switch
            {              
                DriverType.Chrome => CreateChromeDriver(headless: false),
                DriverType.ChromeHeadless => CreateChromeDriver(headless: true),
                DriverType.Firefox => CreateFirefoxDriver(headless: false),
                DriverType.FirefoxHeadless => CreateFirefoxDriver(headless: true),
                DriverType.Edge => CreateEdgeDriver(headless: false),
                DriverType.EdgeHeadless => CreateEdgeDriver(headless: true),
                DriverType.InternetExplorer => throw new NotImplementedException($"'{_config.DriverType}' is not implemented yet!"),
                _ => throw new NotImplementedException($"'{_config.DriverType}' is not implemented yet!")
            };
        }

        #region MyRegion

        private IWebDriver CreateChromeDriver(bool headless)
        {
            IWebDriver driver;

            var options = new ChromeOptions();
            options.AddArgument(_config.Maximize ? "start-maximized" : $"window-size={_config.Height},{_config.Width}");
            options.AddArgument("--disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            options.AddUserProfilePreference("download.prompt_for_download", false);

            if (!_config.RunRemote && headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }
                       
            if (_config.RunRemote)
            {
                var ltOptions = new Dictionary<string, object>();
                ltOptions.Add("os", "Windows");
                ltOptions.Add("osVersion", "10");
                ltOptions.Add("local", "false");
                ltOptions.Add("seleniumVersion", _config.RemoteDriverInfo.SeleniumVersion);
                ltOptions.Add("enableVNC", _config.RemoteDriverInfo.EnableVNC);
                ltOptions.Add("name", TestContext.CurrentContext.Test.Name);
                ltOptions.Add("enableVideo", _config.RemoteDriverInfo.EnableVideo);
                options.AddAdditionalOption("selenoid:options", ltOptions);

                driver = new RemoteWebDriver(_config.RemoteDriverInfo.Url, options);
            }               
            else
                driver = new ChromeDriver(options);

            return driver;
        }

        private IWebDriver CreateEdgeDriver(bool headless)
        {
            var options = new EdgeOptions();
            options.AddArgument(_config.Maximize ? "start-maximized" : $"window-size={_config.Height},{_config.Width}");
            options.AddArgument("--disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            options.AddUserProfilePreference("download.prompt_for_download", false);

            if (headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }

            if (_config.RunRemote)
                throw new NotImplementedException("EdgeDriver is not ready to run on remote");

            return new EdgeDriver(options);
        }

        private IWebDriver CreateFirefoxDriver(bool headless)
        {
            IWebDriver driver;

            var options = new FirefoxOptions();
            options.AddArgument(_config.Maximize ? "start-maximized" : $"window-size={_config.Height},{_config.Width}");
            options.AddArgument("-disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            //options.AddUserProfilePreference("download.prompt_for_download", false);                   

            var driverService = FirefoxDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;                     

            if (!_config.RunRemote && headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }

            if (_config.RunRemote)
            {
                var ltOptions = new Dictionary<string, object>();
                ltOptions.Add("os", "Windows");
                ltOptions.Add("osVersion", "10");
                ltOptions.Add("local", "false");
                ltOptions.Add("seleniumVersion", _config.RemoteDriverInfo.SeleniumVersion);
                ltOptions.Add("enableVNC", _config.RemoteDriverInfo.EnableVNC);
                ltOptions.Add("name", TestContext.CurrentContext.Test.Name);
                ltOptions.Add("enableVideo", _config.RemoteDriverInfo.EnableVideo);
                options.AddAdditionalOption("selenoid:options", ltOptions);

                driver = new RemoteWebDriver(_config.RemoteDriverInfo.Url, options);
            }
            else
                driver = new FirefoxDriver(driverService, options);

            return driver;
        }        
        #endregion
    }
}