using AT.Framework.Logger;
using AT.Selenium.Helpers;
using OpenQA.Selenium;

namespace AT.Selenium.WebElement.BaseElements
{
    public class InputElement : HtmlElement
    {
        public InputElement(IWebElement convert) : base(convert)
        {
        }

        public InputElement(By locator) : base(locator)
        {
        }

        public InputElement(HtmlElement webElement, By locator) : base(webElement, locator)
        {
        }

        public InputElement(IWebElement webElement, By locator) : base(webElement, locator)
        {
        }

        private InputElement Input => FindElement<InputElement>(By.TagName("input"));
        private HtmlElement TitleBox => Ancestor<HtmlElement>("div[contains(@class, 'adm_control_box')]");

        #region Html parameters

        public override string Title
        {
            get
            {
                var value = TitleBox.Text;
                WriteLog.ElementDiagnostic($"Element '{Locator}' get Title: '{value}'");

                return value;
            }
        }
        #endregion

        #region Methods

        public void SetValue(string value)
        {
            WaitUtilities.WaitUntil(x => IsElementPresent(), message: $"Element '{Locator}' is not visible");

            if (TagName != "input")
                Input.SetValue(value); //NOTE: if current item is not an input, we will find first input inside current element and sendKeys in it
            else
                Element.SendKeys(value); //NOTE: if current item is input, we will sendKeys in it

            WriteLog.ElementDiagnostic($"HtmlElement '{Locator}' was SenKeys '{value}'");
        }
        #endregion
    }
}
