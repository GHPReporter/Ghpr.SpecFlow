using System;
using System.Collections.Generic;
using System.Globalization;
using Ghpr.Core.Common;
using Ghpr.Core.Helpers;
using Ghpr.Core.Interfaces;
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
            var dateTimeKey = TestDataHelper.GetTestDataDateTimeKey(count);
            var actualKey = TestDataHelper.GetTestDataActualKey(count);
            var expectedKey = TestDataHelper.GetTestDataExpectedKey(count);
            var commentKey = TestDataHelper.GetTestDataCommentKey(count);
            while (TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(dateTimeKey) != null)
            {
                count++;
                dateTimeKey = ScreenshotHelper.GetScreenKey(count);
            }

            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(dateTimeKey, DateTime.Now.ToString("yyyyMMdd_HHmmssfff"));
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(actualKey, actual);
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(expectedKey, expected);
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(commentKey, comment);
        }

        public List<ITestData> GetTestData()
        {
            var testData = new List<ITestData>();
            var count = 0;
            var dateTimeKey = TestDataHelper.GetTestDataDateTimeKey(count);
            var actualKey = TestDataHelper.GetTestDataActualKey(count);
            var expectedKey = TestDataHelper.GetTestDataExpectedKey(count);
            var commentKey = TestDataHelper.GetTestDataCommentKey(count);
            while (TestContext.CurrentContext.Test.Properties.Get(dateTimeKey) != null)
            {
                var dateTime = DateTime.ParseExact(TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(dateTimeKey).ToString(), 
                    "yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                var actual = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(actualKey).ToString();
                var expected = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(expectedKey).ToString();
                var comment = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(commentKey).ToString();
                testData.Add(new TestData
                {
                    Actual = actual,
                    Expected = expected,
                    Date = dateTime,
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