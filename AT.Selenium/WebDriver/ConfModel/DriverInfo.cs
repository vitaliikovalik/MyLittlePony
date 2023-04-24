using AT.Selenium.WebDriver.Enum;

namespace AT.Selenium.WebDriver.ConfModel
{
    public class DriverInfo
    {
        public DriverType DriverType { get; set; } = DriverType.Chrome;
        public bool RunRemote { get; set; } = false;
        public bool Maximize { get; set; } = true;
        public int Width { get; set; }
        public int Height { get; set; }
        public TimeoutsInfo TimeoutsInfo { get; set; }
        public RemoteDriverInfo RemoteDriverInfo { get; set; }
    }
}
