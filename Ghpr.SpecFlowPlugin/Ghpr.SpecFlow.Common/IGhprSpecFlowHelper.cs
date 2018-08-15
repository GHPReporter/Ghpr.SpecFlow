using System;
using Ghpr.Core.Common;
using TechTalk.SpecFlow;

namespace GhprSpecFlow.Common
{
    public interface IGhprSpecFlowHelper
    {
        IGhprSpecFlowScreenHelper ScreenHelper { get; }
        IGhprSpecFlowTestDataHelper TestDataHelper { get; }

        TestRunDto GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc);
        TestRunDto UpdateTestRunOnScenarioEnd(TestRunDto tr, Exception testError, string testOutput, FeatureContext fc, ScenarioContext sc, out TestOutputDto testOutputDto);
        void OnGiven(ScenarioContext sc);
        void OnWhen(ScenarioContext sc);
        void OnAnd(ScenarioContext sc);
        void OnBut(ScenarioContext sc);
        void OnThen(ScenarioContext sc);
    }
}
