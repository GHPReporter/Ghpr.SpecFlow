using System;
using BoDi;
using Ghpr.Core;
using Ghpr.Core.Utils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTraceListener : ITraceListener
    {
        //private readonly Log _l;
        private readonly ITraceListenerQueue _traceListenerQueue;
        private readonly Lazy<ITestRunner> _testRunner;

        public GhprTraceListener(ITraceListenerQueue traceListenerQueue, IObjectContainer container)
        {
            //_l = new Log(ReporterManager.OutputPath, $"trace_listener_{Guid.NewGuid()}.txt");
            //_l.Write("constructor");
            _traceListenerQueue = traceListenerQueue;
            _testRunner = new Lazy<ITestRunner>(container.Resolve<ITestRunner>);
        }
        
        public void WriteTestOutput(string message)
        {
            //_l.Write("test: " + message);
            _traceListenerQueue.EnqueueMessgage(_testRunner.Value, message, false);
        }

        public void WriteToolOutput(string message)
        {
            //_l.Write("tool: " + message);
            _traceListenerQueue.EnqueueMessgage(_testRunner.Value, message, true);
        }
    }
}