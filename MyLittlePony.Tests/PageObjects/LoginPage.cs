using MyLittlePony.AT.Framework.Models;
using MyLittlePony.AT.Selenium.Helpers;
using MyLittlePony.AT.Selenium.WebElement.BaseElements;
using MyLittlePony.AT.Selenium.WebElement.BaseElements.Buttons;
using OpenQA.Selenium;

namespace MyLittlePony.Tests.PageObjects
{
    public class LoginPage
    {
        public InputElement UserLogin => new InputElement(By.Id("ctl00_CPHContainer_txtUserLogin")) 
            { ExpectedTitle = "Email Address / Login Id:" };

        public InputElement Password => new InputElement(By.Id("ctl00_CPHContainer_txtPassword")) 
            { ExpectedTitle = "Password :" };

        public AcceptButton BtnLogin => new AcceptButton(By.CssSelector("#ctl00_CPHContainer_btnLoginn")) 
            { ButtonText = "Login" };


        #region POM Methods

        public void SetLoginForm(LoginInfo info)
        {
            WaitUtilities.ConditionIsMet(ExpectedConditions.PageLoadIsComplete());

            UserLogin.SetValue(info.UserName);
            Password.SetValue(info.Password);
            BtnLogin.Click();
        }
        #endregion
    }
}
