using System;

namespace MyLittlePony.AT.Selenium.WebDriver.ConfModel
{
    public class TimeoutsInfo
    {
        public TimeSpan ElementTimeout { get; set; }
        public TimeSpan ImplicitWait { get; set; }
        public TimeSpan PageLoadTimeout { get; set; }
    }
}
