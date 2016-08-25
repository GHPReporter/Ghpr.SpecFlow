using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            Log.Write("Initialize");

            //var oc = new ObjectContainer();
            //oc.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
            //runtimePluginEvents.RaiseRegisterGlobalDependencies(oc);

            runtimePluginEvents.CustomizeGlobalDependencies += CustomizeGlobalDependencies;

        }

        private void CustomizeGlobalDependencies(object sender, CustomizeGlobalDependenciesEventArgs e)
        {
            CustomizeDependencies(e);
        }

        public void CustomizeDependencies(CustomizeGlobalDependenciesEventArgs eventArgs)
        {
            eventArgs.ObjectContainer.RegisterTypeAs<GhprTestExecutionEngine, ITestExecutionEngine>();
        }
    }
}