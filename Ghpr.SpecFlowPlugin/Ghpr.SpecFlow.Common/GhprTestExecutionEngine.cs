﻿using System.Collections.Generic;
using BoDi;
using Ghpr.Core;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Analytics;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.CucumberMessages;
using TechTalk.SpecFlow.ErrorHandling;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;
using TechTalk.SpecFlow.UnitTestProvider;

namespace GhprSpecFlow.Common
{
    public class GhprTestExecutionEngine : ITestExecutionEngine
    {
        private readonly TestExecutionEngine _engine;

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
                IContextManager contextManager,
                IStepDefinitionMatchService stepDefinitionMatchService,
                IDictionary<string, IStepErrorHandler> stepErrorHandlers,
                IBindingInvoker bindingInvoker,
                IObsoleteStepHandler obsoleteStepHandler,
                ICucumberMessageSender cucumberMessageSender,
                ITestResultFactory testResultFactory,
                ITestPendingMessageFactory testPendingMessageFactory,
                ITestUndefinedMessageFactory testUndefinedMessageFactory,
                ITestRunResultCollector testRunResultCollector,
                IAnalyticsEventProvider analyticsEventProvider,
                IAnalyticsTransmitter analyticsTransmitter,
                ITestRunnerManager testRunnerManager,
                ITestObjectResolver testObjectResolver = null,
                IObjectContainer testThreadContainer = null)
        {
            _engine = new TestExecutionEngine(stepFormatter,
                testTracer,
                errorProvider,
                stepArgumentTypeConverter,
                specFlowConfiguration,
                bindingRegistry,
                unitTestRuntimeProvider,
                contextManager,
                stepDefinitionMatchService,
                stepErrorHandlers,
                bindingInvoker,
                obsoleteStepHandler,
                cucumberMessageSender,
                testResultFactory,
                testPendingMessageFactory,
                testUndefinedMessageFactory,
                testRunResultCollector,
                analyticsEventProvider,
                analyticsTransmitter,
                testRunnerManager,
                testObjectResolver,
                testThreadContainer);
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

        public void OnScenarioInitialize(ScenarioInfo scenarioInfo)
        {

            lock (Lock)
            {
                _engine.OnScenarioInitialize(scenarioInfo);
            }
        }

        public void OnScenarioStart()
        {
            lock (Lock)
            {
                _engine.OnScenarioStart();
            }
        }

        public void OnScenarioEnd()
        {
            lock (Lock)
            {
                _engine.OnScenarioEnd();
            }
        }

        public void OnScenarioSkipped()
        {
            lock (Lock)
            {
                _engine.OnScenarioSkipped();
            }
        }

        public void OnAfterLastStep()
        {
            lock (Lock)
            {
                _engine.OnAfterLastStep();
            }
        }

        public void Step(StepDefinitionKeyword stepDefinitionKeyword, string keyword, string text, string multilineTextArg,
            Table tableArg)
        {
            lock (Lock)
            {
                _engine.Step(stepDefinitionKeyword, keyword, text, multilineTextArg, tableArg);
            }
        }

        public void Pending()
        {
            lock (Lock)
            {
                _engine.Pending();
            }
        }
    }
}