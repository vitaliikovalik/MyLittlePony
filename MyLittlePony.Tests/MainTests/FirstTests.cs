using MyLittlePony.AT.Framework.WebDriver;
using MyLittlePony.Tests.Base;
using NUnit.Framework;

namespace MyLittlePony.Tests.MainTests
{
    [TestFixture]
    public class FirstTests : UiTestBase
    {
        [Test]
        public void Test01()
        {
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test02()
        {
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test03()
        {
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test04()
        {
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }
    }
}
