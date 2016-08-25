using BoDi;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;

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

        private void CustomizeGlobalDependencies(object sender, CustomizeGlobalDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
        }

        private void RegisterGlobalDependencies(object sender, RegisterGlobalDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
        }

        private void CustomizeTestThreadDependencies(object sender, CustomizeTestThreadDependenciesEventArgs e)
        {
            Log.Write("CustomizeTestThreadDependencies...");
            e.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
        }
    }
}