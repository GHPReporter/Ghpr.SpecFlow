using Ghpr.Core;
using Ghpr.Core.Enums;
using Ghpr.Core.Utils;
using Ghpr.SpecFlow.Common;
using Ghpr.SpecFlowPlugin;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;

namespace Ghpr.NUnit.SpecFlowPlugin
{
    public class Plugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            ReporterManager.Initialize(TestingFramework.SpecFlow);
            StaticLog.Initialize(ReporterManager.OutputPath);
            var specFlowHelper = new GhprNUnitSpecFlowHelper();
            GhprPluginHelper.Init(specFlowHelper);
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
