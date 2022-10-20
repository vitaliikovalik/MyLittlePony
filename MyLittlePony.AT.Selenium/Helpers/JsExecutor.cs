using MyLittlePony.AT.Framework.Logger;
using MyLittlePony.AT.Selenium.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Globalization;

namespace MyLittlePony.AT.Selenium.Helpers
{
    public static class JsExecutor
    {
        /// <summary>
        /// ExecuteScript Extenstion method for Driver
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="script"></param>
        /// <returns></returns>
        public static string ExecuteScript(this IWebDriver driver, string script)
        {
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string result = (string)js.ExecuteScript($"{script}");

            WriteLog.JavascriptDiagnostics($"Javascript Execution: {script} Results: {result}");

            return result;
        }

        /// <summary>
        /// ExecuteScript Extenstion method for IWebElement
        /// </summary>
        /// <param name="element"></param>
        /// <param name="script">Script to execute arguments[0]{script}</param>
        /// <returns></returns>
        public static string ExecuteScript(this IWebElement element, string script)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            string result = Driver.GetDriver().ExecuteJavaScript<string>($"{script}", element);

            WriteLog.JavascriptDiagnostics($"Javascript Execution: arguments[0]{script} Results: {result}");

            return result;
        }

        /// <summary>
        /// Static Script Executor
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static string ExecuteScript(string script)
        {
            string result = (string)Driver.GetDriver().ExecuteScript($"{script}");

            WriteLog.JavascriptDiagnostics($"Javascript Execution: {script} Results: {result}");

            return result;
        }

        /// <summary>
        /// Static Script Executor
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static T ExecuteScript<T>(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.GetDriver();

            var scriptResult = js.ExecuteScript($"{script}");
            var result = (T)Convert.ChangeType(scriptResult, typeof(T), CultureInfo.InvariantCulture);
            WriteLog.JavascriptDiagnostics($"Javascript Execution: {script} Results: {typeof(T)}");

            return result;
        }
    }
}
