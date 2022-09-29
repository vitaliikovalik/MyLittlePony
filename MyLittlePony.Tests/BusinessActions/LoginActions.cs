using MyLittlePony.AT.Framework;
using MyLittlePony.AT.Framework.Models;
using MyLittlePony.AT.Selenium.Helpers;
using MyLittlePony.AT.Selenium.WebDriver;
using MyLittlePony.Tests.PageObjects;

namespace MyLittlePony.Tests.BusinessActions
{
    public class LoginActions
    {
        public void Login(LoginInfo info)
        {
            Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl);
            WaitUtilities.ConditionIsMet(ExpectedConditions.PageLoadIsComplete());

            var loginPage = new LoginPage();
            var homePage = new HomePage();

            loginPage.SetLoginForm(info);

            WaitUtilities.WaitUntil(x => loginPage.BtnLogin.IsElementAbsent(), message: "SetLoginForm Failed, BtnLogin do not disappear");
            WaitUtilities.WaitUntil(x => homePage.ProfileFirstName.IsElementVisible(), message: "Home Page is not opened, ProfileFirstName Is Not Visible");
        }
    }
}
