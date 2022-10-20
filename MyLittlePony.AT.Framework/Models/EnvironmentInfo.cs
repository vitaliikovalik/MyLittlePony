using MyLittlePony.AT.Framework.Models.Enums;

namespace MyLittlePony.AT.Framework.Models
{
    public class EnvironmentInfo
    {
        public string BaseUrl { get; set; }
        public EnvironmentType EnvironmentType { get; set; }
        public string DefaultUserName { get; set; }
        public string DefaultPassword { get; set; }
    }
}
