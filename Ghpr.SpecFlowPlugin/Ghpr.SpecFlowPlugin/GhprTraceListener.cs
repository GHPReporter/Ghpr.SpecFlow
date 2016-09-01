using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTraceListener : ITraceListener
    {
        public void WriteTestOutput(string message)
        {
            OutputHelper.WriteLine(message);
        }

        public void WriteToolOutput(string message)
        {
            OutputHelper.WriteLine("-> " + message);
        }
    }
}