// ReSharper disable InconsistentNaming

using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

namespace GhprMSTestTestContext.SpecFlowPlugin
{
    public class GhprMSTestTestContextSpecFlowPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters)
        {
            generatorPluginEvents.CustomizeDependencies += CustomizeDependencies;
        }

        public void CustomizeDependencies(object sender, CustomizeDependenciesEventArgs eventArgs)
        {
            eventArgs.ObjectContainer.RegisterTypeAs<GhprMSTestSpecFlowGeneratorProvider, IUnitTestGeneratorProvider>();
        }
    }
}