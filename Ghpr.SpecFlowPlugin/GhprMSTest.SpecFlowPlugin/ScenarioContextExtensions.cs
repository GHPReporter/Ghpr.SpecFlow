using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GhprMSTest.SpecFlowPlugin
{
    public static class ScenarioContextExtensions
    {
        public static TestContext TestContext(this ScenarioContext sc)
        {
            return sc.ScenarioContainer.Resolve<TestContext>();
        }
    }
}