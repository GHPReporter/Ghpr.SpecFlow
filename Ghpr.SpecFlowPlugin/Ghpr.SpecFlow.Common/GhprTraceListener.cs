using System;
using BoDi;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace GhprSpecFlow.Common
{
    public class GhprTraceListener : ITraceListener
    {
        private readonly ITraceListenerQueue _traceListenerQueue;
        private readonly Lazy<ITestRunner> _testRunner;

        public GhprTraceListener(ITraceListenerQueue traceListenerQueue, IObjectContainer container)
        {
            _traceListenerQueue = traceListenerQueue;
            _testRunner = new Lazy<ITestRunner>(container.Resolve<ITestRunner>);
        }
        
        public void WriteTestOutput(string message)
        {
            _traceListenerQueue.EnqueueMessage(_testRunner.Value, message, false);
        }

        public void WriteToolOutput(string message)
        {
            _traceListenerQueue.EnqueueMessage(_testRunner.Value, message, true);
        }
    }
}