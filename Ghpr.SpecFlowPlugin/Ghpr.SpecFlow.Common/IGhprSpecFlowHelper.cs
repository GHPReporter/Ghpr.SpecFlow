using System;
using Ghpr.Core.Common;
using Ghpr.Core.Interfaces;
using TechTalk.SpecFlow;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowHelper
    {
        bool UpdateTestDataProvider { get; }
        IGhprSpecFlowScreenHelper ScreenHelper { get; }
        IGhprSpecFlowTestDataHelper TestDataHelper { get; }

        ITestDataProvider GetTestDataProvider(FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc);

        TestRunDto GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc);
        TestRunDto UpdateTestRunOnScenarioEnd(TestRunDto tr, Exception testError, TestOutputDto testOutputDto, FeatureContext fc, ScenarioContext sc);
        void OnGiven(ScenarioContext sc);
        void OnWhen(ScenarioContext sc);
        void OnAnd(ScenarioContext sc);
        void OnBut(ScenarioContext sc);
        void OnThen(ScenarioContext sc);
    }
}
