using System;

namespace AT.Selenium.WebDriver.ConfModel
{
    public class RemoteDriverInfo
    {
        public string UserName { get; set; }
        public string AccessKey { get; set; }
        public string SeleniumVersion { get; set; }        
        public bool EnableVNC { get; set; }
        public bool EnableVideo { get; set; }        
        public string BrowserVersion { get; set; }
        public Uri Url { get; set; }
    }
}
