using System.Collections;
using AT.Framework.Models;
using NUnit.Framework;

namespace WebUi.Tests.DataSource
{
    public static class TestDataSource
    {
        public static IEnumerable LoginTestCases
        {
            get
            {
                yield return new TestCaseData(new LoginInfo() { UserName = "vitalii", Password = "tuqd3" })
                    .SetCategory("Smoke")
                    .SetName("{m}ViaUserNameTest");
                yield return new TestCaseData(new LoginInfo() { UserName = "vitaliikovaliuk@icloud.com", Password = "tuqd3" })
                    .SetCategory("Regression")
                    .SetName("{m}ViaEmailTest");
            }
        }
    }
}
