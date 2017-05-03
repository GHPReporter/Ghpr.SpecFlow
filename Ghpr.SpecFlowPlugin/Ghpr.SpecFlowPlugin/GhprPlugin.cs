using Ghpr.Core;
using Ghpr.Core.Enums;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            GhprPluginHelper.Init();
            ReporterManager.Initialize(TestingFramework.SpecFlow);
            runtimePluginEvents.CustomizeTestThreadDependencies += CustomizeTestThreadDependencies;
        }

        private static void CustomizeTestThreadDependencies(object sender, CustomizeTestThreadDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<GhprTestRunner, ITestRunner>();
            e.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
            e.ObjectContainer.RegisterTypeAs<GhprTraceListener, ITraceListener>();
        }
    }
}