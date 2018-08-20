// ReSharper disable InconsistentNaming
using System;
using Ghpr.Core.Common;
using Ghpr.Core.Extensions;
using Ghpr.Core.Interfaces;
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
            UpdateTestDataProvider = true;
        }

        public static string GetFullNameForGuid(TestContext tc, ScenarioContext sc, FeatureContext fc)
        {
            return $"{fc.FeatureInfo.Title} {fc.FeatureInfo.Description} [{string.Join(", ", fc.FeatureInfo.Tags)}] " +
                   $"{sc.ScenarioInfo.Title} [{string.Join(",", sc.ScenarioInfo.Tags)}]";
        }

        public static string GetFullName(TestContext tc, ScenarioContext sc, FeatureContext fc)
        {
            return
                $"{sc.TryGetTestContext().FullyQualifiedTestClassName}.{fc.FeatureInfo.Title}.{sc.ScenarioInfo.Title}";
        }

        public bool UpdateTestDataProvider { get; }
        public IGhprSpecFlowScreenHelper ScreenHelper { get; private set; }
        public IGhprSpecFlowTestDataHelper TestDataHelper { get; private set; }

        public ITestDataProvider GetTestDataProvider(FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc)
        {
            return new GhprMSTestSpecFlowTestDataProvider(sc.TryGetTestContext(), sc, fc);
        }

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
                Categories = si.Tags,
                TestInfo =
                {
                    Start = DateTime.Now
                }
            };
            return testRun;
        }

        public TestRunDto UpdateTestRunOnScenarioEnd(TestRunDto tr, Exception testError, string testOutput, FeatureContext fc, ScenarioContext sc, 
            out TestOutputDto testOutputDto)
        {
            var finishDt = DateTime.Now;
            var tc = sc.TryGetTestContext();
            var nameForGuid = GetFullNameForGuid(tc, sc, fc);
            var guid = nameForGuid.ToMd5HashGuid().ToString();
            tr.TestInfo.Guid = Guid.Parse(guid);
            tr.TestInfo.Finish = finishDt;
            tr.FullName = GetFullName(tc, sc, fc);
            testOutputDto = new TestOutputDto
            {
                Output = testOutput,
                SuiteOutput = "",
                TestOutputInfo = new SimpleItemInfoDto
                {
                    Date = finishDt,
                    ItemName = "Test output"
                }
            };
            tr.Output = testOutputDto.TestOutputInfo;
            tr.Result = testError == null ? "Passed" : (testError is AssertFailedException ? "Failed" : "Error");
            tr.TestMessage = testError?.Message ?? "";
            tr.TestStackTrace = testError?.StackTrace ?? "";
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