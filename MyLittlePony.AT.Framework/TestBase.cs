using System;
using System.Collections.Generic;
using System.Diagnostics;
using MyLittlePony.AT.Framework.CustomExceptions;
using MyLittlePony.AT.Framework.Logger;

namespace MyLittlePony.AT.Framework
{
    public abstract class TestBase
    {
        [ThreadStatic]
        protected static List<string> TestAttachedFilePaths;

        public virtual void TestStep(string stepName, Action action)
        {
            var watch = new Stopwatch();

            try
            {
                watch.Start();
                WriteLog.TestStepLog($"STEP --- [{stepName}] --- STARTED");
                action.Invoke();

                watch.Stop();
                WriteLog.TestStepLog(
                    $"STEP --- [{stepName}] --- ENDED SUCCESSFULLY, [EXECUTION_TIME: {watch.Elapsed.Seconds}s]");
            }
            catch (FatalTestingException ex)
            {
                watch.Stop();

                HandleException();
                WriteLog.Error($"STEP --- [{stepName}] --- FAILED, [EXECUTION_TIME: {watch.Elapsed.Seconds}s], {WriteLog.NewLine(2)} ERROR: {ex.Message}");

                throw;
            }
            catch (Exception ex)
            {
                watch.Stop();
                WriteLog.Error($"STEP --- [{stepName}] --- FAILED, [EXECUTION_TIME: {watch.Elapsed.Seconds}s], {WriteLog.NewLine(2)} ERROR: {ex.Message}");
            }
        }

        protected virtual void HandleException()
        {
        }
    }
}
