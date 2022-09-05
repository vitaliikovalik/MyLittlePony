using MyLittlePony.AT.Framework.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyLittlePony.AT.Framework
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class TestBase
    {
        [SetUp]
        public void Setup()
        {

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
