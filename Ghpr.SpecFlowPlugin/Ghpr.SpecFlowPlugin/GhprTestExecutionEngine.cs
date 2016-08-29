using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly StringWriter _sw;

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
            _sw = new StringWriter();
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
            Log.Write($"Feature start! {featureInfo.Title}: {featureInfo.Description}");
        }

        public void OnFeatureEnd()
        {
            _engine.OnFeatureEnd();
            Log.Write("Feature end");
        }
        
        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            _engine.OnScenarioStart(scenarioInfo);
            Log.Write($"Scenario start! {scenarioInfo.Title}, Tags: {string.Join(", ", scenarioInfo.Tags)}");
            
            Console.SetOut(_sw);
        }
        
        public void OnScenarioEnd()
        {
            _engine.OnScenarioEnd();
            Log.Write("Scenario end");
            //Log.Write("Test: " + (ScenarioContext.Current?. ?? "null"));
            Log.Write("Context count: " + (ScenarioContext.Current?.Count));
            Log.Write("Test Error Message: " + (ScenarioContext.Current?.TestError?.Message ?? "null"));
            Log.Write("Test Error Stack: " + (ScenarioContext.Current?.TestError?.StackTrace ?? "null"));

            Log.Write("SW!!!! " + _sw);
            _sw.Dispose();
        }

        public void OnAfterLastStep()
        {
            _engine.OnAfterLastStep();
            Log.Write("Last step");
        }

        public void Step(StepDefinitionKeyword stepDefinitionKeyword, string keyword, string text, string multilineTextArg,
            Table tableArg)
        {
            _engine.Step(stepDefinitionKeyword, keyword, text, multilineTextArg, tableArg);
            Log.Write($"Step: {stepDefinitionKeyword}, {keyword}, {text}, {multilineTextArg}");
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