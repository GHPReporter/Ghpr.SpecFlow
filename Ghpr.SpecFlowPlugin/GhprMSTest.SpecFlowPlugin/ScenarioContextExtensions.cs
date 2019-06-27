using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GhprMSTest.SpecFlowPlugin
{
    public static class ScenarioContextExtensions
    {
        public static TestContext TryGetTestContext(this ScenarioContext sc)
        {
            //return sc.ContainsKey("TestContext") ? sc["TestContext"] as TestContext : null;
            return sc.ScenarioContainer.Resolve<TestContext>();
        }
    }
}