using System.Collections.Generic;
using Ghpr.Core.Interfaces;
using GhprSpecFlow.Common;

namespace Ghpr.SpecFlowPlugin
{
    public class GhprSpecFlowScreenHelper : IGhprSpecFlowScreenHelper
    {
        public void SaveScreenshot(byte[] screenBytes)
        {
        }

        public List<ITestScreenshot> GetScreenshots()
        {
            return new List<ITestScreenshot>();
        }
    }
}