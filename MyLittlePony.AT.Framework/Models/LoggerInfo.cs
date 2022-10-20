namespace MyLittlePony.AT.Framework.Models
{
    public class LoggerInfo
    {
        public string ConsoleConversionPattern { get; set; }
        public string FileConversionPattern { get; set; }
        public string LogLevel { get; set; }
        public bool TestStepLog { get; set; } = true;
        public bool ElementDiagnostic { get; set; } = true;
        public bool JavascriptDiagnostics { get; set; } = true;
    }
}
