using OpenQA.Selenium;

namespace MyLittlePony.AT.Selenium.WebElement.BaseElements.Buttons
{
    public class AcceptButton : HtmlElement
    {
        public AcceptButton(IWebElement convert) : base(convert)
        {
        }

        public AcceptButton(By locator) : base(locator)
        {
        }

        public AcceptButton(HtmlElement webElement, By locator) : base(webElement, locator)
        {
        }

        public AcceptButton(IWebElement webElement, By locator) : base(webElement, locator)
        {
        }

        #region Settable parameters

        public string ButtonText { get; set; }
        #endregion
    }
}
