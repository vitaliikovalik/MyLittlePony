using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MyLittlePony.AT.Framework.Logger;
using MyLittlePony.AT.Selenium.WebDriver;
using OpenQA.Selenium;

namespace MyLittlePony.AT.Selenium.WebElement.BaseElements
{
    public class HtmlElement
    {
        protected IWebDriver MyDriver => Driver.GetDriver();

        private readonly IWebElement _parentWebElement = null;
        private readonly IWebElement _convert = null;

        public IWebElement Element => _convert ??
                                      (_parentWebElement == null
                                      ? MyDriver.FindElement(Locator)
                                      : _parentWebElement.FindElement(Locator));

        public By Locator { get; set; }


        public HtmlElement(IWebElement convert)
        {
            _convert = convert;
        }

        public HtmlElement(HtmlElement element, By locator)
        {
            _parentWebElement = element.Element;
            Locator = locator;
        }

        public HtmlElement(By locator)
        {
            Locator = locator;
        }

        public HtmlElement(IWebElement webElement, By locator)
        {
            _parentWebElement = webElement ?? throw new ArgumentNullException(nameof(webElement));
            Locator = locator;
        }

        #region Settable parameters

        public string ExpectedText { get; set; }

        public string ExpectedTitle { get; set; }
        #endregion

        #region Html Parameters

        public virtual string Text
        {
            get
            {
                var value = Element.Text;
                WriteLog.ElementDiagnostic($"Element '{Locator}' Text: {value}");

                return value;
            }
        }

        public virtual string Title
        {
            get
            {
                var value = Element.GetAttribute("title");
                WriteLog.ElementDiagnostic($"Element '{Locator}' get Title: '{value}'");

                return value;
            }
        }

        public virtual string Value
        {
            get
            {
                var value = Element.GetAttribute("value");
                WriteLog.ElementDiagnostic($"Element '{Locator}' get Value: '{value}'");

                return value;
            }
        }

        public virtual string InnerHtml
        {
            get
            {
                var value = Element.GetAttribute("innerHTML"); ;
                WriteLog.ElementDiagnostic($"Element '{Locator}' innerHTML: {value}");

                return value;
            }
        }

        public virtual string OuterHtml
        {
            get
            {
                var value = Element.GetAttribute("outerHTML"); ;
                WriteLog.ElementDiagnostic($"Element '{Locator}' outerHTML: {value}");

                return value;
            }
        }

        public string Id
        {
            get
            {
                var value = Element.GetAttribute("Id");
                WriteLog.ElementDiagnostic($"Element '{Locator}' id: {value}");

                return value;
            }
        }

        public string Name
        {
            get
            {
                var value = Element.GetAttribute("name");
                WriteLog.ElementDiagnostic($"Element '{Locator}' name: {value}");

                return value;
            }
        }

        public string Class
        {
            get
            {
                var value = Element.GetAttribute("class");
                WriteLog.ElementDiagnostic($"Element '{Locator}' class: {value}");

                return value;
            }
        }

        public bool Enabled
        {
            get
            {
                var value = Element.Enabled;
                WriteLog.ElementDiagnostic($"Element '{Locator}' Enabled: {value}");

                return value;
            }
        }

        public bool Displayed
        {
            get
            {
                var value = Element.Displayed;
                WriteLog.ElementDiagnostic($"Element '{Locator}' Displayed: {value}");

                return value;
            }
        }

        public string TagName
        {
            get
            {
                var value = Element.TagName;
                WriteLog.ElementDiagnostic($"Element '{Locator}' TagName: {value}");

                return value;
            }
        }

        public Point Location
        {
            get
            {
                var value = Element.Location;
                WriteLog.ElementDiagnostic($"Element '{Locator}' X location: {value.X} Y location: {value.Y}");

                return value;
            }
        }

        public Size Size
        {
            get
            {
                var value = Element.Size;
                WriteLog.ElementDiagnostic($"Element '{Locator}' Height: {value.Height} Width: {value.Width}");

                return value;
            }
        }

