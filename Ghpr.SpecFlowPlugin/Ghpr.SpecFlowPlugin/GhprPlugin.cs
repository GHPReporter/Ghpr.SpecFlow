using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            runtimePluginEvents.CustomizeTestThreadDependencies += CustomizeTestThreadDependencies;
        }

        private static void CustomizeTestThreadDependencies(object sender, CustomizeTestThreadDependenciesEventArgs e)
        {
            Log.Write("CustomizeTestThreadDependencies...");
            e.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
            //e.ObjectContainer.RegisterTypeAs<GhprTraceListenerQueue, ITraceListenerQueue>();
            e.ObjectContainer.RegisterTypeAs<GhprTraceListener, ITraceListener>();
            //e.ObjectContainer.RegisterTypeAs<GhprTestTracer, ITestTracer>();
        }
    }
}