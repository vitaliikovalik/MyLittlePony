using MyLittlePony.AT.Framework.Models;
using NUnit.Framework;
using System.Collections;

namespace MyLittlePony.Tests.DataSource
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
