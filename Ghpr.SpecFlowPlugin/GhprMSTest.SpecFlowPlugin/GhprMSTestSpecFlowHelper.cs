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
        }

        public static string GetFullNameForGuid(TestContext tc)
        {
            return tc?.FullyQualifiedTestClassName + "." + tc?.TestName;
        }

        public IGhprSpecFlowScreenHelper ScreenHelper { get; private set; }
        
        public ITestRun GetTestRunOnScenarioStart(FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc)
        {
            var tc = sc["TestContext"] as TestContext;
            ScreenHelper = new GhprMSTestSpecFlowScreenHelper(tc);

            var fullName = $"{tc?.FullyQualifiedTestClassName}.{fi.Title}.{si.Title}";
            var name = si.Title;
            var guid = GuidConverter.ToMd5HashGuid(GetFullNameForGuid(tc)).ToString();
            var testRun = new TestRun(guid, name, fullName)
            {
                Categories = si.Tags
            };
            return testRun;
        }

        public ITestRun UpdateTestRunOnScenarioEnd(ITestRun tr, Exception testError, string testOutput, FeatureContext fc, ScenarioContext sc)
        {
            tr.Output = testOutput;
            tr.Result = testError == null ? "Passed" : (testError is AssertFailedException ? "Failed" : "Error");
            tr.TestMessage = testError?.Message ?? "";
            tr.TestStackTrace = testError?.StackTrace ?? "";
            tr.Screenshots.AddRange(ScreenHelper.GetScreenshots()
                .Where(s => !tr.Screenshots.Any(cs => cs.Name.Equals(s.Name))));
            return tr;
        }
    }
}