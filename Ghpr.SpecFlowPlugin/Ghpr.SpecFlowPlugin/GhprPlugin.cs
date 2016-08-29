using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            Log.Write("Initialize... " + runtimePluginParameters.Parameters);

            runtimePluginEvents.CustomizeTestThreadDependencies += CustomizeTestThreadDependencies;
            
            Log.Write("Done.");
            
        }

        /*private void CustomizeGlobalDependencies(object sender, CustomizeGlobalDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
        }

        private void RegisterGlobalDependencies(object sender, RegisterGlobalDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
        }*/

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