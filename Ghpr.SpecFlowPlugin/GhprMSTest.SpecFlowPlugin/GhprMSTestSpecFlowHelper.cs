// ReSharper disable InconsistentNaming
using System;
using System.Linq;
using Ghpr.Core.Common;
using Ghpr.Core.Extensions;
using GhprSpecFlow.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowHelper : IGhprSpecFlowHelper
    {
        public GhprMSTestSpecFlowHelper()
        {
            ScreenHelper = new GhprMSTestSpecFlowScreenHelper();
            TestDataHelper = new GhprMSTestSpecFlowTestDataHelper();           
        }

        public static string GetFullNameForGuid(TestContext tc, ScenarioContext sc, FeatureContext fc)
        {
            return $"{fc.FeatureInfo.Title} {fc.FeatureInfo.Description} [{string.Join(", ", fc.FeatureInfo.Tags)}] " +
                   $"{sc.ScenarioInfo.Title} [{string.Join(",", sc.ScenarioInfo.Tags)}]";
        }

        public IGhprSpecFlowScreenHelper ScreenHelper { get; private set; }
        public IGhprSpecFlowTestDataHelper TestDataHelper { get; private set; }

        public TestRunDto GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc)
        {
            var tc = sc.TryGetTestContext();
            ScreenHelper = new GhprMSTestSpecFlowScreenHelper(tc, sc, fc);
            TestDataHelper = new GhprMSTestSpecFlowTestDataHelper(tc, sc, fc);

            var fullName = $"{tc?.FullyQualifiedTestClassName}.{fi.Title}.{si.Title}";
            var name = si.Title;
            var nameForGuid = GetFullNameForGuid(tc, sc, fc);
            var guid = nameForGuid.ToMd5HashGuid().ToString();
            var testRun = new TestRunDto(guid, name, fullName)
            {
                Categories = si.Tags
            };
            return testRun;
        }

        public TestRunDto UpdateTestRunOnScenarioEnd(TestRunDto tr, Exception testError, string testOutput, FeatureContext fc, ScenarioContext sc, 
            out TestOutputDto testOutputDto)
        {
            var tc = sc.TryGetTestContext();
            var nameForGuid = GetFullNameForGuid(tc, sc, fc);
            var guid = nameForGuid.ToMd5HashGuid().ToString();
            tr.TestInfo.Guid = Guid.Parse(guid);
            tr.FullName = $"{sc.TryGetTestContext().FullyQualifiedTestClassName}.{fc.FeatureInfo.Title}.{sc.ScenarioInfo.Title}";
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
            tr.Result = testError == null ? "Passed" : (testError is AssertFailedException ? "Failed" : "Error");
            tr.TestMessage = testError?.Message ?? "";
            tr.TestStackTrace = testError?.StackTrace ?? "";
            tr.Screenshots.AddRange(ScreenHelper.GetScreenshots()
                .Where(s => !tr.Screenshots.Any(cs => cs.ItemName.Equals(s.ItemName))));
            tr.TestData.AddRange(TestDataHelper.GetTestData());
            return tr;
        }

        public void OnGiven(ScenarioContext sc)
        {
            (ScreenHelper as GhprMSTestSpecFlowScreenHelper)?.SetTestContext(sc.TryGetTestContext());
            (TestDataHelper as GhprMSTestSpecFlowTestDataHelper)?.SetTestContext(sc.TryGetTestContext());
        }

        public void OnWhen(ScenarioContext sc)
        {
            (ScreenHelper as GhprMSTestSpecFlowScreenHelper)?.SetTestContext(sc.TryGetTestContext());
            (TestDataHelper as GhprMSTestSpecFlowTestDataHelper)?.SetTestContext(sc.TryGetTestContext());
        }

        public void OnAnd(ScenarioContext sc)
        {
            (ScreenHelper as GhprMSTestSpecFlowScreenHelper)?.SetTestContext(sc.TryGetTestContext());
            (TestDataHelper as GhprMSTestSpecFlowTestDataHelper)?.SetTestContext(sc.TryGetTestContext());
        }

        public void OnBut(ScenarioContext sc)
        {
            (ScreenHelper as GhprMSTestSpecFlowScreenHelper)?.SetTestContext(sc.TryGetTestContext());
            (TestDataHelper as GhprMSTestSpecFlowTestDataHelper)?.SetTestContext(sc.TryGetTestContext());
        }

        public void OnThen(ScenarioContext sc)
        {
            (ScreenHelper as GhprMSTestSpecFlowScreenHelper)?.SetTestContext(sc.TryGetTestContext());
            (TestDataHelper as GhprMSTestSpecFlowTestDataHelper)?.SetTestContext(sc.TryGetTestContext());
        }
    }
}