using System;
using Ghpr.Core.Common;
using Ghpr.Core.Extensions;
using Ghpr.Core.Interfaces;
using GhprSpecFlow.Common;
using TechTalk.SpecFlow;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowHelper : IGhprSpecFlowHelper
    {
        public GhprSpecFlowHelper()
        {
            ScreenHelper = new GhprSpecFlowScreenHelper();
            TestDataHelper = new GhprSpecFlowPluginTestDataHelper();
            UpdateTestDataProvider = false;
        }

        public bool UpdateTestDataProvider { get; }
        public IGhprSpecFlowScreenHelper ScreenHelper { get; }
        public IGhprSpecFlowTestDataHelper TestDataHelper { get; }

        public ITestDataProvider GetTestDataProvider(FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc)
        {
            return new GhprSpecFlowTestDataProvider();
        }

        public TestRunDto GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc,
            ScenarioContext sc)
        {
            var fullName = $"Features.{fi.Title}.{si.Title}";
            var name = si.Title;
            var guid = fullName.ToMd5HashGuid();
            var testRun = new TestRunDto(guid, name, fullName)
            {
                Categories = si.Tags
            };
            return testRun;
        }

        public TestRunDto UpdateTestRunOnScenarioEnd(TestRunDto tr, Exception testError, string testOutput, FeatureContext fc,
            ScenarioContext sc, out TestOutputDto testOutputDto)
        {
            var toDto = new TestOutputDto
            {
                Output = testOutput,
                SuiteOutput = "",
                TestOutputInfo = new SimpleItemInfoDto {ItemName = "Test output", Date = tr.TestInfo.Finish}
            };
            testOutputDto = toDto;
            tr.Output = toDto.TestOutputInfo;
            tr.Result = testError == null ? "Passed" : "Failed";
            tr.TestMessage = testError?.Message ?? "";
            tr.TestStackTrace = testError?.StackTrace ?? "";
            return tr;
        }
        
        public void OnGiven(ScenarioContext sc)
        {
        }

        public void OnWhen(ScenarioContext sc)
        {
        }

        public void OnAnd(ScenarioContext sc)
        {
        }

        public void OnBut(ScenarioContext sc)
        {
        }

        public void OnThen(ScenarioContext sc)
        {
        }
    }
}