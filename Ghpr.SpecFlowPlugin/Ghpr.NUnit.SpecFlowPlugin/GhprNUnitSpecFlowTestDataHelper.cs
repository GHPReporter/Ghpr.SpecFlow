using System;
using System.Collections.Generic;
using System.Globalization;
using Ghpr.Core.Common;
using Ghpr.Core.Helpers;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
using GhprSpecFlow.Common;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GhprNUnit.SpecFlowPlugin
{
    public class GhprNUnitSpecFlowTestDataHelper : IGhprSpecFlowTestDataHelper
    {
        public void AddTestData(string actual, string expected, string comment)
        {
            var count = 0;
            var dateTimeKey = Paths.GetTestDataDateTimeKey(count);
            var actualKey = Paths.GetTestDataActualKey(count);
            var expectedKey = Paths.GetTestDataExpectedKey(count);
            var commentKey = Paths.GetTestDataCommentKey(count);
            while (TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(dateTimeKey) != null)
            {
                count++;
                dateTimeKey = Paths.GetScreenKey(count);
            }

            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(dateTimeKey, DateTime.Now.ToString("yyyyMMdd_HHmmssfff"));
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(actualKey, actual);
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(expectedKey, expected);
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(commentKey, comment);
        }

        public List<TestDataDto> GetTestData()
        {
            var testData = new List<TestDataDto>();
            var count = 0;
            var dateTimeKey = Paths.GetTestDataDateTimeKey(count);
            var actualKey = Paths.GetTestDataActualKey(count);
            var expectedKey = Paths.GetTestDataExpectedKey(count);
            var commentKey = Paths.GetTestDataCommentKey(count);
            while (TestContext.CurrentContext.Test.Properties.Get(dateTimeKey) != null)
            {
                var dateTime = DateTime.ParseExact(TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(dateTimeKey).ToString(), 
                    "yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                var actual = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(actualKey).ToString();
                var expected = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(expectedKey).ToString();
                var comment = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(commentKey).ToString();
                testData.Add(new TestDataDto
                {
                    Actual = actual,
                    Expected = expected,
                    TestDataInfo = new SimpleItemInfoDto
                    {
                        Date = dateTime,
                        ItemName = "Test data"
                    },
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