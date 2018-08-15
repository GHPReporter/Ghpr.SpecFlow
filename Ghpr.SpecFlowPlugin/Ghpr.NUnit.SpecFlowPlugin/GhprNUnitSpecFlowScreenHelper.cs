using System;
using System.Collections.Generic;
using System.IO;
using Ghpr.Core;
using Ghpr.Core.Common;
using Ghpr.Core.Extensions;
using Ghpr.Core.Helpers;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
using Ghpr.LocalFileSystem.Entities;
using GhprSpecFlow.Common;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GhprNUnit.SpecFlowPlugin
{
    public class GhprNUnitSpecFlowScreenHelper : IGhprSpecFlowScreenHelper
    {
        //TODO: fix later
        public void SaveScreenshot(byte[] screenBytes)
        {
            var guid = TestContext.CurrentContext.Test.Properties.Get("TestGuid")?.ToString();
            var fullName = TestContext.CurrentContext.Test.FullName;
            var testGuid = guid != null ? Guid.Parse(guid) : fullName.ToMd5HashGuid();
            //var fullPath = Path.Combine(ReporterManager.OutputPath, Paths.Folders.Tests, testGuid.ToString(), Paths.Folders.Img);
            //var screenshotName = ScreenshotHelper.SaveScreenshot(fullPath, screenBytes, DateTime.Now);
            //var count = 0;
            //var screenKey = Paths.GetScreenKey(count);
            //while (TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(screenKey) != null)
            //{
            //    count++;
            //    screenKey = Paths.GetScreenKey(count);
            //}
            //
            //TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(screenKey, screenshotName);
        }

        public IEnumerable<SimpleItemInfoDto> GetScreenshots()
        {
            var screenshots = new List<SimpleItemInfoDto>();
            var count = 0;
            var screenKey = Paths.GetScreenKey(count);
            while (TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(screenKey) != null)
            {
                //var screenshotName = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get(screenKey).ToString();
                //screenshots.Add(new TestScreenshot(screenshotName));
                //
                //count++;
                //screenKey = ScreenshotHelper.GetScreenKey(count);
            }

            return screenshots;
        }
    }
}