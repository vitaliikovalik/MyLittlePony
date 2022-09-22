using MyLittlePony.AT.Framework.Models;
using MyLittlePony.AT.Selenium.WebDriver;
using MyLittlePony.Tests.Base;
using MyLittlePony.Tests.PageObjects;
using NUnit.Framework;

namespace MyLittlePony.Tests.MainTests
{
    [TestFixture]
    public class SecondTests : UiTestBase
    {
        [Test]
        public void SignUpTest()
        {
            var loginPage = new LoginPage();

            TestStep($"Open Url '{EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentInfo.BaseUrl));

            TestStep($"Login as {EnvironmentInfo.DefaultUserName}", () =>
                    loginPage.Login(new LoginInfo() { UserName = EnvironmentInfo.DefaultUserName, Password = EnvironmentInfo.DefaultPassword }));
        }
    }
}
