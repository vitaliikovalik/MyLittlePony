using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace MyLittlePony.AT.Framework.CustomAttributes
{
    public class TestReporterAttribute : Attribute, ITestAction
    {
        private int _linkId;

        public TestReporterAttribute(int linkId)
        {
            _linkId = linkId;
        }
        
        public void BeforeTest(ITest test)
        {
            //Create Suite

            throw new NotImplementedException();
        }

        public void AfterTest(ITest test)
        {
            //Report by Id

            throw new NotImplementedException();
        }

        public ActionTargets Targets { get; }
    }
}
