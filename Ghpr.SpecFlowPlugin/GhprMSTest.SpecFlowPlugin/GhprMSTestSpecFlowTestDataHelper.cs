// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.Globalization;
using Ghpr.Core.Common;
using Ghpr.Core.Utils;
using GhprSpecFlow.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GhprMSTest.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowTestDataHelper : IGhprSpecFlowTestDataHelper
    {
        private TestContext _testContext;
        private readonly ScenarioContext _scenarioContext;

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

        public GhprMSTestSpecFlowTestDataHelper(TestContext testContext, ScenarioContext sc, FeatureContext fc)
        {
            _testContext = testContext;
            _scenarioContext = sc;
        }

        public void AddTestData(string actual, string expected, string comment)
        {
            if (_testContext == null)
            {
                _testContext = _scenarioContext.ScenarioContainer.Resolve<TestContext>();
            }
            var count = 0;
            var dateTimeKey = Paths.GetTestDataDateTimeKey(count);
            var actualKey = Paths.GetTestDataActualKey(count);
            var expectedKey = Paths.GetTestDataExpectedKey(count);
            var commentKey = Paths.GetTestDataCommentKey(count);
            while (_testContext.Properties[dateTimeKey] != null)
            {
                count++;
                dateTimeKey = Paths.GetTestDataDateTimeKey(count);
            }

            _testContext.Properties.Add(dateTimeKey, DateTime.Now.ToString("yyyyMMdd_HHmmssfff"));
            _testContext.Properties.Add(actualKey, actual);
            _testContext.Properties.Add(expectedKey, expected);
            _testContext.Properties.Add(commentKey, comment);
        }

        public List<TestDataDto> GetTestData()
        {
            var testData = new List<TestDataDto>();
            var count = 0;
            var dateTimeKey = Paths.GetTestDataDateTimeKey(count);
            var actualKey = Paths.GetTestDataActualKey(count);
            var expectedKey = Paths.GetTestDataExpectedKey(count);
            var commentKey = Paths.GetTestDataCommentKey(count);
            while (_testContext?.Properties[dateTimeKey] != null)
            {
                var date = DateTime.ParseExact(_testContext.Properties[dateTimeKey].ToString(),
                    "yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                var actual = _testContext.Properties[actualKey].ToString();
                var expected = _testContext.Properties[expectedKey].ToString();
                var comment = _testContext.Properties[commentKey].ToString();
                testData.Add(new TestDataDto
                {
                    TestDataInfo = new SimpleItemInfoDto
                    {
                        Date = date,
                        ItemName = "Test data"
                    },
                    Actual = actual,
                    Expected = expected,
                    Comment = comment
                });
            
                count++;
                dateTimeKey = Paths.GetTestDataDateTimeKey(count);
                actualKey = Paths.GetTestDataActualKey(count);
                expectedKey = Paths.GetTestDataExpectedKey(count);
                commentKey = Paths.GetTestDataCommentKey(count);
            }

            return testData;
        }
    }
}