using MyLittlePony.AT.Framework;
using MyLittlePony.AT.Framework.WebDriver;
using NUnit.Framework;

namespace MyLittlePony.Tests.BaseTests
{
    [TestFixture]
    public class FirstTests : TestBase
    {
        [Test]
        public void Test01()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }

        [Test]
        public void Test02()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }

        [Test]
        public void Test03()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }

        [Test]
        public void Test04()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }
    }
}
