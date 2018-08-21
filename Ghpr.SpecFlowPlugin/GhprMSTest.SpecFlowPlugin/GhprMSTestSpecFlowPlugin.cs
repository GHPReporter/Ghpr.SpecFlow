// ReSharper disable InconsistentNaming
using Ghpr.Core;
using Ghpr.Core.Enums;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
using GhprSpecFlow.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowPlugin : IRuntimePlugin
    {
        public static IGhprSpecFlowScreenHelper ScreenHelper =>
            GhprPluginHelper.TestExecutionEngineHelper.ScreenHelper;
        public static IGhprSpecFlowTestDataHelper TestDataHelper =>
            GhprPluginHelper.TestExecutionEngineHelper.TestDataHelper;

        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            ReporterManager.Initialize(TestingFramework.SpecFlow, new GhprMSTestSpecFlowTestDataProvider());
            ILogger logger = new EmptyLogger();
            ReporterManager.Action(r => { logger = r.Logger; });
            var specFlowHelper = new GhprMSTestSpecFlowHelper(logger);
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