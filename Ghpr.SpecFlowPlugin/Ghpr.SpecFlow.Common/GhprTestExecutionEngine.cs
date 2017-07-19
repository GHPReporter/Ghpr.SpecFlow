using System.Collections.Generic;
using Ghpr.Core;
using Ghpr.Core.Interfaces;
using Ghpr.SpecFlowPlugin;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.BindingSkeletons;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.ErrorHandling;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;
using TechTalk.SpecFlow.UnitTestProvider;
using static Ghpr.SpecFlow.Common.GhprPluginHelper;

namespace Ghpr.SpecFlow.Common
{
    public class GhprTestExecutionEngine : ITestExecutionEngine
    {
        private readonly TestExecutionEngine _engine;
        private FeatureInfo _currentFeatureInfo;
        private ITestRun _currentTestRun;
        private OutputWriter _outputWriter;

        public FeatureContext FeatureContext => _engine.FeatureContext;
        public ScenarioContext ScenarioContext => _engine.ScenarioContext;

        private static readonly object Lock = new object();

        public GhprTestExecutionEngine(
            IStepFormatter stepFormatter, 
            ITestTracer testTracer, 
            IErrorProvider errorProvider, 
            IStepArgumentTypeConverter stepArgumentTypeConverter, 
            SpecFlowConfiguration specFlowConfiguration, 
            IBindingRegistry bindingRegistry, 
            IUnitTestRuntimeProvider unitTestRuntimeProvider, 
            IStepDefinitionSkeletonProvider stepDefinitionSkeletonProvider, 
            IContextManager contextManager, 
            IStepDefinitionMatchService stepDefinitionMatchService, 
            IDictionary<string, IStepErrorHandler> stepErrorHandlers, 
            IBindingInvoker bindingInvoker)
        {
            _engine = new TestExecutionEngine(stepFormatter,
                testTracer,
                errorProvider,
                stepArgumentTypeConverter,
                specFlowConfiguration,
                bindingRegistry,
                unitTestRuntimeProvider,
                stepDefinitionSkeletonProvider,
                contextManager,
                stepDefinitionMatchService,
                stepErrorHandlers,
                bindingInvoker);
        }
        
        public void OnTestRunStart()
        {
            lock (Lock)
            {
                ReporterManager.RunStarted();
                _engine.OnTestRunStart();
            }
        }

        public void OnTestRunEnd()
        {
            lock (Lock)
            {
                ReporterManager.RunFinished();
                _engine.OnTestRunEnd();
            }
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            lock (Lock)
            {
                _currentFeatureInfo = featureInfo;
                _engine.OnFeatureStart(featureInfo);
            }
        }

        public void OnFeatureEnd()
        {
            lock (Lock)
            {
                _engine.OnFeatureEnd();
            }
        }
        
        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            lock (Lock)
            {
                _outputWriter = new OutputWriter();
                _outputWriter.WriteFeature(_currentFeatureInfo);
                _outputWriter.WriteScenario(scenarioInfo);
                _currentTestRun = TestExecutionEngineHelper.GetTestRunOnScenarioStart(_currentFeatureInfo, scenarioInfo);
                ReporterManager.TestStarted(_currentTestRun);
                _engine.OnScenarioStart(scenarioInfo);
            }
        }

        public void OnScenarioEnd()
        {
            lock (Lock)
            {
                var te = _engine.ScenarioContext?.TestError;
                _currentTestRun = TestExecutionEngineHelper.UpdateTestRunOnScenarioEnd(_currentTestRun, te);
                ReporterManager.TestFinished(_currentTestRun);
                _engine.OnScenarioEnd();
                _outputWriter.Flush();
            }
        }

        public void OnAfterLastStep()
        {
            _engine.OnAfterLastStep();
        }

        public void Step(StepDefinitionKeyword stepDefinitionKeyword, string keyword, string text, string multilineTextArg,
            Table tableArg)
        {
            _engine.Step(stepDefinitionKeyword, keyword, text, multilineTextArg, tableArg);
            _outputWriter.WriteStep(text);
        }

        public void Pending()
        {
            _engine.Pending();
        }
    }
}