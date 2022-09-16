using MyLittlePony.AT.Framework.Logger;
using MyLittlePony.AT.Framework.WebDriver;
using NUnit.Framework;

[assembly: LevelOfParallelism(6)]
namespace MyLittlePony.Tests
{
    [SetUpFixture]
    public class ProjectSetUp
    {
        [OneTimeSetUp]
        public void ProjectOneTimeSetUp()
        {
            Logger.InitNewLogger(nameof(ProjectSetUp));
        }
        
        [OneTimeTearDown]
        public void ProjectOneTimeTearDown()
        {
            Driver.KillAllDriverProcess();
        }
    }
}
