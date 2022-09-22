using System;
using MyLittlePony.AT.Framework.Logger;

namespace MyLittlePony.AT.Framework
{
    public class TestBase
    {
        public void TestStep(string stepName, Action action)
        {
            try
            {
                WriteLog.TestStepLog($"STEP --- [{stepName}] --- STARTED");
                action.Invoke();

                WriteLog.TestStepLog($"STEP --- [{stepName}] --- ENDED SUCCESSFULLY");
            }
            catch (Exception e)
            {
                //Collect logs
                //Make printScreen

                WriteLog.TestStepLog($"STEP --- [{stepName}] --- FAILED, {WriteLog.NewLine(2)} ERROR: {e.Message}");

                throw new Exception("TestStep Failed", e);
            }
        }
    }
}
