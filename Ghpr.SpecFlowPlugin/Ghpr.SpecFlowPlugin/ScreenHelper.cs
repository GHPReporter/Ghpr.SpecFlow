using System;
using System.Collections.Generic;
using System.IO;
using Ghpr.Core;
using Ghpr.Core.Common;
using Ghpr.Core.Helpers;
using Ghpr.Core.Interfaces;
using Ghpr.Core.Utils;
using NUnit.Framework;

namespace Ghpr.SpecFlowPlugin
{
    public static class ScreenHelper
    {
        internal const string ScreenKeyTemplate = "ghpr_screenshot_";

        private static string GetScreenKey(int count)
        {
            return $"{ScreenKeyTemplate}{count}";
        }

        public static void SaveScreenshot(byte[] screenBytes)
        {
            var guid = TestContext.CurrentContext.Test.Properties.Get("TestGuid")?.ToString();
            var fullName = TestContext.CurrentContext.Test.FullName;
            var testGuid = guid != null ? Guid.Parse(guid) : GuidConverter.ToMd5HashGuid(fullName);
            var fullPath = Path.Combine(ReporterManager.OutputPath, Paths.Folders.Tests, testGuid.ToString(), Paths.Folders.Img);
            var screenshotName = ScreenshotHelper.SaveScreenshot(fullPath, screenBytes, DateTime.Now);
            var count = 0;
            var screenKey = GetScreenKey(count);
            while (TestContext.CurrentContext.Test.Properties.Get(screenKey) != null)
            {
                count++;
                screenKey = GetScreenKey(count);
            }

            TestContext.CurrentContext.Test.Properties.Add(screenKey, screenshotName);
        }

        public static List<ITestScreenshot> GetScreenshots()
        {
            var screenshots = new List<ITestScreenshot>();
            var count = 0;
            var screenKey = GetScreenKey(count);
            while (TestContext.CurrentContext.Test.Properties.Get(screenKey) != null)
            {
                var screenshotName = TestContext.CurrentContext.Test.Properties.Get(screenKey).ToString();
                count++;
                screenKey = GetScreenKey(count);
                screenshots.Add(new TestScreenshot(screenshotName));
            }

            return screenshots;
        }
    }
}