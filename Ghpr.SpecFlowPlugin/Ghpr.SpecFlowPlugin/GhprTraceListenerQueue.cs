using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTraceListenerQueue : ITraceListenerQueue
    {
        /*private readonly TraceListenerQueue _traceListenerQueue;

        public GhprTraceListenerQueue(ITraceListener traceListener, ITestRunnerManager testRunnerManager)
        {
            _traceListenerQueue = new TraceListenerQueue(traceListener, testRunnerManager);
        }*/

        public void Dispose()
        {
            //_traceListenerQueue.Dispose();
        }

        public void Start()
        {
            //_traceListenerQueue.Start();
        }

        public void EnqueueMessgage(ITestRunner sourceTestRunner, string message, bool isToolMessgae)
        {
            //_traceListenerQueue.EnqueueMessgage(sourceTestRunner, message, isToolMessgae);
            Log.Write("EnqueueMessgage: " + message);
        }
    }
}