        public string GetCssValue(string value)
        {
            WriteLog.ElementDiagnostic($"Try to get CSS Value {value} from Element '{Locator}'");
            var result = Element.GetCssValue(value);

            WriteLog.ElementDiagnostic($"Element '{Locator}',  CSS Value {value} = '{result}'");

            return result;
        }

        public string GetAttributeValue(string name)
        {
            WriteLog.ElementDiagnostic($"Try to get attribute Value {name} from Element '{Locator}'");
            var result = Element.GetAttribute(name);

            WriteLog.ElementDiagnostic($"Element '{Locator}',  CSS Value {name} = '{result}'");

            return result;
        }

        public string GetProperty(string name)
        {
            WriteLog.ElementDiagnostic($"Try to get property Value {name} from Element '{Locator}'");
            var result = Element.GetDomProperty(name);

            WriteLog.ElementDiagnostic($"Element '{Locator}',  property {name} = '{result}'");

            return result;
        }

        public virtual HtmlElement Parent
        {
            get
            {
                var value = FindElement<HtmlElement>(By.XPath("parent::*"));
                WriteLog.ElementDiagnostic($"Element '{Locator}' Parent: {value.TagName}");

                return value;
            }
        }
        #endregion

        #region Main Methods

        public virtual void Click()
        {
            //Wait
            //MoveToElement
            Element.Click();

            WriteLog.ElementDiagnostic($"Element: {Locator} Clicked");
        }

        public T FindElement<T>(By by) where T : HtmlElement
        {
            WriteLog.ElementDiagnostic($"FindElement by '{by}' and cast to {typeof(T)}");

            return (T)Activator.CreateInstance(typeof(T), this, by);
        }

        public List<T> FindElements<T>(By by) where T : HtmlElement
        {
            if (by == null)
                throw new ArgumentNullException(nameof(by));

            WriteLog.ElementDiagnostic($"FindElement by  {by} and cast to {typeof(T)}");

            var elements = Element.FindElements(by);

            return elements.Select(v => (T)Activator.CreateInstance(typeof(T), v)).ToList();
        }

        protected virtual T Ancestor<T>(string by)
        {
            WriteLog.ElementDiagnostic($"FindElement by '{by}' and cast to {typeof(T)}");
           
            return (T)Activator.CreateInstance(typeof(T), this, By.XPath($"ancestor::{by}"));
        }
        #endregion

        #region ElementStates 

        public bool IsElementPresent()
        {
            try
            {
                var a = Element.Displayed;//Any state mean element present
                WriteLog.ElementDiagnostic("IsElementPresent is 'true'");
                return true;
            }
            catch (StaleElementReferenceException)
            {
                WriteLog.ElementDiagnostic("IsElementVisible is 'false' as StaleElementReferenceException happen");
                return false;
            }
            catch (NoSuchElementException)
            {
                WriteLog.ElementDiagnostic("IsElementVisible is 'false' as NoSuchElementException happen");
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }

        public bool IsElementVisible()
        {
            try
            {
                var isElementVisible = Element.Displayed;
                WriteLog.ElementDiagnostic($"isElementVisible by .Displayed '{isElementVisible}'");
                return isElementVisible;
            }
            catch (StaleElementReferenceException)
            {
                WriteLog.ElementDiagnostic("IsElementVisible is 'false' as StaleElementReferenceException happen");
                return false;
            }
            catch (NoSuchElementException)
            {
                WriteLog.ElementDiagnostic("IsElementVisible is 'false' as NoSuchElementException happen");
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }

        public bool IsElementClickable()
        {
            try
            {
                var clickable = Element is { Displayed: true, Enabled: true };
                WriteLog.ElementDiagnostic($"IsElementClickable is '{clickable}'");
                return clickable;
            }
            catch (StaleElementReferenceException)
            {
                WriteLog.ElementDiagnostic("IsElementClickable is 'false' as StaleElementReferenceException happen");
                return false;
            }
            catch (NoSuchElementException)
            {
                WriteLog.ElementDiagnostic("IsElementClickable is 'false' as NoSuchElementException happen");
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }

        public bool IsElementAbsent()
        {
            try
            {
                var a = Element.Displayed;//any state except exception - element present 
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }
        #endregion
    }
}
