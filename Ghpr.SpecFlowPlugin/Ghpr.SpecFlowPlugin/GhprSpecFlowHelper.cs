using System;
using System.Linq;
using Ghpr.Core.Common;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
using GhprSpecFlow.Common;
using TechTalk.SpecFlow;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowHelper : IGhprSpecFlowHelper
    {
        public GhprSpecFlowHelper()
        {
            ScreenHelper = new GhprSpecFlowScreenHelper();
        }

        public IGhprSpecFlowScreenHelper ScreenHelper { get; }

        public ITestRun GetTestRunOnScenarioStart(ITestRunner runner, FeatureInfo fi, ScenarioInfo si, FeatureContext fc,
            ScenarioContext sc)
        {
            var fullName = $"Features.{fi.Title}.{si.Title}";
            var name = si.Title;
            var guid = GuidConverter.ToMd5HashGuid(fullName).ToString();
            var testRun = new TestRun(guid, name, fullName)
            {
                Categories = si.Tags
            };
            return testRun;
        }

        public ITestRun UpdateTestRunOnScenarioEnd(ITestRun tr, Exception testError, string testOutput, FeatureContext fc,
            ScenarioContext sc)
        {
            tr.Output = testOutput;
            tr.Result = testError == null ? "Passed" : "Failed";
            tr.TestMessage = testError?.Message ?? "";
            tr.TestStackTrace = testError?.StackTrace ?? "";
            tr.Screenshots.AddRange(ScreenHelper.GetScreenshots()
                .Where(s => !tr.Screenshots.Any(cs => cs.Name.Equals(s.Name))));
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