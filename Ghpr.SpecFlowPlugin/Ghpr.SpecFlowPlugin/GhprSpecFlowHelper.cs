using System;
using Ghpr.Core.Interfaces;
using GhprSpecFlow.Common;
using TechTalk.SpecFlow;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowHelper : IGhprSpecFlowHelper
    {
        public ITestRun GetTestRunOnScenarioStart(FeatureInfo fi, ScenarioInfo si, FeatureContext fc, ScenarioContext sc)
        {
            throw new NotImplementedException();
        }

        public ITestRun UpdateTestRunOnScenarioEnd(ITestRun tr, Exception testError, string testOutput, FeatureContext fc,
            ScenarioContext sc)
        {
            throw new NotImplementedException();
        }

        public void OnGiven(ScenarioContext sc)
        {
            throw new NotImplementedException();
        }

        public void OnWhen(ScenarioContext sc)
        {
            throw new NotImplementedException();
        }

        public void OnAnd(ScenarioContext sc)
        {
            throw new NotImplementedException();
        }

        public void OnBut(ScenarioContext sc)
        {
            throw new NotImplementedException();
        }

        public void OnThen(ScenarioContext sc)
        {
            throw new NotImplementedException();
        }

        public IGhprSpecFlowScreenHelper ScreenHelper { get; }
    }
}