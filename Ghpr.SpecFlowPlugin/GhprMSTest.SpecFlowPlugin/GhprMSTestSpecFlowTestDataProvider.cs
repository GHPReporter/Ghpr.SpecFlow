using System;
using Ghpr.Core.Extensions;
using Ghpr.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

// ReSharper disable InconsistentNaming

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowTestDataProvider : ITestDataProvider
    {
        private readonly TestContext _tc;
        private readonly ScenarioContext _sc;
        private readonly FeatureContext _fc;

        public GhprMSTestSpecFlowTestDataProvider(TestContext tc, ScenarioContext sc, FeatureContext fc)
        {
            _tc = tc;
            _sc = sc;
            _fc = fc;
        }

        public GhprMSTestSpecFlowTestDataProvider()
        {
        }

        public Guid GetCurrentTestRunGuid()
        {
            return GhprMSTestSpecFlowHelper.GetFullNameForGuid(_tc, _sc, _fc).ToMd5HashGuid();
        }

        public string GetCurrentTestRunFullName()
        {
            return GhprMSTestSpecFlowHelper.GetFullName(_tc, _sc, _fc);
        }
    }
}