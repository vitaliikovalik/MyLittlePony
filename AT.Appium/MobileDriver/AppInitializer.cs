using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace AT.Appium.MobileDriver
{
    public class AppInitializer
    {
        private static AppiumDriver<AppiumWebElement>? _app;

        public static void CreateDriver(string platformName)
        {
            if (platformName.Equals("iOS"))
            {
                _app = new IOSDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), GetIosCapabilities());
            }
            else if (platformName.Equals("Android"))
            {
                _app = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), GetAndroidCapabilities());
            }
        }

        private static AppiumOptions GetIosCapabilities()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone 12");
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
            capabilities.AddAdditionalCapability(MobileCapabilityType.Udid, "auto");
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, "/path/to/your/ios/app");
            return capabilities;
        }

        private static AppiumOptions GetAndroidCapabilities()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 4 API 30");
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            capabilities.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            //capabilities.AddAdditionalCapability(MobileCapabilityType.AppPackage, "com.android.calculator2");
            //capabilities.AddAdditionalCapability(MobileCapabilityType.AppActivity, ".Calculator");
            return capabilities;
        }
    }
}

