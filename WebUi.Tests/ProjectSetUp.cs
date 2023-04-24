using AT.Framework.Logger;
using AT.Selenium.WebDriver;
using NUnit.Framework;

[assembly: LevelOfParallelism(2)]
namespace WebUi.Tests
{
    [SetUpFixture]
    public class ProjectSetUp
    {
        [OneTimeSetUp]
        public void ProjectOneTimeSetUp()
        {
            WriteLog.InitNewLogger(nameof(ProjectSetUp));
        }
        
        [OneTimeTearDown]
        public void ProjectOneTimeTearDown()
        {
            Driver.KillAllDriverProcess(DriverSettings.DriverInfo.DriverType);
        }
    }
}
