using AT.Selenium.WebElement.BaseElements;
using OpenQA.Selenium;

namespace WebUi.Tests.PageObjects
{
    public class HomePage
    {
        public HtmlElement ProfileFirstName => new HtmlElement(By.Id("ctl00_CPHContainer_spFirstName"))
        { ExpectedTitle = "Name" };
    }
}
