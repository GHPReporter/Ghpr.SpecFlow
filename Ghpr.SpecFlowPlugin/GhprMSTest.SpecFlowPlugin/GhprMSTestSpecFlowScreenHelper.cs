// ReSharper disable InconsistentNaming

using Ghpr.Core;
using GhprSpecFlow.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowScreenHelper : IGhprSpecFlowScreenHelper
    {
        private TestContext _testContext;
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;

        public GhprMSTestSpecFlowScreenHelper()
        {
        }

        public GhprMSTestSpecFlowScreenHelper(TestContext testContext, ScenarioContext sc, FeatureContext fc)
        {
            _testContext = testContext;
            _scenarioContext = sc;
            _featureContext = fc;
        }

        public void SetTestContext(TestContext testContext)
        {
            if (testContext!= null)
            {
                _testContext = testContext;
            }
        }

        public void SetContext(TestContext testContext, ScenarioContext sc, FeatureContext fc)
        {
            _testContext = testContext;
            _scenarioContext = sc;
            _featureContext = fc;
        }

        public void SaveScreenshot(byte[] screenBytes, string format)
        {
            ReporterManager.SaveScreenshot(screenBytes, format);
        }
    }
}