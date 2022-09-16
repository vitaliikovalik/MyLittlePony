using MyLittlePony.AT.Framework.Logger;
using MyLittlePony.AT.Framework.Models;
using MyLittlePony.AT.Framework.WebDriver;
using MyLittlePony.Tests.Base;
using MyLittlePony.Tests.DataSource;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyLittlePony.Tests.MainTests
{
    [TestFixture]
    public class FirstTests : UiTestBase
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.LoginTestCases))]
        public void LoginUser(LoginInfo info)
        {
            Logger.TestStepLog($"Step1 - Open Url '{BaseUrl}'");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);

            Logger.TestStepLog($"Step2 - Set UserName '{info.UserName}'");
            Driver.GetDriver().FindElement(By.CssSelector("#ctl00_CPHContainer_txtUserLogin")).SendKeys(info.UserName);

            Logger.TestStepLog($"Step3 - Set Password '{info.Password}'");
            Driver.GetDriver().FindElement(By.CssSelector("#ctl00_CPHContainer_txtPassword")).SendKeys(info.Password);

            Logger.TestStepLog("Step3 - Click Login button ");
            Driver.GetDriver().FindElement(By.CssSelector("#ctl00_CPHContainer_btnLoginn")).Click();
        }

        [Test]
        public void Test02()
        {
            Logger.Info($"Test02");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test03()
        {
            Logger.Info($"Test03");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test04()
        {
            Logger.Info($"Test04");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }
    }
}
