using System;
using System.Linq;
using Ghpr.Core.Common;
using Ghpr.Core.Extensions;
using GhprSpecFlow.Common;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GhprNUnit.SpecFlowPlugin
{
    public class GhprNUnitSpecFlowHelper : IGhprSpecFlowHelper
    {
        public GhprNUnitSpecFlowHelper()
        {
            ScreenHelper = new GhprNUnitSpecFlowScreenHelper();
            TestDataHelper = new GhprNUnitSpecFlowTestDataHelper();
        }

        public IGhprSpecFlowScreenHelper ScreenHelper { get ; }
        public IGhprSpecFlowTestDataHelper TestDataHelper { get; }

        public TestRunDto GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc)
        {
            var className = TestContext.CurrentContext.Test.ClassName;
            var testName = TestContext.CurrentContext.Test.Name;
            var names = className.Split('.').ToList();
            if (names.Count >= 2)
            {
                names.RemoveAt(names.Count - 1);
            }
            className = string.Join(".", names);
            var fullName = $"{className}.{fi.Title}.{testName}";
            var name = si.Title;
            var guid = TestContext.CurrentContext.Test.FullName.ToMd5HashGuid().ToString();
            var testRun = new TestRunDto(guid, name, fullName)
            {
                Categories = si.Tags
            };
            return testRun;
        }

        public TestRunDto UpdateTestRunOnScenarioEnd(TestRunDto tr, Exception testError, string testOutput, FeatureContext fc, ScenarioContext sc, 
            out TestOutputDto testOutputDto)
        {
            testOutputDto = new TestOutputDto
            {
                Output = testOutput,
                SuiteOutput = "",
                TestOutputInfo = new SimpleItemInfoDto
                {
                    Date = tr.TestInfo.Finish,
                    ItemName = "Test output"
                }
            };
            tr.Output = testOutputDto.TestOutputInfo;
            //tr.Result = testError == null ? "Passed" : (testError is AssertionException ? "Failed" : "Error");
            tr.Result = TestContext.CurrentContext.Result.Outcome.ToString();
            tr.TestMessage = testError?.Message ?? "";
            tr.TestStackTrace = testError?.StackTrace ?? "";
            tr.Screenshots.AddRange(ScreenHelper.GetScreenshots()
                .Where(s => !tr.Screenshots.Any(cs => cs.ItemName.Equals(s.ItemName))));
            tr.TestData.AddRange(TestDataHelper.GetTestData());
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