// ReSharper disable InconsistentNaming
using System;
using System.Linq;
using Ghpr.Core.Common;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
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

        public ITestRun GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc)
        {
            var tc = sc.TryGetTestContext();
            ScreenHelper = new GhprMSTestSpecFlowScreenHelper(tc, sc, fc);
            TestDataHelper = new GhprMSTestSpecFlowTestDataHelper(tc, sc, fc);

            var fullName = $"{tc?.FullyQualifiedTestClassName}.{fi.Title}.{si.Title}";
            var name = si.Title;
            var nameForGuid = GetFullNameForGuid(tc, sc, fc);
            var guid = GuidConverter.ToMd5HashGuid(nameForGuid).ToString();
            var testRun = new TestRun(guid, name, fullName)
            {
                Categories = si.Tags
            };
            return testRun;
        }

        public ITestRun UpdateTestRunOnScenarioEnd(ITestRun tr, Exception testError, string testOutput, FeatureContext fc, ScenarioContext sc)
        {
            var tc = sc.TryGetTestContext();
            var nameForGuid = GetFullNameForGuid(tc, sc, fc);
            var guid = GuidConverter.ToMd5HashGuid(nameForGuid).ToString();
            tr.TestInfo.Guid = Guid.Parse(guid);
            tr.FullName = $"{sc.TryGetTestContext().FullyQualifiedTestClassName}.{fc.FeatureInfo.Title}.{sc.ScenarioInfo.Title}";
            tr.Output = testOutput;
            tr.Result = testError == null ? "Passed" : (testError is AssertFailedException ? "Failed" : "Error");
            tr.TestMessage = testError?.Message ?? "";
            tr.TestStackTrace = testError?.StackTrace ?? "";
            tr.Screenshots.AddRange(ScreenHelper.GetScreenshots()
                .Where(s => !tr.Screenshots.Any(cs => cs.Name.Equals(s.Name))));
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