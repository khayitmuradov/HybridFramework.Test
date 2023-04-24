using NUnit.Framework.Interfaces;

namespace HybridFramework.Test.Utils;

public class TestListener : ITestListener
{
    public void SendMessage(TestMessage message)
    {
        throw new NotImplementedException();
    }

    public void TestFinished(ITestResult result)
    {
        throw new NotImplementedException();
    }

    public void TestOutput(TestOutput output)
    {
        throw new NotImplementedException();
    }

    public void TestStarted(ITest test)
    {
        throw new NotImplementedException();
    }
}
