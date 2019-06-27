using Ghpr.Core;
using Ghpr.Core.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace GhprSpecFlow.Common
{
    public class GhprTestRunner : ITestRunner
    {
        private readonly ITestRunner _runner;
        private readonly ITestExecutionEngine _engine;
        private FeatureInfo _currentFeatureInfo;
        private TestRunDto _currentTestRun;
        private OutputWriter _outputWriter;

        private static readonly object Lock = new object();
        
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
            ReporterManager.Action(r => r.CleanUpJob());
            ReporterManager.Action(r => r.TearDown());
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            _runner.OnFeatureStart(featureInfo);
            _currentFeatureInfo = featureInfo;
        }

        public void OnFeatureEnd()
        {
            _runner.OnFeatureEnd();
        }

        public void OnScenarioInitialize(ScenarioInfo scenarioInfo)
        {
            _outputWriter = new OutputWriter();
            _outputWriter.WriteFeature(_currentFeatureInfo);
            _runner.OnScenarioInitialize(scenarioInfo);
            _outputWriter.WriteScenario(scenarioInfo);
        }

        public void OnScenarioStart()
        {
            lock (Lock)
            {
                if (GhprPluginHelper.TestExecutionEngineHelper.UpdateTestDataProvider)
                {
                    var provider = GhprPluginHelper.TestExecutionEngineHelper.GetTestDataProvider(_currentFeatureInfo,
                        _engine.ScenarioContext?.ScenarioInfo, _engine.FeatureContext, _engine.ScenarioContext);
                    ReporterManager.SetTestDataProvider(provider);
                }
                _runner.OnScenarioStart();
                _currentTestRun = GhprPluginHelper.TestExecutionEngineHelper.GetTestRunOnScenarioStart(_runner, _currentFeatureInfo,
                    _engine.ScenarioContext?.ScenarioInfo, _engine.FeatureContext, _engine.ScenarioContext);
                ReporterManager.TestStarted(_currentTestRun);
            }
        }

        public void CollectScenarioErrors()
        {
            _runner.CollectScenarioErrors();
        }

        public void OnScenarioEnd()
        {
            lock (Lock)
            {
                var te = _engine.ScenarioContext?.TestError;
                var testOutput = _outputWriter.GetOutput();
                var fc = _engine.FeatureContext;
                var sc = _engine.ScenarioContext;
                _currentTestRun = GhprPluginHelper.TestExecutionEngineHelper.UpdateTestRunOnScenarioEnd(
                    _currentTestRun, te, testOutput, fc, sc, out var runOutput);
                ReporterManager.TestFinished(_currentTestRun, runOutput);
                _runner.OnScenarioEnd();
                _outputWriter.Flush();
            }
        }

        public void Given(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.Given(text, multilineTextArg, tableArg, keyword);
            _outputWriter.WriteStep(text);
            GhprPluginHelper.TestExecutionEngineHelper.OnGiven(_engine.ScenarioContext);
        }

        public void When(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.When(text, multilineTextArg, tableArg, keyword);
            _outputWriter.WriteStep(text);
            GhprPluginHelper.TestExecutionEngineHelper.OnWhen(_engine.ScenarioContext);
        }

        public void Then(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.Then(text, multilineTextArg, tableArg, keyword);
            _outputWriter.WriteStep(text);
            GhprPluginHelper.TestExecutionEngineHelper.OnThen(_engine.ScenarioContext);
        }

        public void And(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.And(text, multilineTextArg, tableArg, keyword);
            _outputWriter.WriteStep(text);
            GhprPluginHelper.TestExecutionEngineHelper.OnAnd(_engine.ScenarioContext);
        }

        public void But(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _runner.But(text, multilineTextArg, tableArg, keyword);
            _outputWriter.WriteStep(text);
            GhprPluginHelper.TestExecutionEngineHelper.OnBut(_engine.ScenarioContext);
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