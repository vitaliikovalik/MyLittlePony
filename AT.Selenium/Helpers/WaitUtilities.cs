using System;
using AT.Selenium.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AT.Selenium.Helpers
{
    public static class WaitUtilities
    {
        public static TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition, TimeSpan? timeout = null /*ElementTimeout*/, string message = null)
        {
            timeout ??= DriverSettings.DriverInfo.TimeoutsInfo.ElementTimeout;

            var wait = new WebDriverWait(Driver.GetDriver(), timeout.Value);
            wait.Message = string.IsNullOrEmpty(message) ? $"Wait condition not met after {wait.Timeout.TotalSeconds} seconds." : message;
            var element = wait.Until(condition);

            return element;
        }
        
        public static void ConditionIsMet(Func<IWebDriver, bool> condition, TimeSpan? timeout = null, string message = null)
        {
            timeout ??= DriverSettings.DriverInfo.TimeoutsInfo.ElementTimeout;

            var wait = new WebDriverWait(Driver.GetDriver(), timeout.Value);
            wait.Message = string.IsNullOrEmpty(message) ? $"Wait condition not met after {wait.Timeout.TotalSeconds} seconds." : message;

            wait.Until(condition);
        }
    }
}
