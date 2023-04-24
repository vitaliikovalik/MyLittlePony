using System;
using AT.Framework;
using AT.Framework.Logger;
using AT.Selenium.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebUi.Tests.Base
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class UiTestBase : TestBase
    {
        [SetUp]
        public void Setup()
        {
            WriteLog.InitNewLogger(TestContext.CurrentContext.Test.FullName);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.QuiteDriver();
        }

        protected override void HandleException()
        {
            try
            {
                TestAttachedFilePaths.Add(Driver.MakeScreenShot());
                TestAttachedFilePaths.Add(WriteLog.GetLogFilePath(TestContext.CurrentContext.Test.FullName));
                TestAttachedFilePaths.Add(Driver.SaveBrowserLog(LogType.Browser));
                TestAttachedFilePaths.Add(Driver.SaveBrowserLog(LogType.Performance));
            }
            catch (Exception ex)
            {
                WriteLog.Error($"Take ScreenShot or Browser Logs failed!, {ex}");
            }
        }
    }
}
