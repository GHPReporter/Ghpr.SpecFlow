// ReSharper disable InconsistentNaming

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.UnitTestProvider;

namespace GhprMSTestTestContext.SpecFlowPlugin
{
    public class GhprMSTestTestContextSpecFlowPlugin : IGeneratorPlugin
    {
        public void CustomizeDependencies(object sender, CustomizeDependenciesEventArgs eventArgs)
        {
            eventArgs.ObjectContainer.RegisterTypeAs<GhprMSTestSpecFlowGeneratorProvider, IUnitTestGeneratorProvider>();
        }

        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            generatorPluginEvents.CustomizeDependencies += CustomizeDependencies;
        }
    }
}