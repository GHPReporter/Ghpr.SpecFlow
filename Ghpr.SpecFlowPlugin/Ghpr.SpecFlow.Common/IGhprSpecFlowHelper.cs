using System;
using Ghpr.Core.Interfaces;
using TechTalk.SpecFlow;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowHelper
    {
        IGhprSpecFlowScreenHelper ScreenHelper { get; }

        ITestRun GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc);
        ITestRun UpdateTestRunOnScenarioEnd(ITestRun tr, Exception testError, string testOutput, FeatureContext fc, ScenarioContext sc);
        void OnGiven(ScenarioContext sc);
        void OnWhen(ScenarioContext sc);
        void OnAnd(ScenarioContext sc);
        void OnBut(ScenarioContext sc);
        void OnThen(ScenarioContext sc);
    }
}
