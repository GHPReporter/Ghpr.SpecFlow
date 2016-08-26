using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTraceListener : ITraceListener
    {
        public void WriteTestOutput(string message)
        {
            Log.Write("    TestOutput: " + message);
        }

        public void WriteToolOutput(string message)
        {
            Log.Write("    ToolOutput: " + message);
        }
    }
}