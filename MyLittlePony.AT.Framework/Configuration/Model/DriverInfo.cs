using MyLittlePony.AT.Framework.WebDriver.Enum;

namespace MyLittlePony.AT.Framework.Configuration.Model
{
    public class DriverInfo
    {
        public DriverType DriverType { get; set; } = DriverType.Chrome;
        public bool RunRemote { get; set; } = false;
        public bool Maximize { get; set; } = true;
        public int Width { get; set; }
        public int Height { get; set; }
        public RemoteDriverInfo RemoteDriverInfo { get; set; }
    }
}
