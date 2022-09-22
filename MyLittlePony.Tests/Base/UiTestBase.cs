using MyLittlePony.AT.Framework;
using MyLittlePony.AT.Framework.Configuration;
using MyLittlePony.AT.Framework.Configuration.Model;
using MyLittlePony.AT.Framework.Logger;
using MyLittlePony.AT.Selenium.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyLittlePony.Tests.Base
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class UiTestBase : TestBase
    {
        protected EnvironmentInfo EnvironmentInfo = ConfigurationHelper.GetBindConfiguration<EnvironmentInfo>("EnvironmentConf");

        [SetUp]
        public void Setup()
        {
            WriteLog.InitNewLogger(TestContext.CurrentContext.Test.FullName);
        }

        [TearDown]
        public void TearDown()
        {
            var browserLogs = Driver.GetDriver().Manage().Logs.GetLog(LogType.Browser);
            var performanceLogs = Driver.GetDriver().Manage().Logs.GetLog(LogType.Performance);

            Driver.QuiteDriver();
        }
    }
}
