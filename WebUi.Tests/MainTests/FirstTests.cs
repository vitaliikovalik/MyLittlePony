using AT.Framework;
using AT.Framework.CustomAttributes;
using AT.Framework.Models;
using AT.Framework.Models.Enums;
using AT.Selenium.WebDriver;
using NUnit.Framework;
using WebUi.Tests.Base;
using WebUi.Tests.BusinessActions;
using WebUi.Tests.DataSource;
using WebUi.Tests.PageObjects;

namespace WebUi.Tests.MainTests
{
    [TestFixture]
    public class FirstTests : UiTestBase
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.LoginTestCases))]
        public void LoginUser(LoginInfo info)
        {
            TestStep($"SetLoginForm as {EnvironmentSettings.EnvironmentInfo.DefaultUserName}", () =>
                new LoginActions().Login(info));
        }

        [Test]
        public void AssertLoginUi()
        {
            var loginPage = new LoginPage();

            TestStep($"Open Url '{EnvironmentSettings.EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl));

            TestStep("Verify Ui login box", () =>
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(loginPage.UserLogin.ExpectedTitle, loginPage.UserLogin.Title);
                    Assert.AreEqual(loginPage.Password.ExpectedTitle, loginPage.Password.Title);

                    Assert.AreEqual(loginPage.BtnLogin.ButtonText, loginPage.BtnLogin.Value);
                });
            });
        }

        [Test]
        [SkipIfEnvironment(EnvironmentType.Stg)]
        public void TestSkipIfEnvironmentAttribute()
        {
            TestStep($"Open Url '{EnvironmentSettings.EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl));
        }
    }
}
