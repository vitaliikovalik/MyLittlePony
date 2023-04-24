using System.ComponentModel;

namespace AT.Framework.Models.Enums
{
    public enum EnvironmentType
    {
        [Description("DEV Environment")]
        Qa,
        [Description("Staging Environment")]
        Stg
    }
}
