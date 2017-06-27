using System.Collections.Generic;
using System.Linq;
using Ghpr.Core;
using Ghpr.Core.Common;
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
        private FeatureInfo _currentFeatureInfo;
        private ITestRun _currentTestRun;
        private OutputWriter _outputWriter;
        
        private static readonly object Lock = new object();

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
        }
        
        public void OnTestRunStart()
        {
            lock (Lock)
            {
                ReporterManager.RunStarted();
                //OutputHelper.Initialize();
                _engine.OnTestRunStart();
            }
        }

        public void OnTestRunEnd()
        {
            lock (Lock)
            {
                //OutputHelper.Flush();
                //OutputHelper.Dispose();
                //_outputWriter.Flush();
                //_outputWriter.Dispose();
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
                //OutputHelper.Flush();
                //_outputWriter.Flush();
                _engine.OnFeatureEnd();
            }
        }
        
        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            lock (Lock)
            {
                _outputWriter = new OutputWriter();
                //OutputHelper.WriteFeature(_currentFeatureInfo);
                //OutputHelper.WriteScenario(scenarioInfo);
                _outputWriter.WriteFeature(_currentFeatureInfo);
                _outputWriter.WriteScenario(scenarioInfo);
                var className = TestContext.CurrentContext.Test.ClassName;
                var testName = TestContext.CurrentContext.Test.Name;
                var names = className.Split('.').ToList();
                if (names.Count >= 2)
                {
                    names.RemoveAt(names.Count - 1);
                }
                className = string.Join(".", names);
                var fullName = $"{className}.{_currentFeatureInfo.Title}.{testName}";
                var name = scenarioInfo.Title;
                var guid = GuidConverter.ToMd5HashGuid(fullName).ToString();
                _currentTestRun = new TestRun(guid, name, fullName)
                {
                    Categories = scenarioInfo.Tags
                };
                ReporterManager.TestStarted(_currentTestRun);
                _engine.OnScenarioStart(scenarioInfo);
            }
        }

        public void OnScenarioEnd()
        {
            lock (Lock)
            {
                var te = _engine.ScenarioContext?.TestError;
                //_currentTestRun.Output = OutputHelper.GetOutput();
                _currentTestRun.Output = _outputWriter.GetOutput();
                _currentTestRun.Result = te == null ? "Passed" : (te is AssertionException ? "Failed" : "Error");
                _currentTestRun.TestMessage = te?.Message ?? "";
                _currentTestRun.TestStackTrace = te?.StackTrace ?? "";
                _currentTestRun.Screenshots = ScreenHelper.GetScreenshots();
                ReporterManager.TestFinished(_currentTestRun);
                _engine.OnScenarioEnd();
                //OutputHelper.Flush();
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
            //OutputHelper.WriteStep(text);
            _outputWriter.WriteStep(text);
        }

        public void Pending()
        {
            _engine.Pending();
        }

        public FeatureContext FeatureContext => _engine.FeatureContext;
        public ScenarioContext ScenarioContext => _engine.ScenarioContext;
    }
}