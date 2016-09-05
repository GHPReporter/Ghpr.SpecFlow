using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ghpr.Core;
using Ghpr.Core.Common;
using Ghpr.Core.Interfaces;
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
        private readonly Reporter _reporter;
        private FeatureInfo _currentFeatureInfo;
        private ITestRun _currentTestRun;

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
            _reporter = new Reporter();
        }
        
        public void OnTestRunStart()
        {
            _engine.OnTestRunStart();
            OutputHelper.Initialize();
            _reporter.RunStarted();
        }

        public void OnTestRunEnd()
        {
            _engine.OnTestRunEnd();
            OutputHelper.Flush();
            OutputHelper.Dispose();
            _reporter.RunFinished();
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            _currentFeatureInfo = featureInfo;
            _engine.OnFeatureStart(featureInfo);
        }

        public void OnFeatureEnd()
        {
            _engine.OnFeatureEnd();
            OutputHelper.Flush();
        }
        
        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            _engine.OnScenarioStart(scenarioInfo);
            OutputHelper.WriteFeature(_currentFeatureInfo);
            OutputHelper.WriteScenario(scenarioInfo);
            _currentTestRun = new TestRun
            {
                Name = scenarioInfo.Title,
                FullName = $"{_currentFeatureInfo.Title}.{scenarioInfo.Title}",
                Categories = scenarioInfo.Tags
            };
            _reporter.TestStarted(_currentTestRun);
        }
        
        public void OnScenarioEnd()
        {
            _engine.OnScenarioEnd();
            //Log.Write("Scenario end");
            //Log.Write("Context count: " + (ScenarioContext.Current?.Count));
            //Log.Write("Test Error Message: " + (ScenarioContext.Current?.TestError?.Message ?? "null"));
            //Log.Write("Test Error Stack: " + (ScenarioContext.Current?.TestError?.StackTrace ?? "null"));
            
            OutputHelper.Flush();
        }

        public void OnAfterLastStep()
        {
            _engine.OnAfterLastStep();
        }

        public void Step(StepDefinitionKeyword stepDefinitionKeyword, string keyword, string text, string multilineTextArg,
            Table tableArg)
        {
            _engine.Step(stepDefinitionKeyword, keyword, text, multilineTextArg, tableArg);
            //Log.Write($"Step: {stepDefinitionKeyword}, {keyword}, {text}, {multilineTextArg}");
        }

        public void Pending()
        {
            _engine.Pending();
            //Log.Write("Pending");
        }

        public FeatureContext FeatureContext => _engine.FeatureContext;
        public ScenarioContext ScenarioContext => _engine.ScenarioContext;
    }
}