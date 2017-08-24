// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Ghpr.Core;
using Ghpr.Core.Common;
using Ghpr.Core.Helpers;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
using GhprSpecFlow.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowTestDataHelper : IGhprSpecFlowTestDataHelper
    {
        private TestContext _testContext;
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;

        public GhprMSTestSpecFlowTestDataHelper()
        {
        }

        public void SetTestContext(TestContext testContext)
        {
            if (testContext != null)
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

        public GhprMSTestSpecFlowTestDataHelper(TestContext testContext, ScenarioContext sc, FeatureContext fc)
        {
            _testContext = testContext;
            _scenarioContext = sc;
            _featureContext = fc;
        }

        public void AddTestData(string actual, string expected, string comment)
        {
            var count = 0;
            var dateTimeKey = TestDataHelper.GetTestDataDateTimeKey(count);
            var actualKey = TestDataHelper.GetTestDataActualKey(count);
            var expectedKey = TestDataHelper.GetTestDataExpectedKey(count);
            var commentKey = TestDataHelper.GetTestDataCommentKey(count);
            while (_testContext.Properties[dateTimeKey] != null)
            {
                count++;
                dateTimeKey = TestDataHelper.GetTestDataDateTimeKey(count);
            }

            _testContext.Properties.Add(dateTimeKey, DateTime.Now.ToString("yyyyMMdd_HHmmssfff"));
            _testContext.Properties.Add(actualKey, actual);
            _testContext.Properties.Add(expectedKey, expected);
            _testContext.Properties.Add(commentKey, comment);
        }

        public List<ITestData> GetTestData()
        {
            var testData = new List<ITestData>();
            var count = 0;
            var dateTimeKey = TestDataHelper.GetTestDataDateTimeKey(count);
            var actualKey = TestDataHelper.GetTestDataActualKey(count);
            var expectedKey = TestDataHelper.GetTestDataExpectedKey(count);
            var commentKey = TestDataHelper.GetTestDataCommentKey(count);
            while (_testContext?.Properties[dateTimeKey] != null)
            {
                var date = DateTime.ParseExact(_testContext.Properties[dateTimeKey].ToString(),
                    "yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                var actual = _testContext.Properties[actualKey].ToString();
                var expected = _testContext.Properties[expectedKey].ToString();
                var comment = _testContext.Properties[commentKey].ToString();
                testData.Add(new TestData
                {
                    Date = date,
                    Actual = actual,
                    Expected = expected,
                    Comment = comment
                });

                count++;
                dateTimeKey = TestDataHelper.GetTestDataDateTimeKey(count);
                actualKey = TestDataHelper.GetTestDataActualKey(count);
                expectedKey = TestDataHelper.GetTestDataExpectedKey(count);
                commentKey = TestDataHelper.GetTestDataCommentKey(count);
            }

            return testData;
        }
    }
}