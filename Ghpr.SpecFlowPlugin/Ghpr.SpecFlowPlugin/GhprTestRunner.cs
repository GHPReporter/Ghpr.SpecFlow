using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTestRunner : ITestRunner
    {
        private readonly ITestRunner _runner;
        private readonly ITestExecutionEngine _engine;

        public GhprTestRunner(ITestExecutionEngine engine)
        {
            _runner = new TestRunner(engine);
            _engine = engine;
            GhprPluginHelper.TestRunnerInitialized();
        }

        public void InitializeTestRunner(int threadId)
        {
            _runner.InitializeTestRunner(threadId);
        }

        public void OnTestRunStart()
        {
            _runner.OnTestRunStart();
        }

        public void OnTestRunEnd()
        {
            _runner.OnTestRunEnd();
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            _runner.OnFeatureStart(featureInfo);
        }

        public void OnFeatureEnd()
        {
            _runner.OnFeatureEnd();
        }

        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            _runner.OnScenarioStart(scenarioInfo);
        }

        public void CollectScenarioErrors()
        {
            _runner.CollectScenarioErrors();
        }

        public void OnScenarioEnd()
        {
            _runner.OnScenarioEnd();
        }

        public void Given(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.Given(text, multilineTextArg, tableArg, keyword);
        }

        public void When(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.When(text, multilineTextArg, tableArg, keyword);
        }

        public void Then(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.Then(text, multilineTextArg, tableArg, keyword);
        }

        public void And(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.And(text, multilineTextArg, tableArg, keyword);
        }

        public void But(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.But(text, multilineTextArg, tableArg, keyword);
        }

        public void Pending()
        {
            _runner.Pending();
        }

        public int ThreadId => _runner.ThreadId;
        public FeatureContext FeatureContext => _runner.FeatureContext;
        public ScenarioContext ScenarioContext => _runner.ScenarioContext;
    }
}