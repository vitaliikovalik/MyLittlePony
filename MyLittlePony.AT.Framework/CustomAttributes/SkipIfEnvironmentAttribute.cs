using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using MyLittlePony.AT.Framework.Models.Enums;

namespace MyLittlePony.AT.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SkipIfEnvironmentAttribute : NUnitAttribute, IApplyToTest
    {
        private EnvironmentType _env;
        private string _message;

        public SkipIfEnvironmentAttribute(EnvironmentType type, string message = null)
        {
            _env = type;
            _message = message;
        }

        public void ApplyToTest(Test test)
        {
            if (test.RunState != RunState.NotRunnable && EnvironmentSettings.EnvironmentInfo.EnvironmentType.Equals(_env))
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set(PropertyNames.SkipReason, 
                    _message 
                    ?? $"Test is Skipped as environment equals [{_env}].");
            }
        }
    }
}
