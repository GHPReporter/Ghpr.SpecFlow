using System.Collections.Generic;
using Ghpr.Core;
using Ghpr.Core.Common;
using Ghpr.Core.Enums;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
using NUnit.Framework;
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
        
        private readonly Log _l;

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
            
            _reporter = new Reporter(TestingFramework.SpecFlow);

            _l = new Log(_reporter.Settings.OutputPath, "plugin.txt");
            //_l.Write("constructor");
        }
        
        public void OnTestRunStart()
        {
            _engine.OnTestRunStart();
            _reporter.RunStarted();

            OutputHelper.Initialize();

            //_l.Write("run started");
        }

        public void OnTestRunEnd()
        {
            _engine.OnTestRunEnd();
            OutputHelper.Flush();
            OutputHelper.Dispose();
            _reporter.RunFinished();

            //_l.Write("run finished");
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            _currentFeatureInfo = featureInfo;
            _engine.OnFeatureStart(featureInfo);

            //_l.Write($"feature '{featureInfo.Title}' started");
        }

        public void OnFeatureEnd()
        {
            _engine.OnFeatureEnd();
            OutputHelper.Flush();

            //_l.Write("feature finished");
        }
        
        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            _engine.OnScenarioStart(scenarioInfo);
            OutputHelper.WriteFeature(_currentFeatureInfo);
            OutputHelper.WriteScenario(scenarioInfo);

            //_engine.ScenarioContext.StepContext.StepInfo.MultilineText;

            _currentTestRun = new TestRun
            {
                Name = scenarioInfo.Title,
                FullName = $"{TestContext.CurrentContext.Test.ClassName}.{_currentFeatureInfo.Title}",
                Categories = scenarioInfo.Tags
            };
            _reporter.TestStarted(_currentTestRun);
            
            //_l.Write($"scenario '{scenarioInfo.Title}' started");
        }

        public void OnScenarioEnd()
        {
            _engine.OnScenarioEnd();
            
            var te = _engine.ScenarioContext?.TestError;
            _currentTestRun.Output = OutputHelper.GetOutput();
            _currentTestRun.Result = te == null ? "Passed" : (te is AssertionException ? "Failed" : "Error");
            _currentTestRun.TestMessage = te?.Message ?? "";
            _currentTestRun.TestStackTrace = te?.StackTrace ?? "";

            _reporter.TestFinished(_currentTestRun);

            //_l.Write("scenario finished");

            OutputHelper.Flush();
        }

        public void OnAfterLastStep()
        {
            _engine.OnAfterLastStep();

            //_l.Write("after last step");
        }

        public void Step(StepDefinitionKeyword stepDefinitionKeyword, string keyword, string text, string multilineTextArg,
            Table tableArg)
        {
            _engine.Step(stepDefinitionKeyword, keyword, text, multilineTextArg, tableArg);
            _currentTestRun.FullName += text;
            OutputHelper.WriteStep(text);
            //_l.Write($"step: '{text}'");
        }

        public void Pending()
        {
            _engine.Pending();
        }

        public FeatureContext FeatureContext => _engine.FeatureContext;
        public ScenarioContext ScenarioContext => _engine.ScenarioContext;
    }
}