using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.BindingSkeletons;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.ErrorHandling;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprTestExecutionEngine : ITestExecutionEngine
    {
        private readonly TestExecutionEngine _engine;

        public GhprTestExecutionEngine(
            IStepFormatter stepFormatter, 
            ITestTracer testTracer, 
            IErrorProvider errorProvider, 
            IStepArgumentTypeConverter stepArgumentTypeConverter, 
            RuntimeConfiguration runtimeConfiguration, 
            IBindingRegistry bindingRegistry, 
            IUnitTestRuntimeProvider unitTestRuntimeProvider, 
            IStepDefinitionSkeletonProvider stepDefinitionSkeletonProvider, 
            IContextManager contextManager, 
            IStepDefinitionMatchService stepDefinitionMatchService, 
            IDictionary<string, IStepErrorHandler> stepErrorHandlers, 
            IBindingInvoker bindingInvoker)
        {
            Log.Write("Constructor");
            _engine = new TestExecutionEngine(stepFormatter,
                testTracer,
                errorProvider,
                stepArgumentTypeConverter,
                runtimeConfiguration,
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
            _engine.OnTestRunStart();
            Log.Write("Test run start");
        }

        public void OnTestRunEnd()
        {
            _engine.OnTestRunEnd();
            Log.Write("Test run end");
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            _engine.OnFeatureStart(featureInfo);
            Log.Write("Feature start");
        }

        public void OnFeatureEnd()
        {
            _engine.OnFeatureEnd();
            Log.Write("Feature end");
        }

        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            _engine.OnScenarioStart(scenarioInfo);
            Log.Write("Scenario start");
        }

        public void OnAfterLastStep()
        {
            _engine.OnAfterLastStep();
            Log.Write("Last step");
        }

        public void OnScenarioEnd()
        {
            _engine.OnScenarioEnd();
            Log.Write("Scenario end");
        }

        public void Step(StepDefinitionKeyword stepDefinitionKeyword, string keyword, string text, string multilineTextArg,
            Table tableArg)
        {
            _engine.Step(stepDefinitionKeyword, keyword, text, multilineTextArg, tableArg);
            Log.Write("Step");
        }

        public void Pending()
        {
            _engine.Pending();
            Log.Write("Pending");
        }

        public FeatureContext FeatureContext => _engine.FeatureContext;
        public ScenarioContext ScenarioContext => _engine.ScenarioContext;
    }
}