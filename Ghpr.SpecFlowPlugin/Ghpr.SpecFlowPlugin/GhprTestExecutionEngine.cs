using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Infrastructure;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTestExecutionEngine : ITestExecutionEngine
    {
        public void OnTestRunStart()
        {
            Log.Write("Test run start");
        }

        public void OnTestRunEnd()
        {
            Log.Write("Test run end");
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            Log.Write("Feature start");
        }

        public void OnFeatureEnd()
        {
            Log.Write("Feature end");
        }

        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            Log.Write("Scenario start");
        }

        public void OnAfterLastStep()
        {
            Log.Write("Last step");
        }

        public void OnScenarioEnd()
        {
            Log.Write("Scenario end");
        }

        public void Step(StepDefinitionKeyword stepDefinitionKeyword, string keyword, string text, string multilineTextArg,
            Table tableArg)
        {
            Log.Write("Step");
        }

        public void Pending()
        {
            Log.Write("Pending");
        }

        public FeatureContext FeatureContext { get; }
        public ScenarioContext ScenarioContext { get; }
    }
}