using MyLittlePony.AT.Framework.WebDriver.Enum;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace MyLittlePony.AT.Framework.WebDriver
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver != null) return _driver;

            _driver = new DriverFactory(DriverSettings.DriverInfo).CreateDriver();

            return _driver;
        }

        public static void QuiteDriver()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();

            _driver = null;
        }

        public static void KillAllDriverProcess(DriverType type = DriverType.Chrome)
        {
            string driverName;

            switch (type)
            {
                case DriverType.Chrome:
                case DriverType.ChromeHeadless:
                    driverName = "chromedriver";
                    break;
                case DriverType.Firefox:
                case DriverType.FirefoxHeadless:
                    driverName = "geckodriver";
                    break;
                case DriverType.Edge:
                case DriverType.EdgeHeadless:
                    driverName = "msedgewebview2";
                    break;
                case DriverType.InternetExplorer:
                    throw new NotImplementedException($"'{type}' is not implemented yet!");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            foreach (var chromeDriverProcess in Process.GetProcessesByName(driverName))
            {
                chromeDriverProcess.Kill();
            }
        }
    }
}
