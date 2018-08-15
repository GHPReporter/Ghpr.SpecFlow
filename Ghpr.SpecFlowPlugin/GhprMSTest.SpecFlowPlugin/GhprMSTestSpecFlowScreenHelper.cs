// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.IO;
using Ghpr.Core;
using Ghpr.Core.Common;
using Ghpr.Core.Extensions;
using Ghpr.Core.Utils;
using Ghpr.LocalFileSystem.Entities;
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

        //TODO: update screenshot saving
        public void SaveScreenshot(byte[] screenBytes)
        {
            //var guid = _testContext.Properties["TestGuid"]?.ToString();
            //var fullName = GhprMSTestSpecFlowHelper.GetFullNameForGuid(_testContext, _scenarioContext, _featureContext);
            //var testGuid = guid != null ? Guid.Parse(guid) : fullName.ToMd5HashGuid();
            //var fullPath = Path.Combine(ReporterManager.OutputPath, Paths.Folders.Tests, testGuid.ToString(), Paths.Folders.Img);
            //var screenshotName = ScreenshotHelper.SaveScreenshot(fullPath, screenBytes, DateTime.Now);
            //var count = 0;
            //var screenKey = ScreenshotHelper.GetScreenKey(count);
            //while (_testContext.Properties[screenKey] != null)
            //{
            //    count++;
            //    screenKey = ScreenshotHelper.GetScreenKey(count);
            //}
            //
            //_testContext.Properties.Add(screenKey, screenshotName);
        }

        public IEnumerable<SimpleItemInfoDto> GetScreenshots()
        {
            var screenshots = new List<SimpleItemInfoDto>();
            //var count = 0;
            //var screenKey = ScreenshotHelper.GetScreenKey(count);
            //while (_testContext?.Properties[screenKey] != null)
            //{
            //    var screenshotName = _testContext.Properties[screenKey].ToString();
            //    screenshots.Add(new TestScreenshot(screenshotName));
            //
            //    count++;
            //    screenKey = ScreenshotHelper.GetScreenKey(count);
            //}

            return screenshots;
        }
    }
}